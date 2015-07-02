namespace Common
{
    using System;
    using System.Windows.Input;

    public class MainWindowViewModel : AbstractNotify, INotifierClient
    {
        #region # Fields #

        private readonly ITestAction _testAction;

        private int _r; 

        #endregion // # Fields #

        #region # Properties #

        #region = Base =

        public int A { get; set; }

        public int B { get; set; }

        public int R
        {
            get
            {
                return _r;
            }
            set
            {
                _r = value;
                OnPropertyChanged(() => R);
            }
        }

        public string NotifyMessage { get; set; }

        #endregion // = Base =

        #region = INotifierClient =

        public string NotifierName { get; set; }

        public INotifier Notifier { get; set; }

        #endregion // = INotifierClient =

        #region = Commands =

        public ICommand CalculateCommand { get; set; }

        public ICommand NotifyCommand { get; set; } 

        #endregion // = Commands =

        #endregion // # Properties #
        
        public MainWindowViewModel(ITestAction testAction)
        {
            _testAction = testAction;
            CalculateCommand = new RelayCommand(CalculateCommandEx);
            NotifyCommand = new RelayCommand(NotifyCommandEx);
            NotifierName = string.Format("FooBar {0}", new Random().Next());
            NotifyMessage = "Hello, world!!!";
        }

        #region # Methods #

        private void CalculateCommandEx(object parameter)
        {
            R = _testAction.MakeAction(A, B);
        }

        private void NotifyCommandEx(object parameter)
        {
            Notifier.Notify(NotifyMessage);
        }

        #endregion // # Methods #
    }
}
