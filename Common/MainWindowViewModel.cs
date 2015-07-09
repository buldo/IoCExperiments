using System.Linq;

namespace Common
{
    using System;
    using System.Windows.Input;

    using Notifiers;
    using Differents;

    public class MainWindowViewModel : AbstractNotify, INotifierClient
    {
        #region # Fields #

        private readonly ITestAction _testAction;
        private readonly IUserOfDifferentCollection _userOfDifferents;

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

        #region = IUserOfDifferentCollection =

        public IUserOfDifferentCollection UserOfDifferentsCollection { get; set; }

        public string Differents
        {
            get
            {
                return UserOfDifferentsCollection != null && UserOfDifferentsCollection.Users.Length > 0
                    ? string.Join(",", UserOfDifferentsCollection.Users.Select(a => a.WhoAmi))
                    : "** Empty Collection :( **";
            }
        }

        #endregion // = IUserOfDifferentCollection =

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
