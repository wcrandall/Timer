using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Timer.Services;
using Timer.ViewModels;

namespace Timer
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window
	{


		public MainView()
		{
			InitializeComponent();
			ViewModel = new MainViewModel(new Countdown(), new PageService()); 
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
		private void Label_MouseLeftButtonDown_StopwatchSelected(object sender, MouseButtonEventArgs e)
		{
			ViewModel.SelectionChanged(new Stopwatch());
		}

		private void Label_MouseLeftButtonDown_CountdownSelected(object sender, MouseButtonEventArgs e)
		{
			ViewModel.SelectionChanged(new Countdown());
		}

		public MainViewModel ViewModel
        {
            get
            {
				return DataContext as MainViewModel;
            }
            set
            {
				DataContext = value; 
            }
        }
    }
}
