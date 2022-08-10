﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppBindingCommands
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public ICommand ShowMessageComand;

        private string name = string.Empty;

        public string Name
        {
            get => name;
            set
            {
                if (name == null)
                    return;
                name = value;
                OnPropertyChanged(nameof(Name));
                OnPropertyChanged(nameof(DisplayName));
            }
        }

        public string DisplayName => $"Nome digitado: {Name}";

        string displayMessage = string.Empty;

        public string DisplayMessage
        {
            get => displayMessage;
            set
            {
                if (displayMessage == null)
                    return;
                displayMessage = value;
                OnPropertyChanged(nameof(DisplayMessage));
            }
        }

        public void ShowMessage()
        {
            string dataProperty = Application.Current.Properties["dtAtual"].ToString();

            DisplayMessage = $"Boa noite {Name}. Hoje é{dataProperty}";
        }

        
        public MainPageViewModel()
        {
            ShowMessageComand = new Command(ShowMessage);
        }


    }
}