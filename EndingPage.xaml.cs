using System;
using System.Threading.Tasks;
using CountDown.ViewModel;
using Microsoft.Maui.Controls;

namespace CountDown
{
    public partial class EndingPage : ContentPage
    {
        private EndingViewPage viewPage;
        public EndingPage()
        {
            InitializeComponent();
            //BackgroundMusic.Play();
            viewPage = new EndingViewPage(); // Initialize viewPage
            BindingContext = viewPage;
            SaveGameHistoryAsync(Global.player1Name, Global.Totalplayer1Score, Global.player2Name, Global.Totalplayer2Score);
        }

        public void RestartGame(object sender, EventArgs e)
        {
            Global.player1Name = "";
            Global.player2Name = "";
            Global.player1RandAlphas = "";
            Global.player2RandAlphas = "";
            Global.player1Score = 0;
            Global.player2Score = 0;
            Global.round = 1;
            Global.Totalplayer1Score = 0;
            Global.Totalplayer2Score = 0;

            Navigation.PushAsync(new MainPage());
        }

        private async Task SaveGameHistoryAsync(string player1, int player1Score, string player2, int player2Score)
        {
            var gameHistory = new History
            {
                Timestamp = DateTime.Now,
                Player1 = player1,
                Player1Score = player1Score,
                Player2 = player2,
                Player2Score = player2Score
            };

            var gameHistories = await GameHistoryManager.LoadGameHistoryAsync();
            gameHistories.Add(gameHistory);
            await GameHistoryManager.SaveGameHistoryAsync(gameHistories);
        }
    }
}
