using System;
using System.Windows.Threading;

namespace Timer.Services
{
    public interface ITimerService
    {
        void Start(int currentNumber);
        void Stop();
        void Pause();
        event EventHandler<int> TimerTick;
        void OnTimerTick(int numberMovingBy); 
    }
}
