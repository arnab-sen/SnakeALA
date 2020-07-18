using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using Libraries;
using ProgrammingParadigms;

namespace DomainAbstractions
{
    public class Timer : IEvent
    {
        // Public fields and properties
        public string InstanceName = "Default";

        public double Interval
        {
            get => timer.Interval.TotalSeconds;
            set => timer.Interval = TimeSpan.FromSeconds(value);
        }

        // Private fields
        private DispatcherTimer timer = new DispatcherTimer();
        private bool started = false;

        // Ports
        private IEvent tickHappened;

        public Timer()
        {
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += (sender, args) => tickHappened?.Execute();
        }

        // IEvent implementation
        void IEvent.Execute()
        {
            if (!started)
            {
                timer.Start();
            }
            else
            {
                started = false;

                timer.Stop();
            }

        }
    }
}
