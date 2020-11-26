using System;
using System.Windows.Input;
using System.Windows.Threading;
using Timer.Commands;
using Timer.Services;

namespace Timer.ViewModels
{
	public class MainViewModel : BaseViewModel
	{
		private bool _isDefaultValueOrEmpty = true;
		private bool _isStopwatch;
		private string _userInput = _textboxPlaceholder;
		private const string _textboxPlaceholder = "Enter A Time To Countdown From";
		private ITimerService TimerService;
		private IPageService _pageService;
		public ICommand StartCommand { get; private set; }
		public ICommand StopCommand { get; private set; }
		public ICommand PauseCommand { get; private set; }
		public ICommand CheckUserInputCommand { get; private set; }
		private bool _isRunning; 
		public bool IsRunning
        {
            get
            {
				return _isRunning;
            }
            set
            {
				_isRunning = value;
				OnPropertyChanged();
            }
        }

		public string UserInput
		{
			get
			{
				return _userInput;
			}
			set
			{
				_userInput = value;
				OnPropertyChanged();
			}
		}
		public bool IsStopwatch
		{
			get
			{
				return _isStopwatch;
			}
			set
			{
				_isStopwatch = value;
				OnPropertyChanged();
				SelectionChanged();
			}
		}
		private int _input = 0;
		public int Input
		{
			get
			{
				return _input;
			}
			set
			{
				_input = value;
				OnPropertyChanged();
			}
		}
        public MainViewModel(ITimerService timerService, IPageService pageService)
        {
			StartCommand = new RelayCommand(Start);
			StopCommand= new RelayCommand(Stop);
			PauseCommand = new RelayCommand(Pause);
			CheckUserInputCommand = new RelayCommand(CheckIfInputIsNumber); 
			TimerService = timerService;
			SubscribeTimer(); 
			_pageService = pageService;
			IsStopwatch = false;
        }

		private void UnsubscribeTimer()
        {
			TimerService.TimerTick -= TimerTick; 
        }
		private void SubscribeTimer()
        {
			TimerService.TimerTick += TimerTick;
		}
		private void TimerTick(object source, int value)
        {
			Input = value;
        }

		private void SelectionChanged()
        {
			Stop();
			UnsubscribeTimer();
			if(IsStopwatch)
            {
				TimerService = new Stopwatch();
            }
            else
            {
				TimerService = new Countdown();
            }
			SubscribeTimer(); 
        }

		private void Start()
        {
			
			if (!_isStopwatch)
			{
				if (!_isDefaultValueOrEmpty)
				{
					TimerService.Start(Input);
					IsRunning = true;
				}
			}
			else
			{
				TimerService.Start(Input);
			}
			
        }

		private void Stop()
        {
			TimerService.Stop();
			if (!_isStopwatch)
			{
				IsRunning = false;
				if (Int32.TryParse(UserInput, out int result))
				{
					Input = result;
				}
				else
				{
					Input = 0;
				}
			}
			else
			{
				Input = 0;
			}
		}
		private void Pause()
        {

			TimerService.Pause(); 
        }

		private void CheckIfInputIsNumber()
        {

			//removing spaces on right and left sides
			UserInput = UserInput.Trim();

			if (Int32.TryParse(UserInput, out int result))
			{
				if (result < 1)
				{
					_pageService.Message("Please enter a number between 1 and " + Int32.MaxValue.ToString());
					UserInput = "";
					_isDefaultValueOrEmpty = true;
				}
				else
				{
					_isDefaultValueOrEmpty = false;
					UserInput = result.ToString();
					Input = result;

				}
			}
			else
			{
				if (UserInput != "" && UserInput != _textboxPlaceholder)
				{
					_pageService.Message("Please enter a number between 1 and " + Int32.MaxValue.ToString());
					UserInput = "";
					_isDefaultValueOrEmpty = true;
				}

			}

		}



	}
}
