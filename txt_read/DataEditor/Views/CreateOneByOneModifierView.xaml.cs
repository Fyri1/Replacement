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
using static txt_read.Modifiers.OneByOneModifier;

namespace DataEditor.Views
{
    /// <summary>
    /// Логика взаимодействия для CreateOneByOneModifierView.xaml
    /// </summary>
    public partial class CreateOneByOneModifierView : Window
    {

        public string? AddLine { get; private set; } = null;


        private bool _isSuccess = false;

        public CreateOneByOneModifierView()
        {
            InitializeComponent();
            var modifiers = new[]
            {
                    DuplicationType.AddOneByOne,
                    DuplicationType.AddInOneDeletion,
                    DuplicationType.AddInOneSave

            };
            foreach (var item in modifiers)
                this.ComboBoxRules.Items.Add(item);
        }
        public static OneByOneModifier? Create()
        {
            var form = new CreateOneByOneModifierView();
            form.ShowDialog();
            if (!form._isSuccess || form.ComboBoxRules.SelectedItem == null || form.AddLine is null)
            {
                return null;
            }
            return new OneByOneModifier(form.AddLine, (DuplicationType)form.ComboBoxRules.SelectedItem);
        }
        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            _isSuccess = true;
            if (string.IsNullOrEmpty(TextboxAddLine.Text))
            {
                MessageBox.Show("Enter value!");
                return;
            }
            AddLine = TextboxAddLine.Text;
            Close();
        }

        private void ComboBoxRules_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }

}
