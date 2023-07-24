using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace txt_read.Modifiers
{
    public abstract class Modifier
    {
        public abstract string Name { get; }
        public abstract IEnumerable<string> Modify(string readfile);
        public override string ToString()
        {
            return Name;
        }



    }
}
