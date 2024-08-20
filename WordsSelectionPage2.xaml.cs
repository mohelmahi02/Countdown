using Microsoft.Maui.Controls;
using System;

namespace CountDown
{
    public partial class WordsSelectionPage2 : ContentPage
    {
        private readonly char[] vowels = { 'A', 'A', 'A', 'A', 'A', 'A', 'A', 'A', 'A', 'A', 'A', 'A', 'A', 'A', 'A', 'E', 'E', 'E', 'E', 'E', 'E', 'E', 'E', 'E', 'E', 'E', 'E', 'E', 'E', 'E', 'E', 'E', 'E', 'E', 'E', 'E', 'E', 'E', 'E', 'I', 'I', 'I', 'I', 'I', 'I', 'I', 'I', 'I', 'I', 'I', 'I', 'I', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'U', 'U', 'U', 'U', 'U' };
        private readonly char[] consonants = { 'B', 'B', 'C', 'C', 'C', 'D', 'D', 'D', 'D', 'D', 'D', 'F', 'F', 'G', 'G', 'G', 'H', 'H', 'J', 'K', 'L', 'L', 'L', 'L', 'L', 'M', 'M', 'M', 'M', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'P', 'P', 'P', 'P', 'Q', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'S', 'S', 'S', 'S', 'S', 'S', 'S', 'S', 'S', 'T', 'T', 'T', 'T', 'T', 'T', 'T', 'T', 'T', 'V', 'W', 'X', 'Y', 'Z' };

        private readonly Random random = new Random();
        private Label[] boxLabels = new Label[9];
        int j = 0;

        private CountDown.ViewModel.WordsSelection2ViewModel viewModel;

        public WordsSelectionPage2()
        {
            InitializeComponent();
            InitializeGrid();

            viewModel = new CountDown.ViewModel.WordsSelection2ViewModel();
            BindingContext = viewModel;

            ShuffleArray(vowels);
            ShuffleArray(consonants);
        }

        private void InitializeGrid()
        {
            for (int i = 0; i < 9; i++)
            {
                var label = new Label
                {
                    Text = "",
                    TextColor = Colors.Black,
                    FontAttributes = FontAttributes.Bold,
                    BackgroundColor = Colors.White,
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalTextAlignment = TextAlignment.Center,
                    WidthRequest = 50,
                    HeightRequest = 50,
                    Margin = new Thickness(5)
                };

                boxGrid.Children.Add(label);
                Grid.SetColumn(label, i);
                Grid.SetRow(label, 0);
                boxLabels[i] = label;
            }
        }

        private async void OnVowelsClicked(object sender, EventArgs e)
        {
            viewModel.VowelsSelected++;
            FillBoxes(vowels);
            if (j == 9 && !viewModel.ValidateSelection())
            {
                await DisplayAlert("Warning", "You must select at least 3 vowels and 4 consonants.", "OK");
                ResetAllFields();
                Global.player1RandAlphas = "";
                Global.player2RandAlphas = "";
            }
        }

        private async void OnConsonantsClicked(object sender, EventArgs e)
        {
            viewModel.ConsonantsSelected++;
            FillBoxes(consonants);
            if (j == 9 && !viewModel.ValidateSelection())
            {
                await DisplayAlert("Warning", "You must select at least 3 vowels and 4 consonants.", "OK");
                ResetAllFields();
                Global.player1RandAlphas = "";
                Global.player2RandAlphas = "";
            }
        }

        private void FillBoxes(char[] lettersArray)
        {
            char randomLetter = lettersArray[random.Next(lettersArray.Length)];
            boxLabels[j].Text = randomLetter.ToString();
            Global.player1RandAlphas = Global.player1RandAlphas + randomLetter.ToString();
            Global.player2RandAlphas = Global.player2RandAlphas + randomLetter.ToString();
            j++;
            if (j == 9 && viewModel.ValidateSelection())
            {
                ResetAllFields();
                j = 0;
                Navigation.PushAsync(new TimerPlayer1());
            }
        }

        private void ResetAllFields()
        {
            viewModel.ResetSelection();
            foreach (var label in boxLabels)
            {
                label.Text = string.Empty;
            }
            j = 0;
        }
        private void ShuffleArray(char[] array)
        {
            array = array.OrderBy(x => random.Next()).ToArray();
        }
    }
}
