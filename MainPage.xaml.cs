using Microsoft.Maui.Controls;

namespace CountDown
{
    
    public partial class MainPage : ContentPage
    {
        // Variables to store player names
       
        public MainPage()
        {
            InitializeComponent();
        }

        // Event handler for the Enter button click
        public void OnEnterClicked(object sender, EventArgs e)
        {
            // Retrieve the entered names from the Entry controls
            Global.player1Name = player1Entry.Text;
            Global.player2Name = player2Entry.Text;

            Navigation.PushAsync(new WordsSelectionPage());
            
        }

        public void OnSettingsClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SettingsPage());
        }

        public void OnGameHistoryClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GameHistory());
        }
    }
}