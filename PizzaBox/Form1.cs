using System;
using System.Windows.Forms;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

using PizzaBox.Providers;
using PizzaBox.Providers.HeartBeatProvider;

namespace PizzaBox
{
    public partial class Form1 : Form
    {
        private ITrayController _trayController;
        private IDisposable _subscription;
        private IProvider<bool> _provider;

        private string _title = "HeartBeat Provider";

        public Form1(ITrayController controller)
        {
            InitializeComponent();
            _trayController = controller;

            // todo: remove testing a quick provider
            _provider = new HeartBeatProvider();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            // Get a toast XML template
            XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastImageAndText04);

            // Fill in the text elements
            XmlNodeList stringElements = toastXml.GetElementsByTagName("text");
            for (int i = 0; i < stringElements.Length; i++)
            {
                stringElements[i].AppendChild(toastXml.CreateTextNode("Line " + i));
            }

            // Create the toast and attach event listeners
            ToastNotification toast = new ToastNotification(toastXml);
            toast.Activated += ToastActivated;

            // Show the toast. Be sure to specify the AppUserModelId on your application's shortcut!
            ToastNotificationManager.CreateToastNotifier("asd").Show(toast);
        }

        private void ToastActivated(ToastNotification sender, object e)
        {
            
        }



        private void checkBox_heartBeat_CheckedChanged(object sender, EventArgs e)
        {


            if(this.checkBox_heartBeat.Checked)
            {
            _subscription = _provider.Data.Subscribe(onNext: (x) => { if (x) _trayController.ShowBalloonTip(_title, "True"); else _trayController.ShowBalloonTip(_title, "False"); },
                                                     onCompleted: () => { },
                                                     onError: (x) => { });
            }
            else
            {
                _subscription.Dispose();
                _provider.EnablePolling(4000);
            }
        }
    }
}
