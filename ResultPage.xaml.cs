using CountDown.ViewModel;
using Microsoft.Maui.Controls;

namespace CountDown
{
    public partial class ResultPage : ContentPage
    {
        private ResultViewModel viewModel;
        public ResultPage()
        {
            InitializeComponent();
            BindingContext = new ResultViewModel();
        }

        public void nextRound(object sender, EventArgs e)
        {
            Global.player1RandAlphas = "";
            Global.player2RandAlphas = "";
            Global.player1Score = 0;
            Global.player2Score = 0;
            Global.round++;

            if(Global.round == (Global.TotalRounds + 1))
            {
                Navigation.PushAsync(new EndingPage());
            }
            else if(Global.round % 2 == 0)  // for even rounds start with player 2
            {
                Navigation.PushAsync(new WordsSelectionPage2());
            }
            else                // for odd rounds start with player 1
            {
                Navigation.PushAsync(new WordsSelectionPage());
            }
        }
    }
}
