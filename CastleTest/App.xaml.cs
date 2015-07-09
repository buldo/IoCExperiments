namespace CastleTest
{
    using System.Windows;

    using Castle.MicroKernel.Registration;
    using Castle.Windsor;
    using Castle.Windsor.Installer;
    using Castle.Facilities.TypedFactory;
    using Castle.MicroKernel;

    using Common;
    using Common.Config;
    using Common.ChildTest;
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
            _container.AddFacility<TypedFactoryFacility>();

            _container.Register(Component
                .For<ITestAction>()
                .ImplementedBy<MainRealisation>()
                .LifestyleSingleton());

            _container.Register(Component
                .For<MainWindowViewModel>()
                .PropertiesRequire(a => 
                    a.PropertyType == typeof (IUserOfDifferentCollection) ||
                    a.PropertyType == typeof (IParentSystem))
                .LifestyleTransient());

            _container.Register(Component
                .For<IDifferent>()                
                .ImplementedBy<DifferentUniversal>());

            _container.Register(Classes
                .FromAssemblyContaining<IDifferent>()
                .BasedOn<IDifferent>());

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

            _container.Register(Component.For<ParentConfig>());
            _container.Register(Component.For<ChildConfig>());

            _container.Register(Component
                .For<IChildSystem>()
                .ImplementedBy<ChildSystem>()
                .LifestyleTransient());

            _container.Register(Component
                .For<IParentSystem>()
                .OnCreate((kernel, item) =>
                    item.ChildSystem = kernel.Resolve<IChildSystem>(new
                    {
                        System = item,
                        Config = ((ParentSystem)item).ChildConfig
                    }))
                .DependsOn(Dependency.OnValue<ParentConfig>(new ParentConfig("test")))
                .ImplementedBy<ParentSystem>()
                .LifestyleTransient());            

            _container.Register(Component
                .For<UserOfConfig>()
                .LifestyleTransient());
            _container.Register(Component
                .For<IConfigurableFactory>()
                .AsFactory());

            _container.Register(Component
                .For<MainWindow>()
                .OnCreate((k, i) => i.DataContext = k.Resolve<MainWindowViewModel>()));

            _container.Resolve<MainWindow>().Show();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);

            _container.Dispose();
        }
    }
}
