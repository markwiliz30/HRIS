using System.Windows;
using System.Windows.Controls;
using Fasetto.Word.Core;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System;

namespace Fasetto.Word
{
    /// <summary>
    /// Interaction logic for AddEmployee.xaml
    /// </summary>
    public partial class AddEmployee : UserControl
    {
        public AddEmployee()
        {
            InitializeComponent();
            
            registerDatePicker.SelectedDate = DateTime.Today;
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            EmployeeItem item = new EmployeeItem();

            item._employeeId = tbEmployeeId.Text;
            item._firstName = tbFirstName.Text;
            item._middleName = tbMiddleName.Text;
            item._lastName = tbLastName.Text;
            item._nationality = tbNationality.Text;
            item._eMail = tbEmail.Text;
            item._contactNum = tbContactNumber.Text;
            item._religion = tbReligion.Text;
            item._presentAddress = tbPresentAddress.Text;
            item._permanentAddress = tbPermanentAddress.Text;

            try
            {
                SaveEmpoyeeDetails(item);
                MessageBox.Show("New Employee added.");
            }
            catch (System.Exception)
            {
                MessageBox.Show("Error saving new employee.");
            }

            EmployeeCollection myEmpList = new EmployeeCollection();
            myEmpList.RetreiveAllEmployee();

            EmployeeManagement.mEmpTransitioner.SelectedIndex = 0;

            ClearInputFields();

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
        }
    }
}
