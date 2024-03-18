using System.Windows;
using System.Windows.Input;
using TDMS.MVVM;
using TDMS.View;

namespace TDMS.View_Model
{
    public class NavigationVM : ViewModelBase
    {
        private object? _navView;
        public object? NavView
        {
            get { return _navView; }
            set { _navView = value; OnPropertyChanged(); }
        }

        private object? _currentView;
        public object? CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }

        private readonly Window1 _window;
        public object? Window
        {
            get { return _window; }
        }

        public ICommand ADashBoardCommand { get; set; }
        public ICommand UDashBoardCommand { get; set; }
        public ICommand JobsCommand { get; set; }
        public ICommand MaterialsCommand { get; set; }
        public ICommand EmployeeCommand { get; set; }
        public ICommand ProfileCommand { get; set; }
        public ICommand TimeCommand { get; set; }
        public RelayCommand SignOutCommand => new(_ => SignOut());

        private void SignOut()
        {
            // Your sign out logic here
            
            MainWindow objWindow = new();
            _window.Close();
            objWindow.Show();

        }



        private void ADashBoard(object obj) => CurrentView = new ADashBoardVM();
        private void Jobs(object obj) => CurrentView = new JobsVM();
        private void Materials(object obj) => CurrentView = new MaterialsVM();
        private void Employee(object obj) => CurrentView = new EmployeeVM();
        private void Time(object obj) => CurrentView = new TimeVM();
        private void Profile(object obj) => CurrentView = new ProfileVM();
        private void UDashBoard(object obj) => CurrentView = new UDashBoardVM();

        public NavigationVM(string AccountType, Window1 window)
        {
            _window = window;
            ADashBoardCommand = new RelayCommand(ADashBoard);
            JobsCommand = new RelayCommand(Jobs);
            MaterialsCommand = new RelayCommand(Materials);
            EmployeeCommand = new RelayCommand(Employee);
            TimeCommand = new RelayCommand(Time);
            ProfileCommand = new RelayCommand(Profile);
            UDashBoardCommand = new RelayCommand(UDashBoard);

            if (AccountType == "admin")
            {
                CurrentView = new ADashBoardVM();
                NavView = new ANavigation();
            }
            else if (AccountType == "user")
            {
                CurrentView = new UDashBoardVM();
                NavView = new UNavigation();

            }

            //CurrentView = new ADashBoardVM();
        }
    }
}
