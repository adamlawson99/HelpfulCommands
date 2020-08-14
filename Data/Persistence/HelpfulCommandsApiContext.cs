using HelpfulCommands.Controllers;
using HelpfulCommands.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpfulCommands.Data.Persistence
{
    public class HelpfulCommandsApiContext : DbContext
    {
        public HelpfulCommandsApiContext(DbContextOptions<HelpfulCommandsApiContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Platform>()
                .HasMany(p => p.Categories)
                .WithOne(p => p.Platform)
                .HasForeignKey(p => p.PlatformId)
                .HasPrincipalKey(p => p.Id);
        }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}
