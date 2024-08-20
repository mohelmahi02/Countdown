using System;
using Microsoft.Maui.Controls;
using CountDown.ViewModel;
using System.Threading.Tasks;
using System.Globalization;
using System.Collections.Generic;

namespace CountDown
{
    public partial class SettingsPage : ContentPage
    {
        private SettingsViewPage viewModel; 

        public SettingsPage()
        {
            InitializeComponent();
            viewModel = new SettingsViewPage(); 
            BindingContext = viewModel; 
            PopulatePicker();
            numberPicker.SelectedIndexChanged += OnPickerSelectedIndexChanged;
        }

        private void PopulatePicker()
        {
            for (int i = 2; i <= 10; i++)
            {
                numberPicker.Items.Add(i.ToString());
            }

            numberPicker.SelectedIndex = 0;
        }

        private void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            if (numberPicker.SelectedIndex != -1)
            {
                string selectedNumber = numberPicker.Items[numberPicker.SelectedIndex];
                Global.TotalRounds = int.Parse(selectedNumber);
                viewModel.Round = int.Parse(selectedNumber);   
            }
        }

        public void TwentySecClicked(object sender, EventArgs e)
        {
            Global.TimerLength = 20;
            viewModel.Time = 20;
            
        }

        public void ThirtySecClicked(object sender, EventArgs e)
        {
            Global.TimerLength = 30;
            viewModel.Time = 30;
            
        }

        public void FortySecClicked(object sender, EventArgs e)
        {
            Global.TimerLength = 40;
            viewModel.Time = 40;
            
        }
    }
}
