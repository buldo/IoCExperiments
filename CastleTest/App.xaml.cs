using System.Windows;

namespace CastleTest
{
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;
    using Castle.Windsor.Installer;
    using Common;

    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private WindsorContainer container;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            container = new WindsorContainer();
            container.Install(FromAssembly.This());

            container.Register(Component.For<ITestAction>().ImplementedBy<MainRealisation>().LifestyleSingleton());
            container.Register(Component.For<MainWindowViewModel>().LifestyleTransient());
            
            MainWindow = new MainWindow();
            MainWindow.DataContext = container.Resolve<MainWindowViewModel>();
            MainWindow.Show();
        }
    }
}
