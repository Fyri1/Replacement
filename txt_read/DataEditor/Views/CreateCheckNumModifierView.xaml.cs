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

namespace DataEditor.Views
{
    /// <summary>
    /// Interaction logic for CreateCheckNumModifierView.xaml
    /// </summary>
    public partial class CreateCheckNumModifierView : Window
    {
        public string? AddLine { get; private set; } = null;
        public CreateCheckNumModifierView()
        {
            InitializeComponent();
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TextboxAddLine.Text))
            {
                MessageBox.Show("Enter value!");
                return;
            }
            AddLine = TextboxAddLine.Text;
            Close();
        }
        public static CheckNumModifier? Create()
        {
            var form = new CreateCheckNumModifierView();
            form.ShowDialog();
            return form.AddLine is null ? null : new CheckNumModifier(form.AddLine);
        }
    }
}
