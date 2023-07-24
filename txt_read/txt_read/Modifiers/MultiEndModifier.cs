using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using txt_read.Modifiers.ChangingEnd;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace txt_read.Modifiers
{
    public class MultiEndModifier : Modifier
    {
        private readonly string _addElem;
        private readonly Dictionary<string, IEnumerable<string>> _endings;

        public MultiEndModifier(string addElem, Dictionary<string, IEnumerable<string>> endings)
        {
            _addElem = addElem;
            _endings = endings;
        }

        public override string Name => "Multi End Modifier";

        public override IEnumerable<string> Modify(string readfile)
        {
            List<string> result = new List<string>();

            bool hasDigitsAtEndOfWord = Regex.IsMatch(readfile, @"\d+\b");
            var modifier = new ChangingEndModifier(_endings);

            if (readfile.All(Char.IsDigit))
            {
                // Если в строке только цифры, просто добавляем исходную строку
                result.Add(readfile);
                return result.Distinct();
            }

            if (Tools.ExtetsionsTools.ContainsOnlyLetters(readfile))
            {
                // Если в строке только буквы, применяем ChangingEndModifier
                var modifiedStrings = modifier.Modify(readfile);

                foreach (var str in modifiedStrings)
                {
                    result.Add(str);
                }
                return result.Distinct();
            }

            if (hasDigitsAtEndOfWord)
            {
                // Если в конце строки есть цифры, обрабатываем их
                Match match = Regex.Match(readfile, @"^(.*[^\d])(\d+)$");
                string allwords = match.Groups[1].Value;
                string allnum = match.Groups[2].Value;

                var modifiedStrings = modifier.Modify(allwords);

                foreach (var str in modifiedStrings)
                {
                    result.Add(str + allnum);
                }
                return result.Distinct();
            }

            // Обработка с использованием _endings
            foreach (var ending in _endings)
            {
                if (readfile.EndsWith(ending.Key))
                {
                    foreach (var replacement in ending.Value)
                    {
                        result.Add(readfile.Substring(0, readfile.Length - ending.Key.Length) + replacement);
                    }
                    return result.Distinct();
                }
            }

            // Если ни одно из условий не выполнено, используйте обычную обработку
            var modifiedStrings2 = modifier.Modify(readfile);
            result.AddRange(modifiedStrings2);
            return result.Distinct();
        }

        public override string ToString()
        {
            string endingsString = string.Join(", ", _endings.Select(kv => $"{kv.Key}: [{string.Join(", ", kv.Value)}]"));
            return $"Multi End Modifier (Parameter: {_addElem}, Endings: {endingsString})";
        }
    }
}
