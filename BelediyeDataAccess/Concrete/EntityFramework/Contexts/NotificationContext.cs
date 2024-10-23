


using BelediyeCore.Entities.Concrete;
using BelediyeEntities;
using BelediyeEntities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.Configuration;


namespace BelediyeDataAccess.Concrete.EntityFramework.Contexts;

public class NotificationContext:DbContext
{

    public NotificationContext(DbContextOptions<NotificationContext> options) : base(options)
    {

    }
    public NotificationContext() :base()
    {

    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = configuration.GetConnectionString("NotificationContext");
        optionsBuilder.UseSqlServer(connectionString);
    }

 public DbSet<Notification> Notification { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<OperationClaim> OperationClaim { get; set; }
    public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

    public DbSet<Logs> Logs { get; set; }

}
