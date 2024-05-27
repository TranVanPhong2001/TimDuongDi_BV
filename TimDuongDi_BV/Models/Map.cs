using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace TimDuongDi_BV.Models
{
    public partial class Map : DbContext
    {
        public Map()
            : base("name=Map")
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<DuongDi> DuongDis { get; set; }
        public virtual DbSet<Tang> Tangs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>()
                .Property(e => e.username)
                .IsFixedLength();

            modelBuilder.Entity<Admin>()
                .Property(e => e.password)
                .IsFixedLength();
        }
    }
}
