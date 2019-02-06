using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace PizzaBox.Providers.HeartBeatProvider
{
    public class HeartBeatProvider : IProvider<bool>
    {
        private ProviderSubject<bool> _subject;
        private Timer _timer;
        private bool _value = true;

        public HeartBeatProvider()
        {
            _subject = new ProviderSubject<bool>();

            _timer = new Timer();
            _timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            _timer.Interval = 2000;
            _timer.Enabled = true;
        }

        public IObservable<bool> Data => _subject;

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            _value = !_value;
            _subject.OnNext(_value);
        }

        public bool EnablePolling(int rate)
        {
            _timer.Interval = rate;
            return true;
        }
    }
}
