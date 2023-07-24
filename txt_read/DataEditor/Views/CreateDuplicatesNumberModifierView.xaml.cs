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
using static txt_read.Modifiers.DuplicatesNumberModifier;

namespace DataEditor.Views
{
    /// <summary>
    /// Логика взаимодействия для CreateDuplicatesNumberModifierView.xaml
    /// </summary>
    public partial class CreateDuplicatesNumberModifierView : Window
    {
        private bool _isSuccess = false;

        public CreateDuplicatesNumberModifierView()
        {
            InitializeComponent();
            var modifiers = new[]
{
                DuplicationType.WithSave,
                DuplicationType.WithoutSave,

            };
            foreach (var item in modifiers)
                this.ComboBoxRules.Items.Add(item);
            ComboBoxRules.SelectedIndex = 0;
        }
        public static DuplicatesNumberModifier? Create()
        {
            var form = new CreateDuplicatesNumberModifierView();
            form.ShowDialog();
            if (!form._isSuccess || form.ComboBoxRules.SelectedItem == null)
            {
                return null;
            }

            return new DuplicatesNumberModifier((DuplicationType)form.ComboBoxRules.SelectedItem);

        }
        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            _isSuccess = true;

            Close();
        }
    }
}
