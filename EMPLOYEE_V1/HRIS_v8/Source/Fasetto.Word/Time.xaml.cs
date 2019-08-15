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
using System.Windows.Shapes;
using Fasetto.Word.Core;

namespace Fasetto.Word
{
    /// <summary>
    /// Interaction logic for Time.xaml
    /// </summary>
    public partial class Time : Window
    {
        UserItem mitem = new UserItem();
        UserTime utime = new UserTime();
        public Time(UserItem item)
        {
            InitializeComponent();
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();

            mitem = item;
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            timekeep.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }
        private void ButtonMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var desktopWorkingArea = System.Windows.SystemParameters.WorkArea;
            this.Left = desktopWorkingArea.Right - this.Width;
            this.Top = desktopWorkingArea.Bottom - this.Height;
            buttonProfile.Content = mitem._FNAME;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var now = DateTime.Now.ToString("MM/dd/yyyyy");
            var check = utime.Checker(mitem._EMPID, now);

            if(check!= null)
            {

            }
            btn_time_in.IsEnabled = false;
            btn_time_out.IsEnabled = true;
        }

        private void Btn_time_out_Click(object sender, RoutedEventArgs e)
        {
            btn_time_in.IsEnabled = true;
            btn_time_out.IsEnabled = false;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            var parentWindow2 = Window.GetWindow(this);

            parentWindow2.Hide();
            HRISMainWindow mw = new HRISMainWindow(mitem);
            mw.ShowDialog();
            parentWindow2.Show();
        }


    }

}
