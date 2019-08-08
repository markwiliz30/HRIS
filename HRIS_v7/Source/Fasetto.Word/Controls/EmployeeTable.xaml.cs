using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using Fasetto.Word.Core;

namespace Fasetto.Word
{

    /// <summary>
    /// Interaction logic for EmployeeTable.xaml
    /// </summary>
    public partial class EmployeeTable : UserControl
    {

        EmployeeManager myManager = new EmployeeManager();
        EmployeeCollection myCollection = new EmployeeCollection();
        string selectedEmployeeId;
        ObservableCollection<EmployeeItem> observableEmpCollection = new ObservableCollection<EmployeeItem>();
        public EmployeeTable()
        {
            InitializeComponent();

            //EmployeeItem mark = new EmployeeItem();
            //mark._employeeId = "124asf";
            //mark._firstName = "Mark";
            //mark._middleName = "Sese";
            //mark._lastName = "Del Moro";
            //mark._nationality = "Filipino";
            //mark._eMail = "mark@gmail.com";
            //mark._contactNum = "0999999";
            //mark._religion = "INC";

            //EmployeeItem mark2 = new EmployeeItem();
            //mark2._employeeId = "34fgd";
            //mark2._firstName = "Mark2";
            //mark2._middleName = "Sese2";
            //mark2._lastName = "Del Moro2";
            //mark2._nationality = "Filipino2";
            //mark2._eMail = "mark@gmail.com2";
            //mark2._contactNum = "09999992";
            //mark2._religion = "INC2";

            //employeeTable.Items.Add(mark);
            //employeeTable.Items.Add(mark2);

            GetAllEmployees();

            Storyboard sb = this.FindResource("ButtonPopup") as Storyboard;
            sb.Begin();
        }

        private void ButtonViewEmployee_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            
        }

        private void GetAllEmployees()
        {
            //employeeTable.Items.Clear();

            //observableEmpCollection = EmployeeCollection.RetreiveAllEmployee();
            myCollection.RetreiveAllEmployee();

            employeeTable.ItemsSource = StaticEmpoyeeCollection.staticEmployeeList;
        }

        //private void ObservableGetAllEmployees()
        //{
        //    employeeTable.ItemsSource = observableEmployees;
        //}

        private void ButtonNewEmployee_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            EmployeeManagement.mEmpTransitioner.SelectedIndex = 1;
        }

        private void ButtonDeleteEmployee_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            DeleteEmployee();
        }

        private void DeleteEmployee()
        {
            string sMessageBoxText = "Do you want to delete this employee?";
            string sCaption = "Are you Sure?";

            MessageBoxButton btnMessageBox = MessageBoxButton.YesNo;
            MessageBoxImage icnMessageBox = MessageBoxImage.Warning;

            MessageBoxResult rsltMessageBox = System.Windows.MessageBox.Show(sMessageBoxText, sCaption, btnMessageBox, icnMessageBox);

            switch (rsltMessageBox)
            {
                case MessageBoxResult.Yes:
                    myManager.DeleteData(selectedEmployeeId);
                    myCollection.RetreiveAllEmployee();
                    break;

                case MessageBoxResult.No:
                    break;
            }
        }

        private void AddToObservable()
        {
            EmployeeItem mark2 = new EmployeeItem();
            mark2._employeeId = "34fgd";
            mark2._firstName = "Mark2";
            mark2._middleName = "Sese2";
            mark2._lastName = "Del Moro2";
            mark2._nationality = "Filipino2";
            mark2._eMail = "mark@gmail.com2";
            mark2._contactNum = "09999992";
            mark2._religion = "INC2";
            mark2._presentAddress = "mt.veiw";
            mark2._permanentAddress = "Gatiawin";

            StaticEmpoyeeCollection.staticEmployeeList.Add(mark2);
        }

        private void Row_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            object item = employeeTable.SelectedItem;
            selectedEmployeeId = (employeeTable.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
        }

        private void ButtonEditEmployee_Click(object sender, RoutedEventArgs e)
        {
            EditEmployeeDetails.SetValues(selectedEmployeeId);
            EmployeeManagement.mEmpTransitioner.SelectedIndex = 2;
            
        }
    }
}
