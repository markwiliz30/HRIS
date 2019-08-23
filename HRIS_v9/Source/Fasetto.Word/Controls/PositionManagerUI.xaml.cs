using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Fasetto.Word.Core;

namespace Fasetto.Word
{
    /// <summary>
    /// Interaction logic for PositionManagerUI.xaml
    /// </summary>
    public partial class PositionManagerUI : UserControl
    {
        public PositionManagerUI()
        {
            InitializeComponent();

            GetAllPositions();
        }

        private void GetAllPositions()
        {
            positionTable.ItemsSource = StaticPositionCollection.staticPositionList;
        }

        private void ButtonBack_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            EmployeeManagement.mEmpTransitioner.SelectedIndex = 0;
            EmployeeManagement.mEmpTransitioner.Items.RemoveAt(1);
        }

        private bool posValidation()
        {
            if (string.IsNullOrEmpty(tbJobTitle.Text))
            {
                MessageBox.Show("Please input job title.");
                return false;
            }
            else if (string.IsNullOrEmpty(tbDepartment.Text))
            {
                MessageBox.Show("Please input job department.");
                return false;
            }
            else if (!isNewJobTitleUnique(tbJobTitle.Text))
            {
                MessageBox.Show("Job title already existed.");
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool isNewJobTitleUnique(string designation)
        {
            var tempPosList = StaticPositionCollection.staticPositionList.Where(t => t._POS_NAME.ToLower().Equals(designation.ToLower()));

            if (tempPosList.Count() != 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void BtnSave_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (posValidation())
            {
                DesignationItem item = new DesignationItem();

                item._POS_NAME = tbJobTitle.Text;
                item._POS_DEPARTMENT = tbDepartment.Text;

                try
                {
                    SaveDesignationDetails(item);
                    ClearInputFields();
                    MessageBox.Show("New Position added.");
                }
                catch (System.Exception)
                {
                    MessageBox.Show("Error saving new employee.");
                }

                PositionCollection myPosList = new PositionCollection();
                myPosList.RetreiveAllPositions();
            }
        }

        private void SaveDesignationDetails(DesignationItem myItem)
        {
            PositionManager myManager = new PositionManager();
            myManager.SaveDesignation(myItem);
        }

        private void ClearInputFields()
        {
            tbJobTitle.Text = "";
            tbDepartment.Text = "";
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            ClearInputFields();
        }

        private void Row_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }
    }
}
