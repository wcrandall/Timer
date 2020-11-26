using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timer.Services
{
    class Countdown:TimerService
    {
        protected override void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            _currentNumber--;
            OnTimerTick(_currentNumber);
            if (_currentNumber <= 0)
            {
                _isRunning = false;
                _dispatcherTimer.Stop();
            }

        }
    }
}
