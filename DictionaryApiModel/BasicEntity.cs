using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Model
{
    public abstract class BasicEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
