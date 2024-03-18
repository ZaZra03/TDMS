using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using TDMS.DAL;
using TDMS.MVVM;
using TDMS;

namespace TDMS.View_Model;
public class MainWindowVM : ViewModelBase
{
    private string _email;
    public string Email
    {
        get { return _email; }
        set
        {
            _email = value;
            OnPropertyChanged(nameof(Email));
        }
    }

    private string _password;
    public string Password
    {
        get { return _password; }
        set
        {
            _password = value;
            OnPropertyChanged(nameof(Password));
        }
    }

    public ICommand SignInCommand { get; }

    public MainWindowVM()
    {
        SignInCommand = new RelayCommand(execute => SignIn(), canExecute => CanSignIn());
    }

    private bool CanSignIn()
    {
        return !string.IsNullOrWhiteSpace(Email) && !string.IsNullOrWhiteSpace(Password);
    }

    private void SignIn()
    {
        MySQLDB db = new();
        string accountType = db.CheckAccount(Email, Password);

        if (accountType == "admin")
        {
            // Admin account found, show Window1
            Window1 objWindow = new();
            objWindow.Show();
            // Close the current window
            App.Current.MainWindow.Close();
        }
        else if (accountType == "user")
        {
            // User account found, show Window2
            // Implement as needed
        }
        else
        {
            // No account found
            MessageBox.Show("No account found.", "Message Box Title", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
