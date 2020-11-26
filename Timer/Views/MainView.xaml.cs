using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
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

		
		
		//private void CheckIfInputIsNumber(object sender, TextChangedEventArgs e)
		//{
			
		//	//removing spaces on right and left sides
		//	UserInput =UserInput.Trim();

		//	if (Int32.TryParse(UserInput, out int result))
		//	{
		//		if(result < 1)
		//		{
		//			MessageBox.Show("Please enter a number between 1 and " + Int32.MaxValue.ToString());
		//			UserInput="";
		//			_isDefaultValueOrEmpty = true; 
		//		}
		//		else
		//		{
		//			_isDefaultValueOrEmpty = false;
		//			UserInput = result.ToString();
		//			Input = result; 

		//		}
		//	}
		//	else 
		//	{
		//		if (UserInput!= "" && UserInput != _textboxPlaceholder)
		//		{
		//			MessageBox.Show("Please enter a number between 1 and " + Int32.MaxValue.ToString());
		//			UserInput="";
		//			_isDefaultValueOrEmpty = true;
		//		}

		//	}
			
		//}

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
