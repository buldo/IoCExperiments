using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    using System.ComponentModel;
    using System.Windows.Input;

    using Common;

    

    public class MainWindowViewModel : AbstractNotify
    {
        private ITestAction _testAction;

        private int r;

        public MainWindowViewModel(ITestAction testAction)
        {
            _testAction = testAction;
            CalculateCommand = new RelayCommand(CalcalateCommandEx);
        }

        public int A { get; set; }

        public int B { get; set; }

        public int R
        {
            get
            {
                return r;
            }
            set
            {
                r = value;
                OnPropertyChanged(() => R);
            }
        }

        public ICommand CalculateCommand { get; set; }

        private void CalcalateCommandEx(object parameter)
        {
            R = _testAction.MakeAction(A, B);
        }

    }
}
