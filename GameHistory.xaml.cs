using CountDown.ViewModel;
using Microsoft.Maui.Controls;

namespace CountDown
{
    public partial class GameHistory : ContentPage
    {
        private GameHistoryViewPage viewModel;

        public GameHistory()
        {
            InitializeComponent();
            viewModel = new GameHistoryViewPage();
            BindingContext = viewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await viewModel.LoadGameHistoriesAsync();
        }
    }
}
