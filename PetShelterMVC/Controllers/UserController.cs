using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShelterMVC.Controllers
{
    public class UserController
    {
        [Authorize(AuthenticationSchemes = CookieAuthenticationfaults.AuthenticationScheme, Roles = "Admin, Employee")]
        public class UserController : BaseCrudController<UserDto, IUserRepository, IUserService, UserEditVM, UserDetailsVM>
        {
            public UserController(IUserService service, IMapper mapper) : base(service, mapper)
            {

            }
        }
    }
}
