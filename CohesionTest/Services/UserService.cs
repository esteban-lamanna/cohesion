using CohesionTest.Models.Entities;
using CohesionTest.Repository;
using System;
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

        public async Task<User> GetByIdAsync(Guid idUser)
        {
            return await _userRepository.GetByIdAsync(idUser);
        }
    }
}