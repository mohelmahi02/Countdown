using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Timers;

namespace CountDown.ViewModel
{
    internal class SettingsViewPage : INotifyPropertyChanged
    {
        private int round;
        public int Round
        {
            get => round;
            set
            {
                round = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(score_time_str));
            }
        }

        private int time;
        public int Time
        {
            get => time;
            set
            {
                time = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(score_time_str));
            }
        }

        public string score_time_str => $"Time: {time}sec / Rounds : {round}";

        public SettingsViewPage()
        {
            time = Global.TimerLength;
            round = Global.TotalRounds;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
