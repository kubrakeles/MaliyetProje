using System.Linq.Expressions;
using MaliyetCore.Entities;
using MaliyetCore.Specification;
using Microsoft.EntityFrameworkCore;
using MaliyetDataAccess.Data;

namespace MaliyetCore.DataAccess.EntityFramework
{

    public class EFEntityRepositoryBase<Tentity, TContext> : IEntityRepository<Tentity>
    where Tentity : class, IEntity, new()
    where TContext : DbContext, new()
    {
        public void Add(Tentity entity)
        {
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Tentity Entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(Entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Tentity Get(Expression<Func<Tentity, bool>> filter)
        {
            using (var context = new TContext())
            {

                return context.Set<Tentity>().SingleOrDefault(filter);
            }
        }

        public IList<Tentity> GetList(Expression<Func<Tentity, bool>> filter=null)
        {
            using (var context = new TContext())
            {
                return filter == null ?
                context.Set<Tentity>().ToList() :
                context.Set<Tentity>().Where(filter).ToList();
            }
        }
        public async Task<IReadOnlyList<Tentity>> GetListWithSpec(ISpecification<Tentity> spec)
        {   using (var context = new TContext()) 
            { 
            return await ApplySpecification(spec,context).ToListAsync();
            }
        }
        public void Update(Tentity Entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(Entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        private IQueryable<Tentity> ApplySpecification(ISpecification<Tentity> spec,TContext context)
        {    
             return SpecificationEvulator<Tentity>.GetQuery(context.Set<Tentity>().AsQueryable(), spec); 
        }
    }
}