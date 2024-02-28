using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace WebApplication3.Models
{
	[Table("Goods")]
	public class Goodss
	{
		[Key]
		public int goodid { get; set; }
		public string name { get; set; } = "";
		public int price { get; set; }
		public int discout { get; set; }
		public string info { get; set; } = "";
		public string miniinfo { get; set; } = "";
		public string foto1 { get; set; } = "";
		public string foto2 { get; set; } = "";
		public string foto3 { get; set; } = "";
	}

    [Table("users")]
    public class userss
    {
        [Key]
        public int usersID { get; set; }
        public string name { get; set; } = "";
        public string password { get; set; } = "";
        public string email { get; set; } = "";
        
    }
}


