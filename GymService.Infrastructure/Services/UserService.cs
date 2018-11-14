using AutoMapper;
using GymService.Core.Entities;
using GymService.Core.Repositories;
using GymService.Infrastructure.DTO;
using GymService.Infrastructure.Services.Repositories;
using GymService.Infrastructure.Services.Repositories.Passenger.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GymService.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        private readonly IEncrypter _encrypter;

        public UserService(IUserRepository userRepository, IEncrypter encrypter, IMapper mapper)
        {
            _repository = userRepository;
            _encrypter = encrypter;
            _mapper = mapper;
        }

        public Task<IEnumerable<UserDto>> BrowseAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<UserDto> GetAsync(string email)
        {
            User user = await _repository.GetAsync(email);

            return _mapper.Map<User, UserDto>(user);
        }

        public Task LoginAsync(string email, string password)
        {
            throw new NotImplementedException();
        }

        public Task RegisterAsync(Guid userId, string email, string username, string password, string role)
        {
            throw new NotImplementedException();
        }
    }
}
