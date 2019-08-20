using System.Windows;
using System.Windows.Controls;
using Fasetto.Word.Core;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Fasetto.Word
{
    /// <summary>
    /// Interaction logic for ViewEmployeeDetails.xaml
    /// </summary>
    public partial class ViewEmployeeDetails : UserControl
    {
        EducationItem selectedEduItem = new EducationItem();
        ExperienceItem selectedExpItem = new ExperienceItem();

        EmployeeItem mEmpItem = new EmployeeItem();
        List<EducationItem> mEduList = new List<EducationItem>();
        List<ExperienceItem> mExpList = new List<ExperienceItem>();
        List<TrainingItem> mTrainList = new List<TrainingItem>();

        List<EducationItem> mVocationalEduListToBind = new List<EducationItem>();
        List<ExperienceItem> mWorkExpToBind = new List<ExperienceItem>();

        public ViewEmployeeDetails(EmployeeItem empItem, List<EducationItem> eduList, List<ExperienceItem> expList, List<TrainingItem> trainList)
        {
            InitializeComponent();

            dpBirthday.SelectedDate = DateTime.Today;
            dpDateEmployed.SelectedDate = DateTime.Today;
            dpEduDoctoralDate.SelectedDate = DateTime.Today;
            dpEduMasteralDate.SelectedDate = DateTime.Today;
            dpEduPrimaryDate.SelectedDate = DateTime.Today;
            dpEduSecondaryDate.SelectedDate = DateTime.Today;
            dpEduTertiaryDate.SelectedDate = DateTime.Today;
            dpEduVocationalDate.SelectedDate = DateTime.Today;
            dpEndProvision.SelectedDate = DateTime.Today;
            dpTrainingFinished.SelectedDate = DateTime.Today;
            dpWorkEnd.SelectedDate = DateTime.Today;
            dpWorkStart.SelectedDate = DateTime.Today;

            cbPosition.ItemsSource = StaticPositionCollection.staticPositionList;
            cbEmpStatus.ItemsSource = Enum.GetValues(typeof(EmployeeStatus)).Cast<EmployeeStatus>();

            mEmpItem = empItem;
            mEduList = eduList;
            mExpList = expList;
            mTrainList = trainList;  
        }

        private void displayPersonalDetails(EmployeeItem empItem)
        {
            tbEmployeeId.Text = empItem._EMP_NO;
            tbFirstName.Text = empItem._FIRST_NAME;
            tbMiddleName.Text = empItem._MIDDLE_NAME;
            tbLastName.Text = empItem._LAST_NAME;
            tbReligion.Text = empItem._RELIGION;
            if (empItem._GENDER == "Male")
            {
                rbMale.IsChecked = true;
                rbFemale.IsChecked = false;
            }
            else if (empItem._GENDER == "Female")
            {
                rbFemale.IsChecked = true;
                rbMale.IsChecked = false;
            }
            dpBirthday.SelectedDate = DateTime.Parse(empItem._BIRTHDAY);
            tbNationality.Text = empItem._NATIONALITY;
            tbPassportNo.Text = empItem._PASSPORT;
            tbEmail.Text = empItem._EMAIL_ADDRESS;
            tbContactNumber.Text = empItem._CONTACT;
            tbBirthPlace.Text = empItem._BIRTH_PLACE;
            tbPresentAddress.Text = empItem._PRESENT_ADDRESS;
            tbPermanentAddress.Text = empItem._PERMANENT_ADDRESS;
            tbNamePTC.Text = empItem._IOE_PERSON;
            tbContactPTC.Text = empItem._IOE_CONTACT;
            tbRelationPTC.Text = empItem._IOE_RELATION;
            tbAddressPTC.Text = empItem._IOE_ADDRESS;
            cbPosition.SelectedValue = empItem._POS_ID;
            cbEmpStatus.SelectedItem = SetEmpStatus(empItem._EMP_STATUS);
            dpDateEmployed.SelectedDate = DateTime.Parse(empItem._DATE_JOINED);
            dpEndProvision.SelectedDate = DateTime.Parse(empItem._END_PROVITION);
            tbMonthlySalary.Text = empItem._MONTHLY_SALARY.ToString();
            tbSSSNo.Text = empItem._SSS_NO;
            tbPhHealth.Text = empItem._PHIL_HEALTH_NO;
            tbPagIbig.Text = empItem._PAG_IBIG_NO;
            tbBIR.Text = empItem._BIR_NO;
            tbDedSSS.Text = empItem._DEDUC_SSS.ToString();
            tbDedPhilHealth.Text = empItem._DEDUC_PHIL_HEALTH.ToString();
            tbDedPagIbig.Text = empItem._DEDUC_PAG_IBIG.ToString();
            tbDedBIR.Text = empItem._DEDUC_BIR.ToString();
        }

        private void displayEducationDetails(List<EducationItem> eduList)
        {
            foreach (var item in eduList)
            {
                switch (item._EDU_LEVEL)
                {
                    case "Primary":
                        displayPrimaryEducation(item);
                        break;
                    case "Secondary":
                        displaySecondaryEducation(item);
                        break;
                    case "Tertiary":
                        displayTertiaryEducation(item);
                        break;
                    case "Masteral":
                        displayMasteralEducation(item);
                        break;
                    case "Doctoral":
                        displayDoctoralEducation(item);
                        break;
                    case "Vocational":
                        setVocationalEducations(item);
                        break;
                }
            }
            cbVocationalCollect.ItemsSource = mVocationalEduListToBind;
        }

        private void displayPrimaryEducation(EducationItem item)
        {
            tbSchoolNamePrimary.Text = item._EDU_SCHOOL_NAME;
            tbSchoolAddressPrimary.Text = item._EDU_SCHOOL_ADDRESS;
            dpEduPrimaryDate.SelectedDate = DateTime.Parse(item._EDU_DATE_GRADUATED);
        }

        private void displaySecondaryEducation(EducationItem item)
        {
            tbSchoolNameSecondary.Text = item._EDU_SCHOOL_NAME;
            tbSchoolAddressSecondary.Text = item._EDU_SCHOOL_ADDRESS;
            dpEduSecondaryDate.SelectedDate = DateTime.Parse(item._EDU_DATE_GRADUATED);
        }

        private void displayTertiaryEducation(EducationItem item)
        {
            tbSchoolNameTertiary.Text = item._EDU_SCHOOL_NAME;
            tbSchoolAddressTertiary.Text = item._EDU_SCHOOL_ADDRESS;
            tbDegreeTertiary.Text = item._EDU_DEGREE_EARNED;
            dpEduTertiaryDate.SelectedDate = DateTime.Parse(item._EDU_DATE_GRADUATED);
        }

        private void displayMasteralEducation(EducationItem item)
        {
            tbSchoolNameMasteral.Text = item._EDU_SCHOOL_NAME;
            tbSchoolAddressMasteral.Text = item._EDU_SCHOOL_ADDRESS;
            tbDegreeMasteral.Text = item._EDU_DEGREE_EARNED;
            dpEduMasteralDate.SelectedDate = DateTime.Parse(item._EDU_DATE_GRADUATED);
        }

        private void displayDoctoralEducation(EducationItem item)
        {
            tbSchoolNameDoctoral.Text = item._EDU_SCHOOL_NAME;
            tbSchoolAddressDoctoral.Text = item._EDU_SCHOOL_ADDRESS;
            tbDegreeDoctoral.Text = item._EDU_DEGREE_EARNED;
            dpEduDoctoralDate.SelectedDate = DateTime.Parse(item._EDU_DATE_GRADUATED);
        }

        private void setVocationalEducations(EducationItem item)
        {
            var vocEduItem = new EducationItem();
            vocEduItem._EDU_SCHOOL_NAME = item._EDU_SCHOOL_NAME;
            vocEduItem._EDU_SCHOOL_ADDRESS = item._EDU_SCHOOL_ADDRESS;
            vocEduItem._EDU_DEGREE_EARNED = item._EDU_DEGREE_EARNED;
            vocEduItem._EDU_DATE_GRADUATED = item._EDU_DATE_GRADUATED;
            vocEduItem._EDU_HOLDER = "Vocational " + (mVocationalEduListToBind.Count + 1);

            mVocationalEduListToBind.Add(vocEduItem);
        }

        private void displayExperieceDetails(List<ExperienceItem> expList)
        {
            foreach (var item in expList)
            {
                var mItem = new ExperienceItem();
                mItem._DESIGNATION = item._DESIGNATION;
                mItem._COMPANY = item._COMPANY;
                mItem._WORK_LOCATION = item._WORK_LOCATION;
                mItem._DATE_START = item._DATE_START;
                mItem._DATE_END = item._DATE_END;
                mItem._EXP_HOLDER = "Job " + (mWorkExpToBind.Count + 1);

                mWorkExpToBind.Add(mItem);
            }
            cbWorkCollection.ItemsSource = mWorkExpToBind;
        }

        private void displayTrainingDetails(List<TrainingItem> trainList)
        {
            //foreach (var item in trainList)
            //{
            //    var mItem = new TrainingItem();
            //    mItem._DESIGNATION = item._DESIGNATION;
            //    mItem._COMPANY = item._COMPANY;
            //    mItem._WORK_LOCATION = item._WORK_LOCATION;
            //    mItem._DATE_START = item._DATE_START;
            //    mItem._DATE_END = item._DATE_END;
            //    mItem._EXP_HOLDER = "Job " + (mWorkExpToBind.Count + 1);

            //    mWorkExpToBind.Add(mItem);
            //}
            //cbWorkCollection.ItemsSource = mWorkExpToBind;
        }

        private Enum SetEmpStatus(string item)
        {
            return (EmployeeStatus)Enum.Parse(typeof(EmployeeStatus), item);
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            EmployeeManagement.mEmpTransitioner.SelectedIndex = 0;
            EmployeeManagement.mEmpTransitioner.Items.RemoveAt(1);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            displayPersonalDetails(mEmpItem);
            displayEducationDetails(mEduList);
            displayExperieceDetails(mExpList);
            displayTrainingDetails(mTrainList);
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ChangeBtnEditState()
        {

        }

        private void CbVocationalCollect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbVocationalCollect.SelectedIndex != -1)
            {
                var item = cbVocationalCollect.SelectedItem as EducationItem;
                selectedEduItem = item;

                ViewSelectedEdu();
                //hasSelectedEdu = true;
                //ChangeVocBtnIcon();
            }
        }

        private void ViewSelectedEdu()
        {
            if (cbVocationalCollect.SelectedIndex != -1)
            {
                tbSchoolNameVocational.Text = selectedEduItem._EDU_SCHOOL_NAME;
                tbSchoolAddressVocational.Text = selectedEduItem._EDU_SCHOOL_ADDRESS;
                tbDegreeVocational.Text = selectedEduItem._EDU_DEGREE_EARNED;
                dpEduVocationalDate.SelectedDate = DateTime.Parse(selectedEduItem._EDU_DATE_GRADUATED);
            }
        }

        private void ViewSelectedExp()
        {
            if (cbWorkCollection.SelectedIndex != -1)
            {
                tbDesignation.Text = selectedExpItem._DESIGNATION;
                tbCompanyName.Text = selectedExpItem._COMPANY;
                tbComanyLocation.Text = selectedExpItem._WORK_LOCATION;
                dpWorkStart.SelectedDate = DateTime.Parse(selectedExpItem._DATE_START);
                dpWorkEnd.SelectedDate = DateTime.Parse(selectedExpItem._DATE_END);
            }
        }

        private void CbWorkCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbWorkCollection.SelectedIndex != -1)
            {
                var item = cbWorkCollection.SelectedItem as ExperienceItem;
                selectedExpItem = item;

                ViewSelectedExp();
                //hasSelectedEdu = true;
                //ChangeVocBtnIcon();
            }
        }
    }
}
