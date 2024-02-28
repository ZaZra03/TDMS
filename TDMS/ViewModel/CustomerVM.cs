using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDMS.Model;

namespace TDMS.ViewModel
{
    internal class CustomerVM : Utiel.ViewModelBase
    {
        private readonly PageModel _pageModel;

        public CustomerVM()
        {
            _pageModel = new PageModel();
            CustomerID = 100528;
        }

        public int CustomerID
        {
            get
            {
                return _pageModel.CustomerCount;
            }

            set
            {
                _pageModel.CustomerCount = value;
                OnPropertyChanged();
            }
        }
    }
}
