using BelediyeCore.Entities.Concrete;
using BelediyeEntities;
using BelediyeEntities.Concrete.AbbUlasim;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.Configuration;

namespace BelediyeDataAccess.Concrete.EntityFramework.Contexts;

public class UlasimContext:DbContext
{
       public UlasimContext(Microsoft.EntityFrameworkCore.DbContextOptions<UlasimContext> options) : base(options)
    {

    }
    public UlasimContext() :base()
    {
        
    }

     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = configuration.GetConnectionString("UlasimConnection");
        optionsBuilder.UseSqlServer(connectionString);
    }
     public DbSet<Bus> Buses { get; set; }
    public DbSet<BusStop> BusStops { get; set; }
    public DbSet<Point> Points { get; set; }
    public DbSet<Stop> Stops { get; set; }
    public DbSet<StopBusTime> StopBusTimes { get; set; }
    public DbSet<StopBusTimeBackup> StopBusTimeBackups { get; set; }
    public DbSet<TimeBackUp> TimeBackups { get; set; }
    public DbSet<TimeBackUpBus> TimeBackupBuses { get; set; }
     protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // BusRoute - Stop (many-to-many relationship)
        modelBuilder.Entity<Bus>()
            .HasMany(br => br.BusStops)
            .WithOne(bs => bs.Bus)
            .HasForeignKey(bs => bs.BusId)
            .OnDelete(DeleteBehavior.Restrict);

        // StopBusTime - Bus & Stop
        modelBuilder.Entity<StopBusTime>()
            .HasOne(sbt => sbt.Bus)
            .WithMany()
            .HasForeignKey(sbt => sbt.BusId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<StopBusTime>()
            .HasOne(sbt => sbt.Stop)
            .WithMany()
            .HasForeignKey(sbt => sbt.StopId)
            .OnDelete(DeleteBehavior.Restrict);

        // StopBusTimeBackup - Bus & Stop & TimeBackup
        modelBuilder.Entity<StopBusTimeBackup>()
            .HasOne(sbtb => sbtb.Bus)
            .WithMany()
            .HasForeignKey(sbtb => sbtb.BusId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<StopBusTimeBackup>()
            .HasOne(sbtb => sbtb.Stop)
            .WithMany()
            .HasForeignKey(sbtb => sbtb.StopId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<StopBusTimeBackup>()
            .HasOne(sbtb => sbtb.TimeBackup)
            .WithMany()
            .HasForeignKey(sbtb => sbtb.TimeBackupId)
            .OnDelete(DeleteBehavior.Restrict);

        // TimeBackupBu - Bus & TimeBackup
        modelBuilder.Entity<TimeBackUpBus>()
            .HasOne(tbb => tbb.Bus)
            .WithMany()
            .HasForeignKey(tbb => tbb.BusId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<TimeBackUpBus>()
            .HasOne(tbb => tbb.TimeBackup)
            .WithMany()
            .HasForeignKey(tbb => tbb.TimeBackupId)
            .OnDelete(DeleteBehavior.Restrict);

        // TimeBackup - StopBusTimeBackup & TimeBackupBu
        modelBuilder.Entity<TimeBackUp>()
            .HasMany(tb => tb.StopBusTimeBackups)
            .WithOne(sbtb => sbtb.TimeBackup)
            .HasForeignKey(sbtb => sbtb.TimeBackupId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<TimeBackUp>()
            .HasMany(tb => tb.TimeBackupBus)
            .WithOne(tbb => tbb.TimeBackup)
            .HasForeignKey(tbb => tbb.TimeBackupId)
            .OnDelete(DeleteBehavior.Restrict);

        // Point - Bus (many-to-one relationship)
        modelBuilder.Entity<Point>()
            .HasOne(p => p.Bus)
            .WithMany()
            .HasForeignKey(p => p.BusId)
            .OnDelete(DeleteBehavior.Restrict);

        // Stop - Bus (many-to-many relationship for Buses)
        modelBuilder.Entity<Bus>()
            .HasOne(b => b.FirstStop)
            .WithMany()
            .HasForeignKey(b => b.FirstStopId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Bus>()
            .HasOne(b => b.LastStop)
            .WithMany()
            .HasForeignKey(b => b.LastStopId)
            .OnDelete(DeleteBehavior.Restrict);

        base.OnModelCreating(modelBuilder);
    }

}
