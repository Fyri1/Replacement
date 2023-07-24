using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace txt_read.Modifiers
{
    public class DuplicateAllModifier : Modifier // nums 13  14 22
    {
        public override string Name { get => "Duplicate All Modifier"; }


        [JsonProperty("DuplicatesAllCombinationType")]
        private readonly DuplicationType _combinationType;

        public DuplicateAllModifier(DuplicationType combinationType)
        {
            _combinationType = combinationType;

        }
        public override IEnumerable<string> Modify(string readfile)
        {
            List<string> result = new List<string>();

            string allwords = Tools.ExtetsionsTools.GetLetters(readfile); // тут все символы
            string allnum = Tools.ExtetsionsTools.GetNumbers(readfile);// тут все цифры 
            string readfileLower = readfile.ToLower();

            if (_combinationType is DuplicationType.OnlyLetters)
            {
                result.AddRange(new[]
                {
                    readfile + allwords, //Bingo02Bingo
                    readfile + allwords.ToLower(), //Bingo02bingo
                    //allwords.ToLower() + readfile,
                    //readfileLower + allwords.ToLower()
                });
                return result.Distinct();
            }
            if (_combinationType is DuplicationType.Full)
            {
                result.Add(readfile + readfile);//Bingo02Bingo02
                result.Add(readfile + readfile.ToLower());//Bingo02bingo02
                result.Add(readfile.ToLower() + readfile);//bingo02Bingo02
                result.Add(readfile.ToLower() + readfile.ToLower());//bingo02bingo02
                return result.Distinct();
            }
            if (_combinationType is DuplicationType.NumbersBothSides)
            {
                // сделать проверку нахождения символа в конце и в начале строки 
                if (Tools.ExtetsionsTools.CheckNumbersAtEnd(readfile) == true )
                {
                    result.Add(allnum + allwords + allnum);
                }

                return result.Distinct();
            }
            if (_combinationType is DuplicationType.NumbersEnd)
            {
                result.Add(readfile + allnum);
                return result.Distinct();
            }

            return result.Distinct();
        }
        public enum DuplicationType
        {
            OnlyLetters,
            Full,
            NumbersBothSides,
            NumbersEnd
        }

        public override string ToString()
        {
            return $" Duplicate All Modifier   (Parameter: { _combinationType})";
        }
    }
}


