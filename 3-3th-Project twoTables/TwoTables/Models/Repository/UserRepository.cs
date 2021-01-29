using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwoTables.Models.Repository.IRepository;

namespace TwoTables.Models.Repository
{
    public class UserRepository : IUserRepository<User>
    {
        private readonly ApplicationDbContext db;

        public UserRepository(ApplicationDbContext _db)
        {
            this.db = _db;
        }
        public void Add(User entity)
        {
             db.Users.Add(entity);
            db.SaveChanges();
        }

        public void Delete(User entity)
        {
            db.Users.Remove(entity);
            db.SaveChanges();
        }

        public User Find(int id)
        {
            return db.Users.Include(m =>m.UserType).Where(m => m.UserId == id).SingleOrDefault();
        }

        public IEnumerable<User> List()
        {
            return db.Users.Include(m => m.UserType).ToList();
        }

        public void Edit(User entity)
        {
            db.Users.Update(entity);
            db.SaveChanges();
        }

        public User Login(User entity)
        {
            var user = db.Users.Where(u => u.UserName.Equals(entity.UserName) && u.Password.Equals(entity.Password))
                .SingleOrDefault();
                return user;
        }

        public IEnumerable<User> Search(string term)
        {
            return db.Users.Where(m =>m.FullName.Contains(term)).ToList();
        }
    }
}
