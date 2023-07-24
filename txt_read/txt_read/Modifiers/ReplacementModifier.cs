using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace txt_read.Modifiers
{
    //ну это мой эксперемнт , это можно заменить на твое...

    public class ReplacementModifier : Modifier
    {

        private readonly IEnumerable<(string PartToChange, string Replacement)> _replacements;

        public override string Name => "Replacement Modifier";

        public ReplacementModifier(IEnumerable<(string PartToChange, string Replacement)> replacements)
        {
            _replacements = replacements;
        }

       
        public override IEnumerable<string> Modify(string input)
        {
            List<string> res = new List<string>();
/*            var changedInput = ReplaceParts(input, _replacements.ToArray());
            if (changedInput != null)
                res.Add(changedInput);*/



            var changedInput2 = ReplacementSteps(input, _replacements.ToArray());
            foreach (string variant in changedInput2)
            {
                res.Add(variant);
            }

            return res.Distinct();

        }




        public static List<string> ReplacementSteps(string input, (string PartToChange, string Replacement)[] replacements, int index = 0, string currentVariant = "")
        {
            List<string> variants = new List<string>();

            if (index >= input.Length)
            {
                variants.Add(currentVariant);
                return variants;
            }

            char currentChar = input[index];

            foreach (var replacement in replacements)
            {
                if (replacement.PartToChange == currentChar.ToString())
                {
                    variants.AddRange(ReplacementSteps(input, replacements, index + 1, currentVariant + replacement.Replacement));
                }
            }

            variants.AddRange(ReplacementSteps(input, replacements, index + 1, currentVariant + currentChar));

            return variants;
        }

/*        public string? ReplaceParts(string input, params (string PartToChange, string Replacement)[] replacements) // МЕТОТ БЕСАКА
        {
            var temp = string.Join(null, replacements.Select(w => w.PartToChange + "|"));
            var pattern = "(" + temp.Remove(temp.Length - 1) + ")";
            Regex rgx = new Regex(pattern);

            var changedPart = rgx.Replace(input, m =>
            {

                return replacements.First(w => w.PartToChange == m.Value).Replacement;
            });


            return changedPart == input ? null : changedPart;
        }*/
        public override string ToString()
        {
            return $" Duplicates Number Modifier   (Replacements:{_replacements.Count()})";
        }

    }
}
