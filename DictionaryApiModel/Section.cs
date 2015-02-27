using Newtonsoft.Json;
using System.Collections.Generic;

namespace Dictionary.Model
{
    public class Section
    {
        // properties
        public int ID { get; set; }
        public string Name { get; set; }

        // navigation properties
        public virtual ICollection<Word> Words {get; set; }
    }
}
