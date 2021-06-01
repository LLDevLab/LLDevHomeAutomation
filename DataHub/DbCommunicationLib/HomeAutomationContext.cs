using DbCommunicationLib.Model;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DbCommunicationLib
{
    public partial class HomeAutomationContext : DbContext
    {
        public virtual DbSet<Chart> Charts { get; set; }
        public virtual DbSet<ChartSensorGroupsMapping> ChartSensorGroupsMappings { get; set; }
        public virtual DbSet<MeasurementUnit> MeasurementUnits { get; set; }
        public virtual DbSet<Sensor> Sensors { get; set; }
        public virtual DbSet<SensorEvent> SensorEvents { get; set; }
        public virtual DbSet<SensorGroup> SensorGroups { get; set; }
        public virtual DbSet<SensorsDataView> SensorsDataViews { get; set; }

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

            modelBuilder.Entity<ChartSensorGroupsMapping>(entity =>
            {
                entity.HasKey(e => new { e.ChartId, e.SensorGroupId })
                    .HasName("ChartSensorGroupsMapping_pkey");

                entity.ToTable("ChartSensorGroupsMapping");

                entity.HasIndex(e => e.ChartId, "fki_fki_ChartSensorGroupsMapping_Charts_fk");

                entity.HasIndex(e => e.SensorGroupId, "fki_fki_ChartSensorGroupsMapping_SensorGroups_fk");

                entity.HasOne(d => d.Chart)
                    .WithMany(p => p.ChartSensorGroupsMappings)
                    .HasForeignKey(d => d.ChartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fki_ChartSensorGroupsMapping_Charts_fk");

                entity.HasOne(d => d.SensorGroup)
                    .WithMany(p => p.ChartSensorGroupsMappings)
                    .HasForeignKey(d => d.SensorGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fki_ChartSensorGroupsMapping_SensorGroups_fk");
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

                entity.HasIndex(e => e.SensorGroupId, "fki_Sensors_SensorGroups_fk");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.HasOne(d => d.SensorGroup)
                    .WithMany(p => p.Sensors)
                    .HasForeignKey(d => d.SensorGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Sensors_SensorGroups_fk");
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

            modelBuilder.Entity<SensorGroup>(entity =>
            {
                entity.HasIndex(e => e.Name, "SensorGroups_Name_Idx")
                    .IsUnique();

                entity.HasIndex(e => e.UnitId, "fki_SensorGroups_MeasumementUnits_fk");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.SensorGroups)
                    .HasForeignKey(d => d.UnitId)
                    .HasConstraintName("SensorGroups_MeasumementUnits_fk");
            });

            modelBuilder.Entity<SensorsDataView>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SensorsDataView");

                entity.Property(e => e.Name).HasMaxLength(25);

                entity.Property(e => e.SensorGroupName).HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
