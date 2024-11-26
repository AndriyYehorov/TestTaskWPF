using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskWPF.Models;

namespace TestTaskWPF.ViewModels
{
    public class DetailsViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Market> _markets;

        public DetailsViewModel(Coin coinDetails)
        {
            CoinDetails = coinDetails;            
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public Coin CoinDetails { get; set; }

        public ObservableCollection<Market> Markets 
        { 
            get => _markets; 
            set
            {
                _markets = value;
                OnPropertyChanged(nameof(Markets));
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}