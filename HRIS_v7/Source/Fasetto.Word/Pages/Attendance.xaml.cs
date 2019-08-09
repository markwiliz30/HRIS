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
using System.Data.SqlClient;
using Fasetto.Word.Core;

namespace Fasetto.Word
{
    /// <summary>
    /// Interaction logic for Attendance.xaml
    /// </summary>
    public partial class Attendance : BasePage
    {
        AttendanceCollection attendanceList = new AttendanceCollection();

        public Attendance()
        {
            InitializeComponent();

            attendance.ItemsSource = attendanceList.GetAttendance();


        }

        
    }
}
