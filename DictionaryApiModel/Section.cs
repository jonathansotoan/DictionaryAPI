using Newtonsoft.Json;
using System.Collections.Generic;

namespace Dictionary.Model
{
    public class Section : BasicEntity
    {
        // navigation property
        public virtual ICollection<Word> Words {get; set; }
    }
}
