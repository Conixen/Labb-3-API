using System.ComponentModel.DataAnnotations;

namespace Labb_3___API.Models
{
    public class Interest
    {
        [Key]
        public int Id { get; set; }
        public string IntrestName { get; set; }
        public string Description { get; set; }
        public ICollection<MtmInterest> MtmInterest { get; set; }

        //public ICollection<Link> Links { get; set; }
    }
}
