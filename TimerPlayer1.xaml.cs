using System;
using Microsoft.Maui.Controls;
using CountDown.ViewModel;
using System.Threading.Tasks;
using System.Globalization;
using System.Collections.Generic;

namespace CountDown
{
    public partial class TimerPlayer1 : ContentPage
    {
        string word = "";
        private TimerPlayer1ViewModel viewModel;

        public TimerPlayer1()
        {
            InitializeComponent();
            viewModel = new TimerPlayer1ViewModel();
            BindingContext = viewModel;
            _dictionaryService = new DictionaryService();
            LoadDictionary();
            StartTimer();
        }

        private void StartTimer()
        {
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                viewModel.RemainingTime--;

                if (viewModel.RemainingTime == 0)
                {
                    CheckWord();
                    return false; // Stop the timer
                }

                return true; // Repeat the timer
            });
        }

        private async void CheckWord()
        {
            int wordSize = 0;
            bool flag = true;
            bool flag1 = true;
            while (flag)
            {
                string wordSizeInput = await DisplayPromptAsync($"Player 1 ({Global.player1Name})", "Please enter your word size", "OK", "Cancel", "word", 10, Keyboard.Numeric, " ");
                int.TryParse(wordSizeInput, out wordSize);

                if (wordSize <= 9)
                {
                    while (flag1)
                    {
                        word = await DisplayPromptAsync($"Player 1 ({Global.player1Name})", $"Please enter your word of size {wordSize}", "OK", "Cancel", "word", (wordSize + 1), Keyboard.Text, " ");

                        if ((word.Length - 1) != wordSize)
                        {
                            await DisplayAlert("Invalid Input", $"Please enter a word size {wordSize}.", "OK");
                        }
                        else if (CheckAlphabets(Global.player1RandAlphas, word) == false)
                        {
                            await DisplayAlert("Invalid Input", $"Please enter a word from given alphabets.", "OK");
                        }
                        else
                        {
                            flag = false;
                            flag1 = false;
                        }
                    }
                }
                else
                {
                    await DisplayAlert("Invalid Input", "Please enter a valid number for the word size.", "OK");
                }

                if(CheckWordFromDictionary(word.Trim().ToLower()))
                {
                    Global.player1Score = wordSize;
                }
                else
                {
                    Global.player1Score = 0;
                }


                // now for player 2

                wordSize = 0;
                flag = true; flag1 = true;

                while (flag)
                {
                    wordSizeInput = await DisplayPromptAsync($"Player 2 ({Global.player2Name})", "Please enter your word size", "OK", "Cancel", "word", 10, Keyboard.Numeric, " ");
                    int.TryParse(wordSizeInput, out wordSize);

                    if (wordSize <= 9)
                    {
                        while (flag1)
                        {
                            word = await DisplayPromptAsync($"Player 2 ({Global.player2Name})", $"Please enter your word of size {wordSize}", "OK", "Cancel", "word", (wordSize + 1), Keyboard.Text, " ");

                            if ((word.Length - 1) != wordSize)
                            {
                                await DisplayAlert("Invalid Input", $"Please enter a word size {wordSize}.", "OK");
                            }
                            else if (CheckAlphabets(Global.player2RandAlphas, word) == false)
                            {
                                await DisplayAlert("Invalid Input", $"Please enter a word from given alphabets.", "OK");
                            }
                            else
                            {
                                flag = false;
                                flag1 = false;
                            }
                        }
                    }
                    else
                    {
                        await DisplayAlert("Invalid Input", "Please enter a valid number for the word size.", "OK");
                    }
                }
                if (CheckWordFromDictionary(word.Trim().ToLower()))
                {
                    Global.player2Score = wordSize;
                }
                else
                {
                    Global.player2Score = 0;
                }
            }
            

            // clearing all elements
            Global.player1RandAlphas = "";
            Global.player2RandAlphas = "";
            
            Navigation.PushAsync(new ResultPage());

        }



        public bool CheckAlphabets(string A, string B)
        {
            if (string.IsNullOrEmpty(A) || string.IsNullOrEmpty(B))
            {
                return false;
            }

            // Convert strings to lowercase to handle case insensitivity
            A = A.ToLower();
            B = B.ToLower();

            // Create frequency dictionaries for characters in string B and string A
            var frequencyInB = B.Where(char.IsLetter)
                                 .GroupBy(c => c)
                                 .ToDictionary(g => g.Key, g => g.Count());

            var frequencyInA = A.Where(char.IsLetter)
                                 .GroupBy(c => c)
                                 .ToDictionary(g => g.Key, g => g.Count());

            // Check if A contains all characters in B with at least the same count
            foreach (var kvp in frequencyInB)
            {
                if (!frequencyInA.TryGetValue(kvp.Key, out int count) || count < kvp.Value)
                {
                    return false;
                }
            }

            return true;
        }


        private DictionaryService _dictionaryService;
        private HashSet<string> _dictionary;

        

        private async void LoadDictionary()
        {
            try
            {
                var dictionaryContent = await _dictionaryService.GetDictionaryAsync();
                _dictionary = new HashSet<string>(dictionaryContent.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries));
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Failed to load dictionary: {ex.Message}", "OK");
            }
        }

        public bool CheckWordFromDictionary(string wordToCheck)
        {
            return _dictionary != null && _dictionary.Contains(wordToCheck);
        }
    }
}
