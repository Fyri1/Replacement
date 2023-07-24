using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace txt_read.Modifiers.ChangingEnd
{
    public class ChangingEndModifierLoader
    {
        [JsonProperty("Path")]
        private readonly string _path;

        public ChangingEndModifierLoader(string path)
        {
            _path = path;
        }

        public IEnumerable<KeyValuePair<string, IEnumerable<string>>> Load()
        {
            return File.ReadAllLines(_path).Select(w =>
            {
                var key = w.Split(':')[0];
                var value = w.Split(':')[1].Split(',');
                return new KeyValuePair<string, IEnumerable<string>>(key, value);
            });
        }
    }
}
