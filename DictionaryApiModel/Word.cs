using Newtonsoft.Json;

namespace Dictionary.Model
{
    public class Word
    {
        // properties
        public int ID { get; set; }
        public string Name { get; set; }
        public string Definition { get; set; }

        public int? SectionID { get; set; }

        // navigation properties (virtual keyword allows lazy loading)
        [JsonIgnore]
        public virtual Section Section { get; set; }
    }
}