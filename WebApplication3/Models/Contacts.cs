using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace WebApplication3.Models
{
    [Table("Contact")]
    public class Contacts
    {
        [Key]
        public int ContactId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Comment { get; set; }
    }
}