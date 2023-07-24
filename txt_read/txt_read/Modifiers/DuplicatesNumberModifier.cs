using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static txt_read.Modifiers.DuplicateAllModifier;

namespace txt_read.Modifiers
{
    public class DuplicatesNumberModifier : Modifier
    {

        public override string Name { get => "Duplicates Number Modifier"; }

        //public readonly string   DuplicatesNumber;
        [JsonProperty("DuplicatesNumberCombinationType")]
        private readonly DuplicationType _combinationType;
        public DuplicatesNumberModifier(DuplicationType combinationType)
        {
            _combinationType = combinationType;
        }
        public override IEnumerable<string> Modify(string readfile) 
        {
            List<string> result = new List<string>();

            if (_combinationType is DuplicationType.WithSave)
            {
                StringBuilder sb = new StringBuilder(readfile);


                int count = 1; // счетчик для определения порядкового номера цифры

                for (int i = 0; i < readfile.Length; i++)
                {
                    if (Char.IsDigit(readfile[i]))
                    {
                        sb.Insert(i + count, readfile[i]); // вставляем цифру на следующую позицию
                        count++; // увеличиваем счетчик
                        result.Add(sb.ToString());
                    }

                }
            }

            else if (_combinationType is DuplicationType.WithoutSave)
            {
                int count = 1; // счетчик для определения порядкового номера цифры

                for (int i = 0; i < readfile.Length; i++)
                {
                    StringBuilder sb = new StringBuilder(readfile);

                    if (Char.IsDigit(readfile[i]))
                    {
                        sb.Insert(i, readfile[i]); // вставляем цифру на следующую позицию
                        count++; // увеличиваем счетчик
                        result.Add(sb.ToString());
                    }

                }
            }


            return result;
        }

        public enum DuplicationType
        {
            WithSave,
            WithoutSave

        }
        public override string ToString()
        {
            return $" Duplicates Number Modifier   (Parameter: {_combinationType})";
        }


    }
}
