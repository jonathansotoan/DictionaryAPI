using Newtonsoft.Json;

namespace Dictionary.Model
{
    public class Word : BasicEntity
    {
        // properties
        public string Definition { get; set; }

        public int? SectionID { get; set; }

        // navigation properties (virtual keyword allows lazy loading)
        [JsonIgnore]
        public virtual Section Section { get; set; }
    }
}