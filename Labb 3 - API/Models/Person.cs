using System.ComponentModel.DataAnnotations;

namespace Labb_3___API.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        public string Phone { get; set; }
        public ICollection<MtmInterest> MtmInterest { get; set; }


        // public ICollection<Link> Links { get; set; }
    }
}
