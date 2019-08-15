using Fasetto.Word.Core;
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
    /// Interaction logic for Overtime.xaml
    /// </summary>
    /// 
    public partial class Overtime : Window
    {
        UserItem mitem = new UserItem();
        public Overtime(UserItem item)
        {
            InitializeComponent();
            mitem = item;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (project.Text == "" || Reasonbox.Text == "" || fromTime.Text == "" || toTime.Text == "")
            {
                MessageBox.Show("Please fill required inputs");
            }
            else
            {
                RequestItem item = new RequestItem();

                item.EMP_ID = mitem._EMPID;
                item.DATE = DateTime.Now.ToString("MM/dd/yyyy");
                item.PROJECT = project.Text;
                item.REASON = Reasonbox.Text;
                item.STATUS = "Waiting for Approval";
                item.TIME_FROM = fromTime.Text;
                item.TIME_TO = toTime.Text;

                addOT(item);
                clear();
                MessageBox.Show("Request sent!");
                this.Close();
            }

            
        }
        private void addOT(RequestItem newitem)
        {
            AddRequest myrequest = new AddRequest();
            myrequest.AddOt(newitem);
        }

        private void clear()
        {
            project.Text = "";
            Reasonbox.Text = "";
            fromTime.Text = "";
            toTime.Text = "";
        }
    }
}
