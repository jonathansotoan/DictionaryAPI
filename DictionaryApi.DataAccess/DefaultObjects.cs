using Dictionary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.DataAccess
{
    public class DefaultObjects
    {
        public static List<Section> Sections = new List<Section>
        {
            new Section
            {
                ID = 1,
                Name = "Adjective"
            },
            new Section
            {
                ID = 2,
                Name = "Computer object"
            },
            new Section
            {
                ID = 3,
                Name = "Interjection"
            }
        };

        public static List<Word> Words = new List<Word>
        {
            new Word
            {
                Name="Fancy",
                Definition="of extra high quality or exceptional appeal",
                SectionID = 1
            },
            new Word
            {
                Name="Hello",
                Definition="Formal and informal farewell",
                SectionID = 3
            },
            new Word
            {
                Name="Mouse",
                Definition="External device for computers",
                SectionID = 2
            },
            new Word
            {
                Name="Window",
                Definition="Building artifact used to let light pass",
                SectionID = 2
            },
            new Word
            {
                Name="Ugly",
                Definition="Very unattractive or displeasing in appearance",
                SectionID = 1
            },
            new Word
            {
                Name="Screen",
                Definition="Device for seeing most of the CPU output",
                SectionID = 2
            }
        };
    }
}
