using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using txt_read.Modifiers;

namespace DataEditor.Builders
{
    public abstract class RuleBuilder<T> where T : Modifier
    {
        public override string ToString()
        {
            return typeof(T).Name;
        }
        public abstract T Create();
    }
}
