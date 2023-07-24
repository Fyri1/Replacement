using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using txt_read.Modifiers;
using static txt_read.Modifiers.ReplacementModifier;


namespace DataEditor.Views
{
    /// <summary>
    /// Логика взаимодействия для CreateReplacementModifierView.xaml
    /// </summary>
    public partial class CreateReplacementModifierView : Window
    {


        private bool _isSuccess = false;
        private List<(string, string)> _replacements;

        public CreateReplacementModifierView()
        {
            InitializeComponent();
            _replacements = new List<(string, string)>();
        }
        public static ReplacementModifier? Create()
        {
            var form = new CreateReplacementModifierView();
            form.ShowDialog();
            if (!form._isSuccess || !form._replacements.Any())
            {
                return null;
            }


            return new ReplacementModifier(form._replacements);

        }
        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            _isSuccess = true;
            if (string.IsNullOrEmpty(TextboxFirstElement.Text) || string.IsNullOrEmpty(TextboxFirstElementСhange.Text))
            {
                MessageBox.Show("Enter value!");
                return;
            }

            Close();
        }

        private void AddReplacementButton_Click(object sender, RoutedEventArgs e)
        {
            var partToChange = TextboxFirstElement.Text;
            var replacement = TextboxFirstElementСhange.Text;

            if (string.IsNullOrEmpty(replacement) || string.IsNullOrEmpty(partToChange))
                return;
            if (_replacements.Contains((partToChange, replacement)))
                return;
            _replacements.Add((partToChange, replacement));
            ListViewReplacements.Items.Add($"{partToChange} : {replacement}");
        }
    }
}
