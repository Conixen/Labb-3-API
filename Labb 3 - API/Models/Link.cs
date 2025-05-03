using System.ComponentModel.DataAnnotations;

namespace Labb_3___API.Models
{
    public class Link
    {
        [Key]
        public int Id { get; set; }
        public string Url { get; set; }


        public int MtmInterestId { get; set; }
        public MtmInterest MtmInterest { get; set; }

    }
}
