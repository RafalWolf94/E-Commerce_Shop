using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly StoreContext Context;

        public GenericRepository(StoreContext context)
        {
            Context = context;
        }

        public async Task<T> GetByIdAsync(int id) => await Context.Set<T>().FindAsync(id);
        public async Task<IReadOnlyList<T>> ListAllAsync() => await Context.Set<T>().ToListAsync();
        public async Task<T> GetEntityWithSpec(ISpecification<T> spec) => await ApplySpecification(spec).FirstOrDefaultAsync();
        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec) => await ApplySpecification(spec).ToListAsync();
        public async Task<int> CountAsync(ISpecification<T> spec) => await ApplySpecification(spec).CountAsync();

        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(Context.Set<T>().AsQueryable(), spec);
        }
    }
}