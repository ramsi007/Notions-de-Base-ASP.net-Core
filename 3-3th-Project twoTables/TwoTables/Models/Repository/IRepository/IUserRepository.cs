using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TwoTables.Models.Repository.IRepository
{
    public interface IUserRepository<TEntity>
    {
        public IEnumerable<TEntity> List();
        public TEntity Find(int id);
        public void Add(TEntity entity);
        public void Edit(TEntity entity);
        public void Delete(TEntity entity);
        public TEntity Login(TEntity entity);
        public IEnumerable<TEntity> Search(string term);
    }
}
