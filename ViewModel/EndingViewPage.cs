using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace CountDown.ViewModel
{
    public class EndingViewPage : INotifyPropertyChanged
    {
        private string player1;
        public string Player1
        {
            get => player1;
            set
            {
                player1 = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Player1Msg)); // Correct casing here
            }
        }

        public string Player1Msg => $"{player1} has won the game..."; // Correct casing here

        public EndingViewPage()
        {
            if (Global.Totalplayer1Score > Global.Totalplayer2Score)
            {
                Player1 = Global.player1Name;
            }
            else if (Global.Totalplayer1Score < Global.Totalplayer2Score)
            {
                Player1 = Global.player2Name;
            }
            else
            {
                Player1 = "Match TIED no one";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
