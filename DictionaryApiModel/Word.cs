namespace Dictionary.Model
{
    public class Word
    {
        // properties
        public int ID { get; set; }
        public string Name { get; set; }
        public string Definition { get; set; }

        // relationships (virtual keyword allows lazy loading)
        //public int SectionID { get; set; }

        //public virtual Section Section { get; set; }
    }
}