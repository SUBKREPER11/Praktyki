using System;
using System.Collections.Generic;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

//Szablon elementu Pusta strona jest udokumentowany na stronie https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x415

namespace notatnik_xaml
{
    /// <summary>
    /// Pusta strona, która może być używana samodzielnie lub do której można nawigować wewnątrz ramki.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        bool textChanged = false;
        bool loading = false;
        IStorageFile saveFile = null;
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void text_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (loading)
            {
                loading = false;
                return;
            }
            if (!textChanged)
            {
                filename.Text += "*";
                saveButton.IsEnabled = true;
                textChanged = true;
            }
        }

        private async void openButton_Click(object sender, RoutedEventArgs e)
        {
            if (textChanged)
            {
                MessageDialog overwriteDialog = new MessageDialog(
                    "Plik został zmieieniony. Na pewno chcesz wczytać nowy plik?");
                overwriteDialog.Commands.Add(new UICommand("Tak"));
                overwriteDialog.Commands.Add(new UICommand("Nie"));
                overwriteDialog.DefaultCommandIndex = 1;
                UICommand result = await overwriteDialog.ShowAsync() as UICommand;
                if (result != null && result.Label == "Nie")
                    return;
            }
            OpenFile();
        }

        private async void OpenFile()
        {
            FileOpenPicker picker = new FileOpenPicker
            {
                ViewMode = PickerViewMode.List,
                SuggestedStartLocation = PickerLocationId.DocumentsLibrary
            };
            picker.FileTypeFilter.Add(".txt");
            picker.FileTypeFilter.Add(".xml");
            picker.FileTypeFilter.Add(".xaml");
            IStorageFile file = await picker.PickSingleFileAsync();
            if(file != null)
            {
                string fileContents = await FileIO.ReadTextAsync(file);
                loading = true;
                text.Text = fileContents;
                textChanged = false;
                filename.Text = file.Name;
                saveFile = file;
            }
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFile();
        }

        private async void SaveFile()
        {
            if(saveFile == null)
            {
                FileSavePicker picker = new FileSavePicker
                {
                    DefaultFileExtension = ".txt",
                    SuggestedStartLocation = PickerLocationId.DocumentsLibrary
                };
                picker.FileTypeChoices.Add("Plik tekstowy", new List<string>() { ".txt" });
                picker.FileTypeChoices.Add("Plik XML ", new List<String>() { ".xml", ".xaml" });
                saveFile = await picker.PickSaveFileAsync();
                if (saveFile == null) return;
            }
            await FileIO.WriteTextAsync(saveFile, text.Text);
            await new MessageDialog("Zapisano plik " + saveFile.Name).ShowAsync();
            textChanged = false;
            filename.Text = saveFile.Name;
        }
    }
}
