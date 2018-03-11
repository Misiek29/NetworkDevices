namespace wpfNetworkDevices
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model12")
        {
        }

        public virtual DbSet<Device> Devices { get; set; }
        public virtual DbSet<Config> Configs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<Model1>(null);
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Device>()
                .HasMany(e => e.Configs)
                .WithOptional(e => e.Device)
                .HasForeignKey(e => e.id_device);

            modelBuilder.Entity<Config>()
                .Property(e => e.ip)
                .IsUnicode(false);

            modelBuilder.Entity<Config>()
                .Property(e => e.mask)
                .IsUnicode(false);

            modelBuilder.Entity<Config>()
                .Property(e => e.Gateway)
                .IsUnicode(false);

            modelBuilder.Entity<Config>()
                .Property(e => e.DNS)
                .IsUnicode(false);
        }
    }
}
