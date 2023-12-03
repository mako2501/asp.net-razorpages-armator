using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPagesArmator.Models;

namespace RazorPagesArmator.Data
{
    public class RazorPagesArmatorContext : DbContext
    {
        public RazorPagesArmatorContext (DbContextOptions<RazorPagesArmatorContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesArmator.Models.Ship> Ship { get; set; } = default!;

        public DbSet<RazorPagesArmator.Models.Port> Port { get; set; } = default!;
    }
}
