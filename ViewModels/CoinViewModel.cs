using System.Collections.ObjectModel;
using System.ComponentModel;
using TestTaskWPF.Models;

namespace TestTaskWPF.ViewModels
{
    class CoinViewModel : INotifyPropertyChanged
    {        
        private ObservableCollection<Coin> _coins;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Coin> Coins 
        { 
            get => _coins; 
            set 
            { 
                _coins = value; 
                OnPropertyChanged(nameof(Coins)); 
            } 
        }        
        
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

