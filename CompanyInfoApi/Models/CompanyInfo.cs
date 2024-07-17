
using System.ComponentModel.DataAnnotations;

namespace CompanyInfoApi.Models
{
    public class CompanyInfo
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string CompanyName { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 8)]
        public string CompanyNumber { get; set; }

        public string Address { get; set; }
        public DateTime RetrievedAt { get; set; }
    }
}
