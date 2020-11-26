using System;

namespace Timer.Services
{
    public interface ITimerService
    {
        void Start(int currentNumber);
        void Stop();
        void Pause();
        event EventHandler<int> TimerTick;
        bool IsRunning();
        void OnTimerTick(int numberMovingBy); 
    }
}
