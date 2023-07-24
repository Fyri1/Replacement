using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace txt_read.Modifiers
{
    public class TwoNumbersWordsModifier : Modifier // num 19
    {
        public override string Name { get => "Two Numbers Words Modifier"; }
        public override IEnumerable<string> Modify(string readfile)
        {
            List<string> result = new List<string>();
            result.Add(readfile);

            for (int i = 0; i < readfile.Length - 1; i++)
            {
                if (char.IsDigit(readfile[i]) && char.IsLetter(readfile[i + 1]))
                {
                    char upperChar = char.ToUpper(readfile[i + 1]);
                    char lowerChar = char.ToLower(readfile[i + 1]);
                    List<string> newResults = new List<string>();
                    foreach (string resul in result)
                    {
                        newResults.Add(resul.Substring(0, i + 1) + upperChar + resul.Substring(i + 2));
                        newResults.Add(resul.Substring(0, i + 1) + lowerChar + resul.Substring(i + 2));
                    }
                    result = newResults;
                }
            }

            return result;
        }
    }
}
