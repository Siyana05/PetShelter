using PetShelter.Shared.Attributes;
using PetShelter.Shared.Dtos;
using PetShelter.Shared.Repos.Contracts;
using PetShelter.Shared.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShelter.Services
{
     [AutoBind]
    public class UserService : BaseCrudService<UserDto, IUserRepository>, IUserService
    {
        
        public UserService(IUserRepository repository) : base(repository)
        {

        }

        public Task<bool> CanUserLoginAsync(string username, string password)
        {
            return _repository.CanUserLoginAsync(username, password);
        }

        public Task<UserDto> GetByUsernameAsync(string username)
        {
            return _repository.GetByUsernameAsync(username);
        }
    }
}
