using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository_DesignPattern.Models.Repository.IRepository
{
    public interface IServiceRepository<TEntity>
    {
        public void Add(TEntity model);
        public void Update(TEntity model);
        public TEntity Delete(int id);
        public IEnumerable<TEntity> GetAll();
        public TEntity FindById(int id);

        // La methode de la Recherche
        public IEnumerable<TEntity> Search(string term);
    }
}
