using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace txt_read.Modifiers.ChangingEnd
{
    public class ChangingEndModifier : Modifier
    {
        [JsonProperty("Path")]
        private readonly string _path;
        private Dictionary<string, IEnumerable<string>> _endings;

        public ChangingEndModifier(Dictionary<string, IEnumerable<string>> parameters)
        {
            _endings = parameters;
        }

        public override string Name { get => "Changing End Modifier"; }

        public void AddEnding(string key, IEnumerable<string> value)
        {
            _endings.Add(key, value);
        }

        public override IEnumerable<string> Modify(string data)
        {
            var list = new List<string>();

            // Обработка с использованием _endings
            var firstEnding = GetEnding(data);
            if (firstEnding != null)
            {
                foreach (var secondEnding in _endings[firstEnding])
                {
                    list.Add(data + secondEnding);
                }
            }

            return list;
        }

        private string? GetEnding(string data)
        {
            foreach (var ending in _endings)
            {
                if (data.EndsWith(ending.Key))
                    return ending.Key;
            }
            return null;
        }
    }
}