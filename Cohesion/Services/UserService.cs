using CohesionTest.Models.Entities;
using CohesionTest.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CohesionTest.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User> GetByIdAsync(Guid idUser)
        {
            return await _userRepository.GetByIdAsync(idUser);
        }
    }
}