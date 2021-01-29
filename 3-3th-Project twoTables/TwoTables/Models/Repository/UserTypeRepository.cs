using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwoTables.Models.Repository.IRepository;

namespace TwoTables.Models.Repository
{
    public class UserTypeRepository : IUserTypeRepository<UserType>
    {
        private readonly ApplicationDbContext db;

        public UserTypeRepository(ApplicationDbContext _db)
        {
            this.db = _db;
        }
        public IEnumerable<UserType> List()
        {
            return db.UserTypes.ToList();
        }
    }
}
