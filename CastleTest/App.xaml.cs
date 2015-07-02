namespace CastleTest
{
    using System.Windows;

    using Castle.MicroKernel.Registration;
    using Castle.Windsor;
    using Castle.Windsor.Installer;

    using Common;

    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private WindsorContainer _container;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            _container = new WindsorContainer();
            _container.Install(FromAssembly.This());
            _container.AddFacility<NotifierFacility>();

            _container.Register(Component.For<ITestAction>().ImplementedBy<MainRealisation>().LifestyleSingleton());
            _container.Register(Component.For<MainWindowViewModel>().LifestyleTransient());
            
            MainWindow = new MainWindow();
            MainWindow.DataContext = _container.Resolve<MainWindowViewModel>();
            MainWindow.Show();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);

            _container.Dispose();
        }
    }
}
