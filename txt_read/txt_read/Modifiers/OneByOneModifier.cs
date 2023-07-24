using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace txt_read.Modifiers // 20-21 
{
    public class OneByOneModifier : Modifier
    {
        public override string Name { get => "One By One Modifier"; }



        [JsonProperty("AddingLine")]
        private string _addingLine;
        [JsonProperty("DuplicationType")]
        private readonly DuplicationType _duplicationType;

        public OneByOneModifier(string addingLine, DuplicationType duplicationType)
        {
            _addingLine = addingLine;
            _duplicationType = duplicationType;
        }

        public override IEnumerable<string> Modify(string readfile)
        {
            List<string> result = new List<string>();
            if (_duplicationType is DuplicationType.AddOneByOne)
            {
                for (int i = 0; i < readfile.Length; i++)
                {
                    StringBuilder sb = new StringBuilder(readfile);
                    sb.Insert(i, _addingLine);
                    result.Add(sb.ToString());
                }
                /*                StringBuilder sb2 = new StringBuilder(readfile);
                                sb2.Append(_addElem);
                                result.Add(sb2.ToString());*/
            }
            else if (_duplicationType is DuplicationType.AddInOneSave)
            {
                StringBuilder sb = new StringBuilder(readfile);
                for (int i = 1; i < readfile.Length; i += 2)
                {
                    sb.Insert(i, _addingLine);
                    result.Add(sb.ToString());
                }
            }
            else if (_duplicationType is DuplicationType.AddInOneDeletion)
            {
                // добавление поочереди через один. 
                for (int i = 1; i < readfile.Length; i += 2)
                {
                    StringBuilder sb = new StringBuilder(readfile);
                    sb.Insert(i, _addingLine);
                    result.Add(sb.ToString());
                }
            }
            
            return result;
            
        }
        public enum DuplicationType
        {
            AddOneByOne, //20
            AddInOneSave, //21
            AddInOneDeletion, //my custom 

        }
        public override string ToString()
        {
            return $" Duplicates Number Modifier   (Parameter: {_duplicationType}  {_addingLine})";
        }

    }
}
