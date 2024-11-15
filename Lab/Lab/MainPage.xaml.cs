using System;
using System.Collections.Generic;
using CommunityToolkit.Maui.Storage;
using Lab.ParseStrategy;
using Microsoft.Maui.Controls;

namespace Lab
{
    public partial class MainPage : ContentPage
    {
        FileSystem fileSystem;
        XmlParser parser;

        public MainPage(IFileSaver fileSaver)
        {
            InitializeComponent();
            fileSystem = new FileSystem(fileSaver);
            parser = new XmlParser();
        }

        private async void OnLoadFileClicked(object sender, EventArgs e)
        {
            string result;
            try
            {
                result = await fileSystem.LoadAsync();
            }
            catch(Exception ex) {
                await DisplayAlert("Помилка при завантаженні", ex.Message, "OK");
                return;
            }

            parser.Parse(new LinqParse(), result);
            await DisplayAlert("Файл завантажено", "Файл успішно завантажено. Атрибути для пошуку заповнено.", "OK");
        }

        private async void OnSearchClicked(object sender, EventArgs e)
        {
        }

        private void OnClearClicked(object sender, EventArgs e)
        {
            AttributePicker.SelectedItem = null;
        }

        private async void OnExitClicked(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Вихід", "Чи дійсно ви хочете завершити роботу з програмою?", "Так", "Ні");
            if (answer)
            {
                System.Environment.Exit(0);
            }
        }

        private async void OnHelpClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Довідка", "Виконав Власенко Захар К-25", "OK");
        }
    }
}
