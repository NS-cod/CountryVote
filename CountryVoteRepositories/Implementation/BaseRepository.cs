using CountryVoteDataBaseContext;
using Microsoft.EntityFrameworkCore;
using CountryVoteRepositories.Interfaces;
using System.Linq.Expressions;
using CountryVoteModels.DBModel;
using NPOI.SS.Formula.Functions;

namespace CountryVoteRepositories.Implementation
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
    {
        private readonly CountryVoteDbContext countryVoteDbcontext;

        public BaseRepository(CountryVoteDbContext entityAvanzadoDbContext)
        {
            this.countryVoteDbcontext = entityAvanzadoDbContext;
        }

        public  async Task<T> Add(T entity)
        {
            this.countryVoteDbcontext.Set<T>().Add(entity);
            countryVoteDbcontext.Entry(entity).State = EntityState.Added;
            await this.countryVoteDbcontext.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(T entity)
        {
            this.countryVoteDbcontext.Set<T>().Remove(entity);
            await this.countryVoteDbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<T> Get(int id)
        {
            var entidad = await this.countryVoteDbcontext.Set<T>().Where(a => a.ID == id).FirstOrDefaultAsync();

            return entidad;
        }

        public async Task<ICollection<T>> GetAll()
        {
            return await this.countryVoteDbcontext.Set<T>().ToListAsync();
        }

        public async Task<ICollection<T>> GetAll(Expression<Func<T, bool>> predicated)
        {
            return await this.countryVoteDbcontext.Set<T>().Where(predicated).ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicated = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<Expression<Func<T, object>>> includes = null, bool disabledTracking = true)
        {
            using var transaction = await countryVoteDbcontext.Database.BeginTransactionAsync();
            try
            {
                IQueryable<T> query = countryVoteDbcontext.Set<T>();

                if (disabledTracking) query = query.AsNoTracking();

                if (includes != null) query = includes.Aggregate(query, (current, include) => current.Include(include));

                if (predicated != null) query = query.Where(predicated);

                if (orderBy != null) return await orderBy(query).ToListAsync();

                return await query.ToListAsync();

            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }


        }

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicated = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeString = null, bool disabledTracking = true)
        {
            IQueryable<T> query = countryVoteDbcontext.Set<T>();

            if (disabledTracking) query = query.AsNoTracking();

            if (!string.IsNullOrEmpty(includeString)) query = query.Include(includeString);

            if (predicated != null) query = query.Where(predicated);

            if (orderBy != null ) return await orderBy(query).ToListAsync();

            return await query.ToListAsync();
        }

        public async Task<T> Update(T entity)
        {
            this.countryVoteDbcontext.Set<T>().Update(entity);
            countryVoteDbcontext.Entry(entity).State = EntityState.Modified;
            await this.countryVoteDbcontext.SaveChangesAsync();
            return entity;
        }

    
    }
}
