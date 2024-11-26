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
            try
            {
                var apiResponse = await ApiService.GetCoinsAsync(coinsCount);

                CoinViewModel.Coins = new ObservableCollection<Coin>(apiResponse.Data);
            }
            catch (Exception ex) 
            {
                MessageBox.Show($"An error occurred while downloading data: {ex.Message}");
            }
        }   

        private void CoinsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var detailsPage = new DetailsPage(CoinsListView.SelectedItem as Coin, ApiService);

            NavigationService.Navigate(detailsPage);
        }

        private async void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                var apiResponse = await ApiService.GetCoinsByNameAsync(SearchTextBox.Text, coinsCount);

                CoinViewModel.Coins = new ObservableCollection<Coin>(apiResponse.Data);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while downloading data: {ex.Message}");
            }
        }
    }
}
