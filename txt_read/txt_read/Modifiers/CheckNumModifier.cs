using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using txt_read.Tools;

namespace txt_read.Modifiers
{

    public class CheckNumModifier : Modifier
    {
        public override string Name { get => "Check Num Modifier"; }

        [JsonProperty("AddingLine")]
        private string _addingLine;
        public CheckNumModifier(string addingLine)
        {
            _addingLine = addingLine;
        }

        public override IEnumerable<string> Modify(string readfile)
        {
            List<string> result = new List<string>();
            result.Add(readfile + _addingLine);
            result.Add(readfile + _addingLine.ToUpper());
            result.Add(readfile + _addingLine.ToLower());
            return result.Distinct();
        }

        public override string ToString()
        {
            return $" Check Num Modifier   (Parameter: {_addingLine})";
        }
    }
}
