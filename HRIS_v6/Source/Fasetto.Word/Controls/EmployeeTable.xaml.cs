using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Fasetto.Word.Core;

namespace Fasetto.Word
{
    /// <summary>
    /// Interaction logic for EmployeeTable.xaml
    /// </summary>
    public partial class EmployeeTable : UserControl
    {
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
        }

        private void ButtonViewEmployee_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            GetAllEmployees();
        }

        private void GetAllEmployees()
        {
            //employeeTable.Items.Clear();

            //observableEmpCollection = EmployeeCollection.RetreiveAllEmployee();
            EmployeeCollection myCollection = new EmployeeCollection();
            myCollection.RetreiveAllEmployee();

            employeeTable.ItemsSource = StaticEmpoyeeCollection.staticEmployeeList;
        }

        //private void ObservableGetAllEmployees()
        //{
        //    employeeTable.ItemsSource = observableEmployees;
        //}

        private void ButtonNewEmployee_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void ButtonDeleteEmployee_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            AddToObservable();
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
            MessageBox.Show(selectedEmployeeId);
        }
    }
}
