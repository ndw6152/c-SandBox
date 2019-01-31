using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PizzaBox
{
    /// <summary>
    /// Controller class
    /// </summary>
    public class PizzaBoxManager : IPizzaManager
    {
        private ITrayController _trayController;

        public  PizzaBoxManager(ITrayController trayController)
        {
            _trayController = trayController;
        }

        private TrayIconController TrayIconController { get; set; }
 
        public void OpenShop()
        {
            Application.Run();
        }
    }
}
