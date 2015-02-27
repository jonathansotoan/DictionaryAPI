using Dictionary.Model;
using System.Collections.Generic;

namespace Dictionary.DataAccess
{
    public class DictionaryInitializer : System.Data.Entity.DropCreateDatabaseAlways<DictionaryContext>
    {
        protected override void Seed(DictionaryContext context)
        {

            var sections = new List<Section>
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
            sections.ForEach(section => context.Sections.Add(section));
            context.SaveChanges();

            var words = new List<Word>
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
            words.ForEach(word => context.Words.Add(word));
            context.SaveChanges();
        }
    }
}
