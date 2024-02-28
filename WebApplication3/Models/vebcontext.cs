using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models
{
	public class vebcontext : DbContext
	{
		public DbSet<Goodss> Goods { get; set; } = null!;
        public DbSet<userss> users { get; set; } = null!;
        public DbSet<Contacts> Contact { get; set; } = null!;
        public DbSet<Carts> Cart { get; set; } = null!;
        public vebcontext(DbContextOptions options) : base(options) { }
	}
}



