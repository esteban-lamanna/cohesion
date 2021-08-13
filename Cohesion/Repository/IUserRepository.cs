using CohesionTest.Models.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CohesionTest.Repository
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(Guid id);
        Task<IEnumerable<User>> GetAllAsync();
    }
}