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
    public class PizzaBoxManager : ApplicationContext
    {
        private static PizzaBoxManager instance = null;



        private PizzaBoxManager()
        {
            // http://www.tutorialspanel.com/create-system-tray-icon-windows-forms-application-using-c-vb-net/
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
        }

        private TrayIconController TrayIconController { get; set; }
        public static PizzaBoxManager GetInstance() { 
            if(instance == null)
                return new PizzaBoxManager();
            return instance;
        }



        public void Start()
        {
            TrayIconController = new TrayIconController();
            Application.Run();
        }
    }
}
