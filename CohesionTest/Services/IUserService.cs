using CohesionTest.Models.Entities;
using System;
using System.Threading.Tasks;

namespace CohesionTest.Services
{
    public interface IUserService
    {
        Task<User> GetByIdAsync(Guid idUser);
    }
}