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
        public DbSet<Word> Words { get; set; }
        public DbSet<Section> Sections { get; set; }

        // For removing conventions
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        //}
    }
}
