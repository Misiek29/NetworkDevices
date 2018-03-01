namespace wpfNetworkDevices
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=CodeFirst")
        {
        }

        public virtual DbSet<Device> Devices { get; set; }
        public virtual DbSet<Config> Configs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Device>()
                .HasOptional(e => e.Config)
                .WithRequired(e => e.Device);
        }
    }
}
