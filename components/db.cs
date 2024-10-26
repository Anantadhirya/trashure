using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trashure.components
{
    internal class TrashureContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Item> Items { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql("User Id=postgres.gszmytwpftrcwyqopwly;Password=ramahitam123;Server=aws-0-ap-southeast-1.pooler.supabase.com;Port=5432;Database=postgres;");
        }
    }
}
