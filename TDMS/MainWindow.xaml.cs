using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TDMS.DAL;
using TDMS.View_Model;

namespace TDMS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void SignIn(string email, string password)
        {
            MySQLDB db = new MySQLDB();
            string accountType = db.CheckAccount(email, password);

            if (accountType == "admin" || accountType == "user")
            {
                // Admin or user account found, show Window1
                Window1 objWindow = new Window1(accountType);
                objWindow.Show();

                // Close the current window
                this.Close();
            }
            else
            {
                // No account found
                MessageBox.Show("No account found.", "Message Box Title", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            string email = EmailTextBox.Text;
            string password = PasswordTextBox.Password;

            if (!string.IsNullOrWhiteSpace(email) && !string.IsNullOrWhiteSpace(password))
            {
                SignIn(email, password);
            }
            else
            {
                // Handle empty email or password
                MessageBox.Show("Please enter both email and password.", "Message Box Title", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Border_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(PasswordTextBox.Password) && PasswordTextBox.Password.Length > 0)
                textPassword.Visibility = Visibility.Collapsed;
            else
                textPassword.Visibility = Visibility.Visible;
        }

        private void TextPassword_MouseDown(object sender, MouseButtonEventArgs e)
        {
            PasswordTextBox.Focus();
        }

        private void TxtEmail_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(EmailTextBox.Text) && EmailTextBox.Text.Length > 0)
                textEmail.Visibility = Visibility.Collapsed;
            else
                textEmail.Visibility = Visibility.Visible;
        }

        private void TextEmail_MouseDown(object sender, MouseButtonEventArgs e)
        {
            EmailTextBox.Focus();
        }

    }
}