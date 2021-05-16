using DbCommunicationLib.Model;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DbCommunicationLib
{
    public partial class HomeAutomationContext : DbContext
    {
        public virtual DbSet<Chart> Charts { get; set; }
        public virtual DbSet<ChartSensorMap> ChartSensorMaps { get; set; }
        public virtual DbSet<MeasurementUnit> MeasurementUnits { get; set; }
        public virtual DbSet<Sensor> Sensors { get; set; }
        public virtual DbSet<SensorEvent> SensorEvents { get; set; }
        public virtual DbSet<SensorType> SensorTypes { get; set; }

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

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<ChartSensorMap>(entity =>
            {
                entity.HasKey(e => new { e.ChartId, e.SensorId })
                    .HasName("ChartSensorMap_pkey");

                entity.ToTable("ChartSensorMap");

                entity.HasIndex(e => e.ChartId, "fki_fki_ChartSensorMap_Charts_fk");

                entity.HasIndex(e => e.SensorId, "fki_fki_ChartSensorMap_Sensors_fk");

                entity.HasOne(d => d.Chart)
                    .WithMany(p => p.ChartSensorMaps)
                    .HasForeignKey(d => d.ChartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fki_ChartSensorMap_Charts_fk");

                entity.HasOne(d => d.Sensor)
                    .WithMany(p => p.ChartSensorMaps)
                    .HasForeignKey(d => d.SensorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fki_ChartSensorMap_Sensors_fk");
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

                entity.HasIndex(e => e.SensorType, "fki_Sensors_SensorTypes_fk");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.HasOne(d => d.SensorTypeNavigation)
                    .WithMany(p => p.Sensors)
                    .HasForeignKey(d => d.SensorType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Sensors_SensorTypes_fk");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.Sensors)
                    .HasForeignKey(d => d.UnitId)
                    .HasConstraintName("Sensors_MeasurementUnits_fk");
            });

            modelBuilder.Entity<SensorEvent>(entity =>
            {
                entity.HasIndex(e => new { e.SensorId, e.EventDateTime }, "SensorId_EventDateTime_Idx")
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

            modelBuilder.Entity<SensorType>(entity =>
            {
                entity.HasIndex(e => e.Name, "SensorTypes_Name_constraint")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(25);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
