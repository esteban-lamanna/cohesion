using CohesionTest.Models.Entities;
using CohesionTest.Repository.TestData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CohesionTest.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IList<User> _users = new List<User>();

        public UserRepository()
        {
            _users.Add(MockData.UserJohn);
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            //suposing there is always a long delay accessing data
            return await Task.Run(() =>
            {
                return _users.FirstOrDefault(a => a.Id == id);
            });
        }
    }
}