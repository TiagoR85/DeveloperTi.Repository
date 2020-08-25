using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DeveloperTi.Repository.EntityFramework
{
    public abstract class RepositoryGenericoEntity<TEntidade, TChave> : IRepositoryGeneric<TEntidade, TChave>
        where TEntidade : class
    {
        private DbContext context;
        public RepositoryGenericoEntity(DbContext context)
        {
            this.context = context;
        }

        public async Task Delete(TEntidade entidade)
        {
            context.Entry(entidade).State = EntityState.Deleted;
            await SaveChanges();
        }

        public async Task DeleteById(TChave id)
        {
            TEntidade entidade = await GetById(id);
            await Delete(entidade);
        }

        public async Task<TEntidade> GetById(TChave id)
        {
            return await context.Set<TEntidade>().FindAsync(id);
        }

        public async Task Insert(TEntidade entidade)
        {
            context.Set<TEntidade>().Add(entidade);
            await SaveChanges();
        }

        public async Task Update(TEntidade entidade)
        {
            context.Entry(entidade).State = EntityState.Modified;
            await SaveChanges();
        }

        public async Task SaveChanges()
        {
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntidade>> GetAll(Expression<Func<TEntidade, bool>> where = null)
        {
            return where != null ? await context.Set<TEntidade>().Where(where).ToListAsync()
                                 : await context.Set<TEntidade>().ToListAsync();
        }
    }
}
