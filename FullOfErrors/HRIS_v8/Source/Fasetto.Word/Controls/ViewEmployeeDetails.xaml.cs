using System.Windows;
using System.Windows.Controls;
using Fasetto.Word.Core;
using System;
using System.Linq;

namespace Fasetto.Word
{
    /// <summary>
    /// Interaction logic for ViewEmployeeDetails.xaml
    /// </summary>
    public partial class ViewEmployeeDetails : UserControl
    {
        EmployeeItem mEmpItem = new EmployeeItem();
        public ViewEmployeeDetails(EmployeeItem empItem)
        {
            InitializeComponent();

            displayDetails(empItem);

            mEmpItem = empItem;

            cbPosition.ItemsSource = StaticPositionCollection.staticPositionList;
            cbEmpStatus.ItemsSource = Enum.GetValues(typeof(EmployeeStatus)).Cast<EmployeeStatus>();
        }

        private void displayDetails(EmployeeItem item)
        {
            tbEmployeeId.Text = item._EMP_NO;
            tbFirstName.Text = item._FIRST_NAME;
            tbMiddleName.Text = item._MIDDLE_NAME;
            tbLastName.Text = item._LAST_NAME;
            tbReligion.Text = item._RELIGION;
            if (item._GENDER == "Male")
            {
                rbMale.IsChecked = true;
                rbFemale.IsChecked = false;
            }
            else if (item._GENDER == "Female")
            {
                rbFemale.IsChecked = true;
                rbMale.IsChecked = false;
            }
            dpBirthday.SelectedDate = DateTime.Parse(item._BIRTHDAY);
            tbNationality.Text = item._NATIONALITY;
            tbPassportNo.Text = item._PASSPORT;
            tbEmail.Text = item._EMAIL_ADDRESS;
            tbContactNumber.Text = item._CONTACT;
            tbBirthPlace.Text = item._BIRTH_PLACE;
            tbPresentAddress.Text = item._PRESENT_ADDRESS;
            tbPermanentAddress.Text = item._PERMANENT_ADDRESS;
            tbNamePTC.Text = item._IOE_PERSON;
            tbContactPTC.Text = item._IOE_CONTACT;
            tbRelationPTC.Text = item._IOE_RELATION;
            tbAddressPTC.Text = item._IOE_ADDRESS;

            //cbEmpStatus.sele
            dpDateEmployed.SelectedDate = DateTime.Parse(item._DATE_JOINED);
            dpEndProvision.SelectedDate = DateTime.Parse(item._END_PROVITION);
            tbMonthlySalary.Text = item._MONTHLY_SALARY.ToString();
            tbSSSNo.Text = item._SSS_NO;
            tbPhHealth.Text = item._PHIL_HEALTH_NO;
            tbPagIbig.Text = item._PAG_IBIG_NO;
            tbBIR.Text = item._BIR_NO;
            tbDedSSS.Text = item._DEDUC_SSS.ToString();
            tbDedPhilHealth.Text = item._DEDUC_PHIL_HEALTH.ToString();
            tbDedPagIbig.Text = item._DEDUC_PAG_IBIG.ToString();
            tbDedBIR.Text = item._DEDUC_BIR.ToString();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            EmployeeManagement.mEmpTransitioner.SelectedIndex = 0;
            EmployeeManagement.mEmpTransitioner.Items.RemoveAt(1);
        }
    }
}
