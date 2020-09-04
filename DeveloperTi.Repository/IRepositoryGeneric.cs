using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DeveloperTi.Repository
{
    public interface IRepositoryGeneric<TEntidade, TChave> where TEntidade : class
    {
        IEnumerable<TEntidade> GetAll(Expression<Func<TEntidade, bool>> where = null);
        TEntidade GetById(TChave id);
        void Update(TEntidade entidade);
        void Insert(TEntidade entidade);
        void Delete(TEntidade entidade);
        void DeleteById(TChave id);
    }
}
