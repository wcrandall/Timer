using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Timer
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window, INotifyPropertyChanged
	{
		private DispatcherTimer _dispatcherTimer = new DispatcherTimer();
		private bool _isRunning = false;
		private bool _isDefaultValueOrEmpty = true;
		private bool _isStopwatch = false; 
		public bool IsRunning
		{
			get
			{
				return _isRunning; 
			}
			set
			{
				_isRunning = value;
				OnPropertyChanged("IsRunning"); 
			}
		}
		private int _input = 0;
		public int Input {
			get 
			{
				return _input; 
			}
			set
			{
				_input = value;
				OnPropertyChanged("Input"); 
			}
		}
		private const string  _textboxPlaceholder = "Enter A Time To Countdown From";

		public event PropertyChangedEventHandler PropertyChanged;

		public MainWindow()
		{
			InitializeComponent();
			DataContext = this; 
			_dispatcherTimer.Tick += new EventHandler(DispatcherTimer_Tick);
			_dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
		}

		protected void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); 
		}

		private void DispatcherTimer_Tick(object sender, EventArgs e)
		{
			if (!_isStopwatch)
			{
				Input--;
				if (_input <= 0)
				{
					IsRunning = false;
					_dispatcherTimer.Stop();
				}
			}
			else
			{
				Input++; 
			}
		}

		private void CheckIfInputIsNumber(object sender, TextChangedEventArgs e)
		{

			//removing spaces on right and left sides
			string userInput =(sender as TextBox).Text.Trim();

			if (Int32.TryParse(userInput, out int result))
			{
				if(result < 1)
				{
					MessageBox.Show("Please enter a number between 1 and " + Int32.MaxValue.ToString());
					UserInput.Clear();
					_isDefaultValueOrEmpty = true; 
				}
				else
				{
					_isDefaultValueOrEmpty = false; 
					Input = result; 

				}
			}
			else 
			{
				if (userInput!= "" && userInput != _textboxPlaceholder)
				{
					MessageBox.Show("Please enter a number between 1 and " + Int32.MaxValue.ToString());
					UserInput.Clear();
					_isDefaultValueOrEmpty = true;
				}

			}
			
		}

		private void SelectTextboxInputOnFocus(object sender, RoutedEventArgs e)
		{
			TextBox tb = (sender as TextBox); 
			if(tb != null)
			{
				tb.SelectAll(); 
			}
		}

		private void SelectivelyIgnoreMouseButton(object sender, MouseButtonEventArgs e)
		{
			TextBox tb = (sender as TextBox); 

			if(tb!= null)
			{
				if (!tb.IsKeyboardFocusWithin)
				{
					e.Handled = true;
					tb.Focus(); 
				}
			}
		}

		private void StartButtonClicked(object sender, RoutedEventArgs e)
		{
			if (!_isStopwatch)
			{
				if (!_isDefaultValueOrEmpty)
				{
					_dispatcherTimer.Start();
					IsRunning = true;
				}
			}
			else
			{
				_dispatcherTimer.Start();
				IsRunning = true;
			}
			
		}

		private void PauseButtonClicked(object sender, RoutedEventArgs e)
		{

			if(IsRunning)
			{
				_dispatcherTimer.IsEnabled = false;

			}	
		}

		private void StopButtonClicked(object sender, RoutedEventArgs e)
		{
			if(IsRunning)
			{
				Stop(); 
			}
		}

		private void Stop()
		{
			_dispatcherTimer.Stop();
			IsRunning = false;
			if (!_isStopwatch)
			{
				if (Int32.TryParse(UserInput.Text, out int result))
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

        private void TimerTypeSelectionChanged(object sender, MouseButtonEventArgs e)
        {
			MessageBox.Show("achieved");

			if (_isStopwatch)
			{
				_isStopwatch = false;
			}
			else
			{
				_isStopwatch = true; 
			}
			Stop();
        }
    }
}
