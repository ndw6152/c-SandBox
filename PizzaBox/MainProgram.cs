using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autofac;

namespace PizzaBox
{
    static class MainProgram
    {
        private static IContainer Container { get; set; }

        /// <summary>
        /// Autofac initilization
        /// Dependency Inversion tutorial
        /// https://www.codeproject.com/Articles/495019/Dependency-Inversion-Principle-and-the-Dependency
        /// </summary>
        private static void Initialize()
        {
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyModules();

            builder.RegisterType<PizzaBoxManager>().As<IPizzaManager>();
            builder.RegisterType<TrayIconController>().As<ITrayController>();

            Container = builder.Build();

            // http://www.tutorialspanel.com/create-system-tray-icon-windows-forms-application-using-c-vb-net/
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
        }

        public static void OpenTheShop()
        {
            var manager = Container.Resolve<IPizzaManager>();
            manager.OpenShop();
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Initialize();
            OpenTheShop();        
        }
    }
}
