using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CountDown.ViewModel
{
    public class WordsSelection1ViewModel : INotifyPropertyChanged
    {
        private string player1;
        public string Player1
        {
            get => player1;
            set
            {
                player1 = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(player1msg));
            }
        }

        public string player1msg => $"Player 1 ({player1}) please select the words...";

        private int round;
        public int Round
        {
            get => round;
            set
            {
                round = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(roundNumber));
            }
        }

        public string roundNumber => $"Round : {round}";

        private int vowelsSelected;
        public int VowelsSelected
        {
            get => vowelsSelected;
            set
            {
                vowelsSelected = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(NoOfVowelsSelected));
            }
        }

        public string NoOfVowelsSelected => $"Selected Vowels = {vowelsSelected}";

        private int consonantsSelected;
        public int ConsonantsSelected
        {
            get => consonantsSelected;
            set
            {
                consonantsSelected = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(NoOfConsonantsSelected));
            }
        }

        public string NoOfConsonantsSelected => $"Selected Consonants = {consonantsSelected}";

        public WordsSelection1ViewModel()
        {
            Player1 = Global.player1Name;
            vowelsSelected = 0;
            consonantsSelected = 0;
            round = Global.round;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool ValidateSelection()
        {
            return VowelsSelected >= 3 && ConsonantsSelected >= 4;
        }

        public void ResetSelection()
        {
            VowelsSelected = 0;
            ConsonantsSelected = 0;
        }
    }
}
