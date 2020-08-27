using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DeveloperTi.Repository
{
    public interface IRepositoryGeneric<TEntidade, TChave> where TEntidade : class
    {
        Task<IEnumerable<TEntidade>> GetAll(Expression<Func<TEntidade, bool>> where = null);
        Task<TEntidade> GetById(TChave id);
        void Update(TEntidade entidade);
        void Insert(TEntidade entidade);
        void Delete(TEntidade entidade);
        Task DeleteById(TChave id);
    }
}
