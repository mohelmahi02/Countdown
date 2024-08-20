using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace CountDown.ViewModel
{
    public class GameHistoryViewPage : INotifyPropertyChanged
    {
        private ObservableCollection<History> _gameHistories;
        public ObservableCollection<History> GameHistories
        {
            get { return _gameHistories; }
            set
            {
                _gameHistories = value;
                OnPropertyChanged();
            }
        }

        public GameHistoryViewPage()
        {
            GameHistories = new ObservableCollection<History>();
        }

        public async Task LoadGameHistoriesAsync()
        {
            var histories = await GameHistoryManager.LoadGameHistoryAsync();
            GameHistories.Clear();

            histories.Reverse();

            foreach (var history in histories)
            {
                GameHistories.Add(history);
            }

            OnPropertyChanged(nameof(GameHistories));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
