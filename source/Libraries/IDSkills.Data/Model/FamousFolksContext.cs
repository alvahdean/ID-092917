using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace IDSkills.Data
{
    public class FamousFolksContext: DbContext
    {
        public FamousFolksContext(DbContextOptions<FamousFolksContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public virtual DbSet<Folk> Folks { get; set; }
        public virtual DbSet<FolkField> FolkFields { get; set; }
    }
}
