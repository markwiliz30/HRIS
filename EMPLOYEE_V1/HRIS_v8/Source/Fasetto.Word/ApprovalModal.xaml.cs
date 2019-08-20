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
    /// Interaction logic for ApprovalModal.xaml
    /// </summary>
    public partial class ApprovalModal : Window
    {
        int idholder;
        string typeholder;
        UserItem mitem = new UserItem();
        public ApprovalModal(UserItem item,int id , string type)
        {
            InitializeComponent();
            mitem = item;
            idholder = id;
            typeholder = type;
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
            
            if (typeholder == "Leave")
            {

                UserPending upend = new UserPending();
                upend.SpecificPendingLeave(idholder, typeholder);





                empname.Text = StaticApprovalItem.staticApprovalModalItem.PENDING_NAME;
                emptype.Text = StaticApprovalItem.staticApprovalModalItem.PENDING_TYPE;
                from.Text = StaticApprovalItem.staticApprovalModalItem.PENDING_LEAVE_FROM;
                to.Text = StaticApprovalItem.staticApprovalModalItem.PENDING_LEAVE_TO;
                Reason.Text = StaticApprovalItem.staticApprovalModalItem.PENDING_LEAVE_REASON;

            }
            else
            {

                UserPending upend = new UserPending();
                upend.SpecificPendingOT(idholder, typeholder);



                empname.Text = StaticApprovalItem.staticApprovalModalItem.PENDING_NAME;
                emptype.Text = StaticApprovalItem.staticApprovalModalItem.PENDING_TYPE;
                from.Text = StaticApprovalItem.staticApprovalModalItem.PENDING_OT_FROM;
                to.Text = StaticApprovalItem.staticApprovalModalItem.PENDING_OT_TO;
                Reason.Text = StaticApprovalItem.staticApprovalModalItem.PENDING_OT_REASON;

            }




        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UserPending upend = new UserPending();
            string stat = "Approved by Head";
            int empid = StaticApprovalItem.staticApprovalModalItem.EMPID;
            string type = StaticApprovalItem.staticApprovalModalItem.PENDING_TYPE;
            string sdate = StaticApprovalItem.staticApprovalModalItem.PENDING_DATE;
            upend.Approve(stat, mitem._FNAME, empid,type,sdate,Reason.Text);
            MessageBox.Show("Approved!");
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            UserPending upend = new UserPending();
            string stat = "Declined by Head";
            string type = StaticApprovalItem.staticApprovalModalItem.PENDING_TYPE;
            string sdate = StaticApprovalItem.staticApprovalModalItem.PENDING_DATE;
            int empid = StaticApprovalItem.staticApprovalModalItem.EMPID;
            upend.Approve(stat, mitem._FNAME, empid,type,sdate,Reason.Text);
            MessageBox.Show("Declined!");
            this.Close();
        }
    }
}
