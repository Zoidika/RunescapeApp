using Microsoft.EntityFrameworkCore;

namespace RunescapeApp.Data
{
    public class RunescapeContext(DbContextOptions<RunescapeContext> options) : DbContext(options)
    {
        public DbSet<Equipment> Equipment {  get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Rarity> Rarities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Runescape");
            modelBuilder.Entity<Equipment>(eb =>
            {
                eb.ToTable("Equipment");
                eb.HasKey(k => k.EquipmentId);
                eb.Property(p => p.EquipmentId).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<Position>(eb =>
            {
                eb.ToTable("Position");
                eb.HasKey(k => k.PositionId);
                eb.Property(p => p.PositionId).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<Rarity>(eb =>
            {
                eb.ToTable("Rarity");
                eb.HasKey(k => k.RarityId);
                eb.Property(p => p.RarityId).ValueGeneratedOnAdd();
            });
        }
    }
}
