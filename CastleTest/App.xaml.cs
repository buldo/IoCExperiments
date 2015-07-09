namespace CastleTest
{
    using System.Windows;

    using Castle.MicroKernel;
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;
    using Castle.Windsor.Installer;

    using Common;
    using Common.Differents;

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

            _container.Register(Component
                .For<ITestAction>()
                .ImplementedBy<MainRealisation>()
                .LifestyleSingleton());

            _container.Register(Component
                .For<MainWindowViewModel>()
                .PropertiesRequire(a => a.PropertyType == typeof (IUserOfDifferentCollection))
                .LifestyleTransient());

            _container.Register(Component.For<IDifferent>().ImplementedBy<DifferentUniversal>());
            _container.Register(Component.For<Different1>());
            _container.Register(Component.For<Different2>());
            
            _container.Register(Component
                .For<UserOfDifferent1>()
                .DependsOn(Dependency.OnComponent<IDifferent, Different1>()));
            _container.Register(Component
                .For<UserOfDifferent2>()
                .DependsOn(Dependency.OnComponent<IDifferent, Different2>()));
            _container.Register(Component
                .For<UserOfDifferent3>());

            _container.Register(Component
                .For<IUserOfDifferentCollection>()
                .UsingFactoryMethod(kernel => new UserOfUserOfDifferentCollection(
                    kernel.Resolve<UserOfDifferent1>(),
                    kernel.Resolve<UserOfDifferent2>(),
                    kernel.Resolve<UserOfDifferent3>()
                    )));
            
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
