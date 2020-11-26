using System;

namespace Timer.Services
{
    public class Stopwatch : TimerService
    {
        protected override void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            _currentNumber++;
            OnTimerTick(_currentNumber); 
        }
        public override void Stop()
        {
            OnTimerTick(0);
            base.Stop();
        }
    }
}
