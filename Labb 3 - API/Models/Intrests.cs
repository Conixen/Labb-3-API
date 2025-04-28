namespace Labb_3___API.Models
{
    public class Intrests
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Intrests(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
        public Intrests()
        {

        }
    }
}
