using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dictionary.Model;

namespace Dictionary.DataAccess
{
    public class DictionaryContext : DbContext
    {
        //public DbSet<Section> Sections { get; set; }
        public DbSet<Word> Words { get; set; }

        //public static void Main()
        //{
        //    using (DictionaryContext dictionaryContext = new DictionaryContext())
        //    {
        //        dictionaryContext.words.AddRange(new Word[]
        //    {
        //        new Word {
        //            name = "Fancy",
        //            definition = "of extra high quality or exceptional appeal"
        //        },
        //         new Word {
        //            name = "Hello",
        //            definition = "Formal and informal farewell"
        //        },
        //         new Word {
        //            name = "Mouse",
        //            definition = "External device for computers"
        //        },
        //         new Word {
        //            name = "Window",
        //            definition = "Building artifact used to let light pass"
        //        }
        //    };)
        //    }
        //}
    }
}
