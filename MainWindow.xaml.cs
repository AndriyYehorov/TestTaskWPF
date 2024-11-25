using System.Windows;
using TestTaskWPF.Pages;

namespace TestTaskWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IApiService ApiService { get; set; }

        public MainWindow(IApiService apiService)
        {
            InitializeComponent();

            ApiService = apiService;
           
            MainFrame.Navigate(new MainPage(ApiService));
        }
    }
}