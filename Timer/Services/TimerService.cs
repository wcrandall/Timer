using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Timer.Services
{
    public class TimerService : ITimerService
    {
        public event EventHandler<int> TimerTick;
        protected DispatcherTimer _dispatcherTimer = new DispatcherTimer();
        protected bool _isRunning;
        protected int _currentNumber = 0;
        public TimerService()
        {
            _dispatcherTimer.Tick += new EventHandler(DispatcherTimer_Tick);
            _dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
        }
        protected virtual void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void OnTimerTick(int numberMovingBy)
        {
            TimerTick?.Invoke(this, numberMovingBy); 
        }

        public void Pause()
        {
            if (_isRunning)
            {
                _dispatcherTimer.IsEnabled = false;

            }
        }

        public void Start(int currentNumber)
        {
            _currentNumber = currentNumber; 
            _dispatcherTimer.Start();
            _isRunning = true; 
        }

        public void Stop()
        {
            _dispatcherTimer.Stop();
            _isRunning = false; 
        }
    }
}
