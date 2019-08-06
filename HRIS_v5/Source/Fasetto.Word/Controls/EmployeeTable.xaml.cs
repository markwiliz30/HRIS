using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Fasetto.Word
{
    /// <summary>
    /// Interaction logic for EmployeeTable.xaml
    /// </summary>
    public partial class EmployeeTable : UserControl
    {
        public EmployeeTable()
        {
            InitializeComponent();

            Employee mark = new Employee();
            mark._employeeId = "124asf";
            mark._firstName = "Mark";
            mark._middleName = "Sese";
            mark._lastName = "Del Moro";
            mark._nationality = "Filipino";
            mark._eMail = "mark@gmail.com";
            mark._contactNum = 0999999;
            mark._religion = "INC";

            Employee mark2 = new Employee();
            mark2._employeeId = "34fgd";
            mark2._firstName = "Mark2";
            mark2._middleName = "Sese2";
            mark2._lastName = "Del Moro2";
            mark2._nationality = "Filipino2";
            mark2._eMail = "mark@gmail.com2";
            mark2._contactNum = 09999992;
            mark2._religion = "INC2";

            employeeTable.Items.Add(mark);
            employeeTable.Items.Add(mark2);
        }

        public class Employee
        {
            public string _employeeId { get; set; }
            public string _firstName { get; set; }
            public string _middleName { get; set; }
            public string _lastName { get; set; }
            public string _nationality { get; set; }
            public string _eMail { get; set; }
            public int _contactNum { get; set; }
            public string _religion { get; set; }
        }
    }
}
