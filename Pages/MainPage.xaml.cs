using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using TestTaskWPF.Models;
using TestTaskWPF.ViewModels;

namespace TestTaskWPF.Pages
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        private const int coinsCount = 10;

        private CoinViewModel CoinViewModel { get; set; }

        private IApiService ApiService { get; set; }

        public MainPage(IApiService apiService)
        {
            InitializeComponent();

            ApiService = apiService;

            CoinViewModel = new CoinViewModel();
            DataContext = CoinViewModel;
        }
        
        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var apiResponse = await ApiService.GetCoinsAsync(coinsCount);

            CoinViewModel.Coins = new ObservableCollection<Coin>(apiResponse.Data);
        }   

        private void CoinsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var detailsPage = new DetailsPage(CoinsListView.SelectedItem as Coin, ApiService);

            NavigationService.Navigate(detailsPage);
        }
    }
}
