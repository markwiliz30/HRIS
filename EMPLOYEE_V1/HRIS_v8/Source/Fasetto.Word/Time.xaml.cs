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


namespace Fasetto.Word
{
    /// <summary>
    /// Interaction logic for Time.xaml
    /// </summary>
    public partial class Time : Window
    {
        public Time()
        {
            InitializeComponent();
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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
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
            HRISMainWindow mw = new HRISMainWindow();
            mw.ShowDialog();
            parentWindow2.Show();
        }
    }

}
