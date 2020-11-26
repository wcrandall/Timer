using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Timer.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name)); 
        }

        protected void SetValue<T>(ref T backingField, T value, [CallerMemberName] string name = null)
        {
            if(EqualityComparer<T>.Default.Equals(backingField, value))
            {
                return;
            }
            backingField = value;
            OnPropertyChanged(name); 
        }
    }
}
