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
        private readonly DataContext context;

        public RepositoryGenericoEntity(DataContext context)
        {
            this.context = context;
        }

        
    }
}
