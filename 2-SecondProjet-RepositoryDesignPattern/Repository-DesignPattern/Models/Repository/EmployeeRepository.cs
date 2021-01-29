using Repository_DesignPattern.Models.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository_DesignPattern.Models.Repository
{
    public class EmployeeRepository : IServiceRepository<Employee>
    {
        private readonly ApplicationDbContext db;

        public EmployeeRepository(ApplicationDbContext _db)
        {
            db = _db;
        }

        public void Add(Employee model)
        {
            db.Employees.Add(model);
            db.SaveChanges();
        }

        public Employee Delete(int id)
        {
            var emp = FindById(id);
            if(emp != null)
            {
                db.Employees.Remove(emp);
                db.SaveChanges();
            }
            return emp;
        }

        public Employee FindById(int id)
        {
            return db.Employees.Find(id);
        }

        public IEnumerable<Employee> GetAll()
        {
            return db.Employees.ToList();
        }

        public IEnumerable<Employee> Search(string term)
        {
            return db.Employees.Where(m => m.Name.Contains(term)).ToList();
        }

        public void Update(Employee model)
        {
            db.Employees.Update(model);
            db.SaveChanges();
        }
    }
}
