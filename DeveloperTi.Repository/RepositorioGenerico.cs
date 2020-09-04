using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

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

        public void DeleteById(TChave id)
        {
            TEntidade entidade = GetById(id);
            Delete(entidade);
        }

        public TEntidade GetById(TChave id)
        {
            return context.Set<TEntidade>().Find(id);
        }

        public void Insert(TEntidade entidade)
        {
            context.Set<TEntidade>().Add(entidade);
        }

        public void Update(TEntidade entidade)
        {
            context.Entry(entidade).State = EntityState.Modified;
        }

        public IEnumerable<TEntidade> GetAll(Expression<Func<TEntidade, bool>> where = null)
        {
            return where != null ? context.Set<TEntidade>().Where(where).ToList()
                                 : context.Set<TEntidade>().ToList();
        }
    }
}
