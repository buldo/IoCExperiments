namespace Common
{
    using System.Windows;

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ITestAction testAction;

        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
