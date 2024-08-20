using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CountDown.ViewModel
{
    public class ResultViewModel : INotifyPropertyChanged
    {
        private int score1;
        public int Player1Score
        {
            get => score1;
            set
            {
                score1 = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(player1Score));
            }
        }

        public string name1;
        public string Player1name
        {
            get => name1;
            set
            {
                name1 = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(player1Score));
            }
        }

        public string player1Score => $"{name1} score : {score1}";


        private int score2;
        public int Player2Score
        {
            get => score2;
            set
            {
                score2 = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(player2Score));
            }
        }

        public string name2;
        public string Player2name
        {
            get => name2;
            set
            {
                name2 = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(player2Score));
            }
        }

        public string player2Score => $"{name2} score : {score2}";

        public ResultViewModel()
        {
            name1 = Global.player1Name;
            name2 = Global.player2Name;
            if(Global.player1Score > Global.player2Score)
            {
                Global.Totalplayer1Score = Global.Totalplayer1Score + Global.player1Score;
                Player1Score = Global.Totalplayer1Score;
                Player2Score = Global.Totalplayer2Score;
            }
            else if(Global.player1Score < Global.player2Score)
            {
                Global.Totalplayer2Score = Global.Totalplayer2Score + Global.player2Score;
                Player1Score = Global.Totalplayer1Score;
                Player2Score = Global.Totalplayer2Score;
            }
            else
            {
                Global.Totalplayer1Score = Global.Totalplayer1Score + Global.player1Score;
                Global.Totalplayer2Score = Global.Totalplayer2Score + Global.player2Score;
                Player1Score = Global.Totalplayer1Score;
                Player2Score = Global.Totalplayer2Score;
            }

            Global.player1Score = 0;
            Global.player2Score = 0;
            score1 = Global.Totalplayer1Score;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
