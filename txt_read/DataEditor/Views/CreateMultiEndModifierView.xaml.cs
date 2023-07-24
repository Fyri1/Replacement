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
    /// Логика взаимодействия для CreateMultiEndModifierView.xaml
    /// </summary>
    public partial class CreateMultiEndModifierView : Window
    {
        public string? AddLine { get; private set; } = null;
        public List<string>? ListProperty { get; private set; } = null;
        public List<KeyValuePair<string, IEnumerable<string>>> Endings { get; private set; }

        public CreateMultiEndModifierView()
        {
            InitializeComponent();
            Endings = new List<KeyValuePair<string, IEnumerable<string>>>
            {
                new KeyValuePair<string, IEnumerable<string>>("ss",  new List<string>{ "es","Es","ES"}),
                new KeyValuePair<string, IEnumerable<string>>("x",  new List<string>{ "es","Es","ES"}),
                new KeyValuePair<string, IEnumerable<string>>("z",  new List<string>{ "es","Es","ES"}),
                new KeyValuePair<string, IEnumerable<string>>("ch",  new List<string>{ "es","Es","ES"}),
                new KeyValuePair<string, IEnumerable<string>>("sh",  new List<string>{ "es","Es","ES"}),
                new KeyValuePair<string, IEnumerable<string>>("o",  new List<string>{ "es","Es","ES"}),
                new KeyValuePair<string, IEnumerable<string>>("e",  new List<string>{ "r", "R","s","S"}),
              
            };
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TextboxAddLine.Text) || string.IsNullOrEmpty(TextboxAddLine_Copy.Text))
            {
                MessageBox.Show("Enter value!");
                return;
            }

            AddLine = TextboxAddLine.Text;
            ListProperty = new List<string> { TextboxAddLine_Copy.Text };

            // Убедитесь, что Endings инициализирован
            if (Endings == null)
                Endings = new List<KeyValuePair<string, IEnumerable<string>>>();

            // Добавить новую пару ключ-значение в список Endings
            Endings.Add(new KeyValuePair<string, IEnumerable<string>>(AddLine, ListProperty));

            Close();
        }
        public static MultiEndModifier? Create()
        {
            var form = new CreateMultiEndModifierView();
            form.ShowDialog();

            if (string.IsNullOrEmpty(form.AddLine) || form.Endings is null)
                return null;

            // Преобразуйте List<KeyValuePair<string, IEnumerable<string>>> в Dictionary<string, IEnumerable<string>>
            Dictionary<string, IEnumerable<string>> endingsDictionary = form.Endings.ToDictionary(kv => kv.Key, kv => kv.Value);

            // Дополнительная проверка на null после преобразования
            if (endingsDictionary is null)
                return null;

            return new MultiEndModifier(form.AddLine, endingsDictionary);
        }

        private void TextboxAddLine_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextboxAddLine_Copy_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
