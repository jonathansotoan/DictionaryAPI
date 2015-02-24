using Dictionary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.DataAccess
{
    public class DictionaryInitializer : System.Data.Entity.DropCreateDatabaseAlways<DictionaryContext>
    {
        protected override void Seed(DictionaryContext context)
        {

            //context.Sections.Add(new Section
            //{
            //    //ID = 1,
            //    Name = "Adjectives"
            //});
            //context.SaveChanges();

            var words = new List<Word>
            {
                new Word
                {
                    Name="Window",
                    Definition="Building artifact used to let light pass"
                },
                new Word
                {
                    Name="Hello",
                    Definition="Formal and informal farewell"
                },
                new Word
                {
                    Name="Fancy",
                    Definition="of extra high quality or exceptional appeal"
                },
                new Word
                {
                    Name="Mouse",
                    Definition="External device for computers"
                }
            };
            words.ForEach(word => context.Words.Add(word));
            context.SaveChanges();
        }
    }
}
