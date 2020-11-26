using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Timer.Services
{
    public class Stopwatch : TimerService
    {
        protected override void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            _currentNumber++;
            OnTimerTick(_currentNumber); 
        }
    }
}
