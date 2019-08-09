using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using Fasetto.Word.Core;

namespace Fasetto.Word
{
    /// <summary>
    /// Interaction logic for EditEmployeeDetails.xaml
    /// </summary>
    public partial class EditEmployeeDetails : UserControl
    {

        int canDisplay = 0;
        static string selectedEmpId;
        private EmployeeCollection mEmployeeCollection = new EmployeeCollection();
        private EmployeeManager mEmployeeManager = new EmployeeManager();
        private EmployeeItem mEmployeeItem;
        public EditEmployeeDetails()
        {
            InitializeComponent();
        }

        private void ButtonUpdate_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            UpdateEmployee();
            EmployeeManagement.mEmpTransitioner.SelectedIndex = 0;
            canDisplay = 2;
        }

        private void ButtonCancel_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            EmployeeManagement.mEmpTransitioner.SelectedIndex = 0;
            canDisplay = 2;
        }

        public static void SetValues(string item)
        {
            selectedEmpId = item;
        }

        private void Grid_LayoutUpdated(object sender, EventArgs e)
        {
            //DisplayValues();
        }

        private void DisplayValues()
        {
            
                try
                {
                    if (selectedEmpId != "" && selectedEmpId != null)
                    {
                        canDisplay = 1;
                        mEmployeeItem = new EmployeeItem();
                        mEmployeeItem = mEmployeeCollection.RetreiveSpecificEmployee(selectedEmpId);

                        tbFirstName.Text = mEmployeeItem._firstName.ToString();
                        tbMiddleName.Text = mEmployeeItem._middleName.ToString();
                        tbLastName.Text = mEmployeeItem._lastName.ToString();
                        tbNationality.Text = mEmployeeItem._nationality.ToString();
                        tbReligion.Text = mEmployeeItem._religion.ToString();
                        tbPresentAddress.Text = mEmployeeItem._presentAddress.ToString();
                        tbPermanentAddress.Text = mEmployeeItem._permanentAddress.ToString();
                        tbEmail.Text = mEmployeeItem._eMail.ToString();
                        tbContactNumber.Text = mEmployeeItem._contactNum.ToString();
                        tbEmployeeId.Text = mEmployeeItem._employeeId.ToString();
                    }
                }
                catch (Exception)
                {

                    System.Windows.MessageBox.Show("Error");
                }
            

            //if (canDisplay == 2)
            //{
            //    canDisplay = 0;
            //}
        }

        private void UpdateEmployee()
        {
            mEmployeeItem = new EmployeeItem();

            mEmployeeItem._employeeId = tbEmployeeId.Text;
            mEmployeeItem._firstName = tbFirstName.Text;
            mEmployeeItem._middleName = tbMiddleName.Text;
            mEmployeeItem._lastName = tbLastName.Text;
            mEmployeeItem._nationality = tbNationality.Text;
            mEmployeeItem._religion = tbReligion.Text;
            mEmployeeItem._eMail = tbEmail.Text;
            mEmployeeItem._contactNum = tbContactNumber.Text;
            mEmployeeItem._presentAddress = tbPresentAddress.Text;
            mEmployeeItem._permanentAddress = tbPermanentAddress.Text;

            try
            {
                mEmployeeManager.UpdateData(mEmployeeItem);
                System.Windows.MessageBox.Show("Employee details succesfully updated.");
            }
            catch (Exception)
            {

                System.Windows.MessageBox.Show("Error updating employee.");
            }
            
        }

        private void Grid_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            //DisplayValues();
        }
    }
}
