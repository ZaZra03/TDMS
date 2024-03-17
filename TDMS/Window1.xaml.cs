using System.Windows;

namespace TDMS
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void MenuOut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow objWindow = new();
            this.Close();
            objWindow.Show();
        }
    }
}
