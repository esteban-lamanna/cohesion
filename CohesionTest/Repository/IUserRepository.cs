using CohesionTest.Models.Entities;
using System;
using System.Threading.Tasks;

namespace CohesionTest.Repository
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(Guid id);
    }
}