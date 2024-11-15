using System;
using System.Collections.Generic;
using CommunityToolkit.Maui.Storage;
using Lab.ParseStrategy;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Compatibility;

namespace Lab
{
    public partial class MainPage : ContentPage
    {
        FileSystem fileSystem;
        XmlParser parser;
        bool isLabelShown = false;

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
            catch (Exception ex)
            {
                await DisplayAlert("Помилка при завантаженні", ex.Message, "OK");
                return;
            }

            parser.Parse(new DomParse(), result);

            string[] attributes = parser.GetAttributes();
            FillAttributePicker(attributes);
            ShowMembers();
            await DisplayAlert("Файл завантажено", "Файл успішно завантажено. Атрибути для пошуку заповнено.", "OK");
        }

        private void FillAttributePicker(string[] names)
        {
            string[] translatedNames = new string[names.Length];
            for (int i = 0; i < names.Length; i++)
            {
                translatedNames[i] = Translator.GetTranslation(names[i]);
            }

            AttributePicker.ItemsSource = translatedNames;
        }

        private async void OnAttributeSelected(object sender, EventArgs e)
        {
            if (AttributePicker.SelectedIndex == -1)
            {
                parser.SelectAttribute(Attribute.None);
                return;
            }
            {
                var SelectedItem = AttributePicker.SelectedItem;
                if (SelectedItem == null)
                {
                    parser.SelectAttribute(Attribute.None);
                    return;
                }

                string selectedAttribute = SelectedItem.ToString();
                selectedAttribute = Translator.GetTranslation(selectedAttribute);

                Attribute attribute = (Attribute)Enum.Parse(typeof(Attribute), selectedAttribute);
                parser.SelectAttribute(attribute);
            }
        }

        private void OnSearchedClicked(object sender, EventArgs e)
        {
            ShowMembers();
        }

        private void OnClearClicked(object sender, EventArgs e)
        {
            AttributePicker.SelectedItem = null;
            AttributeInput.Text = "";
            ShowMembers();
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

        private void OnParserTypeChanged(object sender, EventArgs e)
        {
            if (parser == null) return;

            RadioButton btn = (RadioButton)sender;
            string parserType = btn.Content.ToString();

            switch (parserType) {
                case "DOM":
                    parser.SelectParser(new DomParse());
                    break;
                case "SAX":
                    parser.SelectParser(new SaxParse());
                    break;
                case "LINQ":
                    parser.SelectParser(new LinqParse());
                    break;
            }
        }
        private void AttributeInput_Unfocused(object sender, EventArgs e)
        {
            string content = AttributeInput.Text;
            parser.SelectSearhBy(content);
        }

        private void ShowMembers()
        {
            parser.Parse();
            if (!isLabelShown)
            {
                string[] attributes = parser.GetAttributes();
                int columnNumber = 0;

                foreach (string attribute in attributes)
                {
                    if (attribute == "None") continue;

                    Label label = new Label
                    {
                        Text = Translator.GetTranslation(attribute),
                        FontAttributes = FontAttributes.Bold,
                        VerticalOptions = LayoutOptions.Center,
                        HorizontalOptions = LayoutOptions.Fill
                    };

                    ParsedTableGrid.AddColumnDefinition(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

                    ParsedTableGrid.SetColumn(label, columnNumber++);
                    ParsedTableGrid.SetRow(label, 0);
                    ParsedTableGrid.Children.Add(label);
                }
                isLabelShown = true;
            }

            int attributeNumber = parser.GetAttributes().Length;
            var childrenToRemove = ParsedTableGrid.Children.Skip(attributeNumber).ToList();

            foreach (var child in childrenToRemove)
            {
                ParsedTableGrid.Children.Remove(child);
            }

            List<StaffMember> members = parser.GetMebmersByAttribute();
            ParsedTableGrid.AddRowDefinition(new RowDefinition());
            for (int i = 0; i < members.Count; i++)
            {
                var member = members[i];
                ParsedTableGrid.AddRowDefinition(new RowDefinition());
                for (int j = 1; j < attributeNumber; j++)
                {
                    Attribute attribute = (Attribute)j;
                    Label entry = new Label
                    {
                        Text = member.values[attribute],
                    };

                    ParsedTableGrid.SetColumn(entry, j-1);
                    ParsedTableGrid.SetRow(entry, i+1);
                    ParsedTableGrid.Children.Add(entry);
                }
            }

        }

        private void AttributeInput_Unfocused(object sender, FocusEventArgs e)
        {

        }
    }
}
