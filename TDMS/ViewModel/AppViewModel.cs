using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TDMS.ViewModel
{
    public class AppViewModel : INotifyPropertyChanged
    {
        private ICommand _hidePanelCommand;
        private bool _isPanelVisible;
        private ICommand _showPanelCommand;

        public AppViewModel()
        {
            // Set Default Panel Visibility //
            IsPanelVisible = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        // Panel Visibility Property //
        public bool IsPanelVisible
        {
            get => _isPanelVisible;
            set
            {
                _isPanelVisible = value;
                OnPropertyChanged("IsPanelVisible");
            }
        }

        // Show Panel Method //
        public void ShowPanel()
        {
            IsPanelVisible = true;
        }

        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
