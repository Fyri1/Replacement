using DataEditor.Views;
using MaterialDesignExtensions.Controls;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using txt_read;
using txt_read.Modifiers;

namespace DataEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MaterialWindow
    {
        private Client? _client;

        public MainWindow()
        {
            var modifiers = new[]
            {
              
               "Check Num Modifier",
               "Duplicates All Modifier",
               "Duplicates Number Modifier",
               "Multi End Modifier",
               "One By One Modifier",
               "Replacement Modifier"
           };
            InitializeComponent();
            ComboBoxRules.SelectedIndex = 1;
            foreach (var item in modifiers)
                this.ComboBoxRules.Items.Add(item);
            UpdateUi();
        }

        private void ButtonAddRule_Click(object sender, RoutedEventArgs e)
        {
            switch (ComboBoxRules.Text)
            {
                case "Check Num Modifier":
                    ListViewRules.Items.Add(CreateCheckNumModifierView.Create());
                    return;

                case "Duplicates All Modifier":
                    ListViewRules.Items.Add(CreateDuplicateAllModifierView.Create());
                    return;
                case "Duplicates Number Modifier":
                    ListViewRules.Items.Add(CreateDuplicatesNumberModifierView.Create());
                    return;
                case "Multi End Modifier":
                    ListViewRules.Items.Add(CreateMultiEndModifierView.Create());
                    return;
                case "One By One Modifier":
                    ListViewRules.Items.Add(CreateOneByOneModifierView.Create());
                    return;
                case "Replacement Modifier":
                    ListViewRules.Items.Add(CreateReplacementModifierView.Create());
                    return;

            }
        }
        private  void UpdateUi()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    Thread.Sleep(1500);
                    if (_client is not null)
                        LogTextblock.Dispatcher.Invoke(() => LogTextblock.Text = $"{_client.Done} / {_client.Total}");
                }
            });

        }
        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            var  ofd = new Microsoft.Win32.OpenFileDialog();

            if (ofd.ShowDialog() != true)
                return;
            var mods = new Modifier[ListViewRules.Items.Count];
            var threadsAmount = int.Parse(TextboxThreadsAmount.Text);
            ListViewRules.Items.CopyTo(mods, 0);

            _client = new Client(mods, File.ReadAllLines(ofd.FileName));

            _client.Start(threadsAmount);
        }

        private void TextboxThreadsAmount_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Check if the entered character is not a digit
            if (!char.IsDigit(e.Text, 0))
            {
                // Prevent the character from being entered
                e.Handled = true;
            }
        }
    }
}
