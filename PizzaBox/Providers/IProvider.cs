using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBox.Providers
{
    interface IProvider<T>
    {
        IObservable<T> Data { get; }

        bool EnablePolling(int rate);
    }
}
