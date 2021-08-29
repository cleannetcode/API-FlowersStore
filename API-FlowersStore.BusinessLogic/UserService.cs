using API_FlowersStore.Core.CoreModels;
using API_FlowersStore.Core.Repositories;
using API_FlowersStore.Core.Services;
using AutoMapper;
using System;
using System.Threading.Tasks;

namespace API_FlowersStore.BusinessLogic
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public Task<User[]> GetAll()
        {
            return _userRepository.GetAll();
        }

        public Task<User> GetById(int id)
        {
            if (id < 0)
                throw new ArgumentException(nameof(id));

            return _userRepository.GetById(id);
        }

        public Task<User> GetByNameAndPassword(string name, string password)
        {
            if (String.IsNullOrEmpty(name))
                throw new ArgumentException(nameof(name));

            if (String.IsNullOrEmpty(password))
                throw new ArgumentException(nameof(password));

            return _userRepository.GetByNameAndPassword(name, password);
        }
    }
}
