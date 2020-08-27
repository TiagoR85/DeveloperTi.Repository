using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DeveloperTi.Repository
{
    public abstract class RepositorioGenerico<TEntidade, TChave> : IRepositoryGeneric<TEntidade, TChave> where TEntidade : class
    {
        private readonly DataContext.EntityFramework.DataContext context;

        public RepositorioGenerico(DataContext.EntityFramework.DataContext context)
        {
            this.context = context;
        }

        public void Delete(TEntidade entidade)
        {
            context.Entry(entidade).State = EntityState.Deleted;
        }

        public async Task DeleteById(TChave id)
        {
            TEntidade entidade = await GetById(id);
            Delete(entidade);
        }

        public async Task<TEntidade> GetById(TChave id)
        {
            return await context.Set<TEntidade>().FindAsync(id);
        }

        public void Insert(TEntidade entidade)
        {
            context.Set<TEntidade>().Add(entidade);
        }

        public void Update(TEntidade entidade)
        {
            context.Entry(entidade).State = EntityState.Modified;
        }

        public async Task<IEnumerable<TEntidade>> GetAll(Expression<Func<TEntidade, bool>> where = null)
        {
            return where != null ? await context.Set<TEntidade>().Where(where).ToListAsync()
                                 : await context.Set<TEntidade>().ToListAsync();
        }
    }
}
