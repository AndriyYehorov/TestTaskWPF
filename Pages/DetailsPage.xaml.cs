using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using TestTaskWPF.Models;
using TestTaskWPF.ViewModels;

namespace TestTaskWPF.Pages
{
    /// <summary>
    /// Interaction logic for DetailsPage.xaml
    /// </summary>
    public partial class DetailsPage : Page
    {
        private const int marketsCount = 20;

        public DetailsPage(Coin coin, IApiService apiService)
        {
            InitializeComponent();

            ApiService = apiService;

            DetailsViewModel = new DetailsViewModel(coin);

            DataContext = DetailsViewModel;
        }

        private DetailsViewModel DetailsViewModel { get; set; }

        private IApiService ApiService { get; set; }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var apiResponse = await ApiService.GetMarketsAsync(DetailsViewModel.CoinDetails.Id, marketsCount);

            DetailsViewModel.Markets = new ObservableCollection<Market>(apiResponse.Data);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var mainPage = new MainPage(ApiService);

            NavigationService.Navigate(mainPage);
        }
    }
}
