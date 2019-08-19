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
    /// Interaction logic for Leave.xaml
    /// </summary>
    public partial class Leave : Window
    {
        UserItem mitem = new UserItem();
        string lastcheckcontent;
        public Leave(UserItem item)
        {
            InitializeComponent();
            mitem = item;
        }
        private void ButtonMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            if(type1.IsChecked == false && type2.IsChecked == false && type3.IsChecked == false || Reason.Text == "" || fromDate.Text == "" || toDate.Text == "")
            {
                MessageBox.Show("Please fill all required Inputs");
            }
            else
            {
                RequestItem item = new RequestItem();

                item.EMP_ID = mitem._EMPID;
                item.DATE = DateTime.Now.ToString("MM/dd/yyyy");
                item.TYPE = lastcheckcontent;
                item.REASON = Reason.Text;
                item.STATUS = "Waiting for Approval";
                item.LEAVE_START = fromDate.Text;
                item.LEAVE_END = toDate.Text;

                PendingItem pitem = new PendingItem();

                pitem.EMPID = mitem._EMPID;
                pitem.PENDING_TYPE = "Leave";
                pitem.PENDING_STATUS = "Waiting for Approval";
                pitem.PENDING_DATE = DateTime.Now.ToString("MM/dd/yyyy");
                pitem.PENDING_POSITION = mitem._POSITION;


                Addleave(item);
                addPend(pitem);
                ClearInputs();

                MessageBox.Show("Request sent!");
                this.Close();
            }

           
         
        }
        private void addPend(PendingItem newitem)
        {
            UserPending upend = new UserPending();
            upend.AddPending(newitem);
        }
        private void Addleave(RequestItem newitem)
        {
            AddRequest myrequest = new AddRequest();
            myrequest.Addleave(newitem);
        }

        private void ClearInputs()
        {
            type1.IsChecked = false;
            type2.IsChecked = false;
            type3.IsChecked = false;
            Reason.Text = "";
            fromDate.Text = "";
            toDate.Text = "";
        }


    private void Type1_Checked(object sender, RoutedEventArgs e)
        {
            type2.IsChecked = false;
            type3.IsChecked = false;
            lastcheckcontent = type1.Content.ToString();
        }

        private void Type2_Checked(object sender, RoutedEventArgs e)
        {
            type1.IsChecked = false;
            type3.IsChecked = false;
            lastcheckcontent = type2.Content.ToString();
        }

        private void Type3_Checked(object sender, RoutedEventArgs e)
        {
            type2.IsChecked = false;
            type1.IsChecked = false;
            lastcheckcontent = type3.Content.ToString();
        }
    }

}
