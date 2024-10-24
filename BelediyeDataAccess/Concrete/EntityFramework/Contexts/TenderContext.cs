


using BelediyeCore.Entities.Concrete;
using BelediyeEntities;
using BelediyeEntities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.Configuration;


namespace BelediyeDataAccess.Concrete.EntityFramework.Contexts;

public class TenderContext:DbContext
{

    public TenderContext(DbContextOptions<TenderContext> options) : base(options)
    {

    }
    public TenderContext() :base()
    {

    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = configuration.GetConnectionString("ConnectionContext");
        optionsBuilder.UseSqlServer(connectionString);
    }

    public DbSet<Tender> Tenders { get; set; }
    public DbSet<TenderType> TenderTypes { get; set; }
    public DbSet<Unit> Units { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<OperationClaim> OperationClaim { get; set; }
    public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

    public DbSet<Logs> Logs { get; set; }




}
