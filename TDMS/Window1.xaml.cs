using System.Windows;
using TDMS.View_Model;

namespace TDMS
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1(string accountType)
        {
            InitializeComponent();
            DataContext = new NavigationVM(accountType, this);
        }

        private void MenuOut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow objWindow = new();
            this.Close();
            objWindow.Show();
        }
    }
}
