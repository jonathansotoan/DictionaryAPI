using Newtonsoft.Json;
using System.Text;

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

        public override string ToString()
        {
            return string.Format("{0}, Definition: \"{1}\", SectionID: {2}", base.ToString(), Definition, SectionID);
        }
    }
}