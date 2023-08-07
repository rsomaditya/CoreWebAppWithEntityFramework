using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreWebAppWithEF.Models
{    
    [Table("Candidate")]
    public class Candidate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int metaid { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime metadate { get; set; }
        [Required]
        [MaxLength(100)]
        public string candidatename { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public string dateofbirth { get; set; }
        public string gender { get; set; }
        [Required]
        public string AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        [Required]
        public int Zip { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Country { get; set; }
        public string streamid { get; set; }
    }
}
