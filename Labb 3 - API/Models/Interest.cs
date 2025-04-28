namespace Labb_3___API.Models
{
    public class Interest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Link> Links { get; set; }
        public ICollection<MtmInterest> PersonInterests { get; set; }

    }
}
