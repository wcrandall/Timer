using System;

namespace Timer.Services
{
    class Countdown:TimerService
    {
        private int _numberCountingDownFrom;
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
        public override void Start(int currentNumber)
        {
            if(!_isRunning)
            {
                _numberCountingDownFrom = currentNumber;
            }
            if (_numberCountingDownFrom > 0)
            {
                base.Start(currentNumber);
            }

        }
        public override void Stop()
        {
            OnTimerTick(_numberCountingDownFrom); 
            base.Stop();
        }
    }
}
