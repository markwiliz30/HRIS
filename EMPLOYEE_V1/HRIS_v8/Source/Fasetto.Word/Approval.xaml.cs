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
    /// Interaction logic for Approval.xaml
    /// </summary>
    
    public partial class Approval : Window
    {
        UserItem mitem = new UserItem();
        public Approval(UserItem item)
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
            StaticApprovalList.staticApprovalList.Clear();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            UserPending pitem = new UserPending();
            pitem.RetrievePending();

            approval.ItemsSource = StaticApprovalList.staticApprovalList;
            total.Content = StaticApprovalList.staticApprovalList.Count;
        }

        private void Approval_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            var main = Window.GetWindow(this);
            main.Hide();

        }
    }
