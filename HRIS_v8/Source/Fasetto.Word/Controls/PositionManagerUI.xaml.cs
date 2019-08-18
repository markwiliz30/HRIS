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
    }
}
