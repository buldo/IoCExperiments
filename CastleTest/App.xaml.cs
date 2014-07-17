using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CastleTest
{
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;

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
            container.Register(Classes.FromAssemblyNamed("Common").Where())
            container.RegisterInstance(typeof(ITestAction), new MainRealisation());

            MainWindow = new MainWindow();
            MainWindow.DataContext = new MainWindowViewModel(container.Resolve<ITestAction>());
            MainWindow.Show();

            container.RegisterInstance(typeof(MainWindowViewModel));
        }
    }
}
