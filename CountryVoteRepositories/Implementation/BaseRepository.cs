using CountryVoteDataBaseContext;
using Microsoft.EntityFrameworkCore;
using CountryVoteRepositories.Interfaces;
using System.Linq.Expressions;
using CountryVoteModels.DBModel;

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

        public async Task<T> Update(T entity)
        {
            this.countryVoteDbcontext.Set<T>().Update(entity);
            countryVoteDbcontext.Entry(entity).State = EntityState.Modified;
            await this.countryVoteDbcontext.SaveChangesAsync();
            return entity;
        }

    
    }
}
