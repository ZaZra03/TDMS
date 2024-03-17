using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TDMS.MVVM;

namespace TDMS.View_Model
{
    class NavigationVM : ViewModelBase
    {
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }

        public ICommand ADashBoardCommand { get; set; }
        public ICommand UDashBoardCommand { get; set; }
        public ICommand JobsCommand { get; set; }
        public ICommand MaterialsCommand { get; set; }
        public ICommand EmployeeCommand { get; set; }
        public ICommand ProfileCommand { get; set; }

        private void ADashBoard(object obj) => CurrentView = new ADashBoardVM();
        private void UDashBoard(object obj) => CurrentView = new UDashBoardVM();
        private void Jobs(object obj) => CurrentView = new JobsVM();
        private void Materials(object obj) => CurrentView = new MaterialsVM();
        private void Employee(object obj) => CurrentView = new EmployeeVM();
        private void Profile(object obj) => CurrentView = new ProfileVM();
        public NavigationVM()
        {
            ADashBoardCommand = new RelayCommand(ADashBoard);
            UDashBoardCommand = new RelayCommand(UDashBoard);
            JobsCommand = new RelayCommand(Jobs);
            MaterialsCommand = new RelayCommand(Materials);
            EmployeeCommand = new RelayCommand(Employee);
            ProfileCommand = new RelayCommand(Profile);

            CurrentView = new ADashBoardVM();
        }
    }
}
