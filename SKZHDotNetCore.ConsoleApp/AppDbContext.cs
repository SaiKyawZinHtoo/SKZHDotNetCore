using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using SKZHDotNetCore.ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKZHDotNetCore.ConsoleApp
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                string connectionString = "Data Source=DESKTOP-MVSU0HC;Initial Catalog=SKZHDotNet;User ID=sa;Password=sasa@123;TrustServerCertificate=True;";
                optionsBuilder.UseSqlServer(connectionString);
            }

        }

        public DbSet<BlogDataModel> Blogs { get; set; }
    }
}
