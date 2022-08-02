


using MaliyetEntities;
using MaliyetEntities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace MaliyetDataAccess.Concrete.EntityFramework.Contexts;

public class TenderContext:DbContext
{
   protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
   {

   dbContextOptionsBuilder.UseSqlServer(connectionString:@"Server=(localdb)\\mssqllocaldb;Database=ABBTenderDB;Trusted_Connection=True;MultipleActiveResultSets=true;)");
   }
   public DbSet<Tender> Tenders { get; set; }
    public DbSet<TenderType> TenderTypes { get; set; }
    public DbSet<Unit> Units { get; set; }

}
