using System.Windows;
using System.Windows.Controls;
using Fasetto.Word.Core;
using System.Collections.Generic;
using System.Collections.ObjectModel;

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
            EmployeeItem mark2 = new EmployeeItem();
            mark2._employeeId = "34fgd0";
            mark2._firstName = "Mark20";
            mark2._middleName = "Sese20";
            mark2._lastName = "Del Moro20";
            mark2._nationality = "Filipino20";
            mark2._eMail = "mark@gmail.com20";
            mark2._contactNum = "099999920";
            mark2._religion = "INC20";
            mark2._presentAddress = "mt.veiw0";
            mark2._permanentAddress = "Gatiawin0";

            StaticEmpoyeeCollection.staticEmployeeList.Add(mark2);
        }
    }
}
