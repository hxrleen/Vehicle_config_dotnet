using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehicleConfiguration02;
using VehicleConfigurator02.DbRepos;

namespace VehicleConfiguration02
{

        public class UserRepositoryImpl : IUserRepository
        {
            private readonly IUserRepository _userRepository;

            public UserRepositoryImpl(IUserRepository userRepository)
            {
                _userRepository = userRepository;
            }

            public async Task<bool> CreateUser(User user)
            {
                // Implement the logic to create user
                await _userRepository.CreateUser(user);
                return true;
            }

            public async Task<bool> ValidateUser(string username, string password)
            {
                // Implement the logic to validate user
                return await _userRepository.ValidateUser(username, password);
            }
        }
    }
