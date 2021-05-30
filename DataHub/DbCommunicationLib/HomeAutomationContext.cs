using DbCommunicationLib.Model;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DbCommunicationLib
{
    public partial class HomeAutomationContext : DbContext
    {
        public virtual DbSet<Chart> Charts { get; set; }
        public virtual DbSet<ChartUnitMapping> ChartUnitMappings { get; set; }
        public virtual DbSet<MeasurementUnit> MeasurementUnits { get; set; }
        public virtual DbSet<Sensor> Sensors { get; set; }
        public virtual DbSet<SensorEvent> SensorEvents { get; set; }

        public HomeAutomationContext() : base()
        {
        }

        public HomeAutomationContext(DbContextOptions<HomeAutomationContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "en_US.UTF-8");

            modelBuilder.Entity<Chart>(entity =>
            {
                entity.HasIndex(e => e.Name, "Charts_Name_constraint")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<ChartUnitMapping>(entity =>
            {
                entity.HasKey(e => new { e.ChartId, e.UnitId })
                    .HasName("ChartUnitMapping_pkey");

                entity.ToTable("ChartUnitMapping");

                entity.HasIndex(e => e.ChartId, "fki_fki_ChartUnitMapping_Charts_fk");

                entity.HasIndex(e => e.UnitId, "fki_fki_ChartUnitMapping_MeasurementUnits_fk");

                entity.HasOne(d => d.Chart)
                    .WithMany(p => p.ChartUnitMappings)
                    .HasForeignKey(d => d.ChartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fki_ChartUnitMapping_Charts_fk");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.ChartUnitMappings)
                    .HasForeignKey(d => d.UnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fki_ChartUnitMapping_MeasurementUnits_fk");
            });

            modelBuilder.Entity<MeasurementUnit>(entity =>
            {
                entity.HasIndex(e => e.Unit, "MeasurementUnits_Unit_constraint")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Unit)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<Sensor>(entity =>
            {
                entity.HasIndex(e => e.Name, "Sensors_Name_constraint")
                    .IsUnique();

                entity.HasIndex(e => e.UnitId, "fki_Sensors_MeasurementUnits_fk");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.Sensors)
                    .HasForeignKey(d => d.UnitId)
                    .HasConstraintName("Sensors_MeasurementUnits_fk");
            });

            modelBuilder.Entity<SensorEvent>(entity =>
            {
                entity.HasIndex(e => new { e.SensorId, e.EventDateTime }, "SensorId_EventDateTime_Idx")
                    .IsUnique()
                    .HasNullSortOrder(new[] { NullSortOrder.NullsLast, NullSortOrder.NullsLast })
                    .HasSortOrder(new[] { SortOrder.Ascending, SortOrder.Descending });

                entity.HasIndex(e => e.SensorId, "fki_SensorEvents_Sensors_fk");

                entity.Property(e => e.EventDateTime).HasColumnType("timestamp with time zone");

                entity.HasOne(d => d.Sensor)
                    .WithMany(p => p.SensorEvents)
                    .HasForeignKey(d => d.SensorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SensorEvents_Sensors_fk");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
