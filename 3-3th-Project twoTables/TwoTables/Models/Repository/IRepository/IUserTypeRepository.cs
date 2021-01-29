using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TwoTables.Models.Repository.IRepository
{
    public interface IUserTypeRepository<TEntity>
    {
        public IEnumerable<TEntity> List();
    }
}
