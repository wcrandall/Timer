using System;
using System.Windows.Input;
using System.Windows.Threading;
using Timer.Services;

namespace Timer.ViewModels
{
    public class MainViewModel:BaseViewModel
	{
		private bool _isDefaultValueOrEmpty = true;
		private bool _isStopwatch;
		private string _userInput = _textboxPlaceholder;
		private const string _textboxPlaceholder = "Enter A Time To Countdown From";
		private ITimerService _timerService;
		private IPageService _pageService; 

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
		public ICommand StartCommand { get; set; }
        public MainViewModel(ITimerService timerService, IPageService pageService)
        {
			_timerService = timerService;
			_pageService = pageService;
        }

		public void Start()
        {
			if (!_isStopwatch)
			{
				if (!_isDefaultValueOrEmpty)
				{
					_timerService.Start(Input);

				}
			}
			else
			{
				_timerService.Start(Input);
			}
			
        }

		public void Stop()
        {
			_timerService.Stop();
			if (!_isStopwatch)
			{
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
		public void Pause()
        {
			_timerService.Pause(); 
        }

		public void CheckIfInputIsNumber()
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

		public void SwitchedToStopwatch()
        {
			IsStopwatch = true;
			Stop(); 
        }
		public void SwitchedToCountdown()
        {
			IsStopwatch = false;
			Stop(); 
        }

	}
}
