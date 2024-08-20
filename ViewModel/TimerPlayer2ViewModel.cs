using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Timers;

namespace CountDown.ViewModel
{
    public class TimerPlayer2ViewModel : INotifyPropertyChanged
    {
        private string words;
        public string Words
        {
            get => words;
            set
            {
                words = value;
                OnPropertyChanged();
            }
        }

        private int remainingTime;
        public int RemainingTime
        {
            get => remainingTime;
            set
            {
                remainingTime = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(RemainingTimeText));
            }
        }

        public string RemainingTimeText => $"Time Left: {RemainingTime} sec";

        public TimerPlayer2ViewModel()
        {
            Words = Global.player1RandAlphas;
            RemainingTime = Global.TimerLength;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
