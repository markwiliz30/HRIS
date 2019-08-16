using System.Windows;
using System.Windows.Controls;
using Fasetto.Word.Core;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System;
using System.Linq;

namespace Fasetto.Word
{
    /// <summary>
    /// Interaction logic for AddEmployee.xaml
    /// </summary>
    public partial class AddEmployee : UserControl
    {
        int selectedDesignation = -1;
        string selectedEmpStatus;
        public AddEmployee()
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
        }

        private string genderSelectResult()
        {
            if (rbMale.IsChecked == true)
            {
                return "Male";
            }
            else if (rbFemale.IsChecked == true)
            {
                return "Female";
            }
            else
            {
                return "";
            }
        }

        private bool InputValidation()
        {
            if (tbEmployeeId.Text == "" || tbEmployeeId.Text == null)
            {
                MessageBox.Show("Please input Employee ID");
                return false;
            }
            else if (tbFirstName.Text == "" || tbFirstName.Text == null)
            {
                MessageBox.Show("Please input First Name");
                return false;
            }
            else if (tbMiddleName.Text == "" || tbMiddleName.Text == null)
            {
                MessageBox.Show("Please input Middle Name");
                return false;
            }
            else if (tbLastName.Text == "" || tbLastName.Text == null)
            {
                MessageBox.Show("Please input Last Name");
                return false;
            }
            else if (pbPassword.Password == "" || pbPassword.Password == null)
            {
                MessageBox.Show("Please input Password");
                return false;
            }
            else if (pbConfirmPass.Password == "" || pbConfirmPass.Password == null)
            {
                MessageBox.Show("Please input Confirmation Password");
                return false;
            }
            else if (rbMale.IsChecked == false && rbFemale.IsChecked == false)
            {
                MessageBox.Show("Please select gender");
                return false;
            }
            else if (dpBirthday.Text == "" || dpBirthday.Text == null)
            {
                MessageBox.Show("Please input Birth Date");
                return false;
            }
            else if (tbNationality.Text == "" || tbNationality == null)
            {
                MessageBox.Show("Please input Nationality");
                return false;
            }
            else if (tbPresentAddress.Text == "" || tbPresentAddress.Text == null)
            {
                MessageBox.Show("Please input Present Address");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void SetValues()
        {
            if (InputValidation())
            {
                if (pbPassword.Password != pbConfirmPass.Password)
                {
                    MessageBox.Show("Password did'nt match the Confirm Password");
                }
                else
                {
                    EmployeeItem item = new EmployeeItem();

                    item._EMP_NO = tbEmployeeId.Text;
                    item._FIRST_NAME = tbFirstName.Text;
                    item._MIDDLE_NAME = tbMiddleName.Text;
                    item._LAST_NAME = tbLastName.Text;
                    item._EMP_PASSWORD = pbPassword.Password;

                    if (rbMale.IsChecked == true)
                    {
                        item._GENDER = "Male";
                    }
                    else if (rbFemale.IsChecked == true)
                    {
                        item._GENDER = "Female";
                    }
                    item._BIRTHDAY = dpBirthday.Text;
                    item._NATIONALITY = tbNationality.Text;
                    item._PASSPORT = tbPassportNo.Text;
                    item._RELIGION = tbReligion.Text;
                    item._EMAIL_ADDRESS = tbEmail.Text;
                    item._CONTACT = tbContactNumber.Text;
                    item._BIRTH_PLACE = tbBirthPlace.Text;
                    item._PRESENT_ADDRESS = tbPresentAddress.Text;
                    item._PERMANENT_ADDRESS = tbPermanentAddress.Text;
                    item._IOE_PERSON = tbNamePTC.Text;
                    item._IOE_CONTACT = tbContactPTC.Text;
                    item._IOE_RELATION = tbRelationPTC.Text;
                    item._IOE_ADDRESS = tbAddressPTC.Text;
                    item._EMP_STATUS = selectedEmpStatus;
                    item._DATE_JOINED = dpDateEmployed.Text;
                    item._END_PROVITION = dpEndProvision.Text;
                    item._POS_ID = selectedDesignation;
                    item._MONTHLY_SALARY = double.Parse(tbMonthlySalary.Text);
                    item._SSS_NO = tbSSSNo.Text;
                    item._PHIL_HEALTH_NO = tbPhHealth.Text;
                    item._PAG_IBIG_NO = tbPagIbig.Text;
                    item._BIR_NO = tbBIR.Text;
                    item._DEDUC_SSS = double.Parse(tbDedSSS.Text);
                    item._DEDUC_PHIL_HEALTH = double.Parse(tbDedPhilHealth.Text);
                    item._DEDUC_PAG_IBIG = double.Parse(tbDedPagIbig.Text);
                    item._DEDUC_BIR = double.Parse(tbDedBIR.Text);

                    item._HOURLY_RATE = 300;


                    //try
                    //{
                    SaveEmpoyeeDetails(item);
                    MessageBox.Show("New Employee added.");
                    //}
                    //catch (System.Exception)
                    //{
                    //MessageBox.Show("Error saving new employee.");
                    //}

                    EmployeeCollection myEmpList = new EmployeeCollection();
                    myEmpList.RetreiveAllEmployee();

                    //ClearInputFields();

                    EmployeeManagement.mEmpTransitioner.SelectedIndex = 0;
                    EmployeeManagement.mEmpTransitioner.Items.RemoveAt(1);

                    
                }
            }
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            SetValues();
        }

        private void SaveEmpoyeeDetails(EmployeeItem myItem)
        {
            EmployeeManager myManager = new EmployeeManager();
            myManager.SaveData(myItem);
        }

        private void ClearInputFields()
        {
            tbEmployeeId.Text = "";
            tbFirstName.Text = "";
            tbMiddleName.Text = "";
            tbLastName.Text = "";
            tbNationality.Text = "";
            tbEmail.Text = "";
            tbContactNumber.Text = "";
            tbReligion.Text = "";
            tbPresentAddress.Text = "";
            tbPermanentAddress.Text = "";
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            EmployeeManagement.mEmpTransitioner.SelectedIndex = 0;
            EmployeeManagement.mEmpTransitioner.Items.RemoveAt(1);
        }

        private void CbPosition_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = cbPosition.SelectedItem as DesignationItem;
            selectedDesignation = Int32.Parse(item._POS_ID.ToString());
            //MessageBox.Show(selectedDesignation.ToString());
        }

        private void CbEmpStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedEmpStatus = cbEmpStatus.SelectedValue.ToString();
        }
    }
}
