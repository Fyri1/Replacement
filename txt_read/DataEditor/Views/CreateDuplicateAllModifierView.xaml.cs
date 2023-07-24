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
using static txt_read.Modifiers.DuplicateAllModifier;

namespace DataEditor.Views
{
    /// <summary>
    /// Логика взаимодействия для CreateDuplicateAllModifier.xaml
    /// </summary>
    public partial class CreateDuplicateAllModifierView : Window
    {
        private bool _isSuccess = false;
        public CreateDuplicateAllModifierView()
        {
            InitializeComponent();
            var modifiers = new[]
            {
                DuplicationType.OnlyLetters,
                DuplicationType.Full,
                DuplicationType.NumbersBothSides,
                DuplicationType.NumbersEnd

            };


            foreach (var item in modifiers)
                ComboBoxRules.Items.Add(item);
            ComboBoxRules.SelectedIndex = 0;
        }

        public static DuplicateAllModifier? Create()
        {
            var form = new CreateDuplicateAllModifierView();
            form.ShowDialog();
            if (!form._isSuccess || form.ComboBoxRules.SelectedItem == null)
            {
                return null;
            }

             return new DuplicateAllModifier((DuplicationType) form.ComboBoxRules.SelectedItem  );
            
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            _isSuccess = true;

            Close();
        }
    }
}
