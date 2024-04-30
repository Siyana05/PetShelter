using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShelterMVC.Controllers
{
    public class RoleController
    {
        [Authorize(AuthenticationSchemes = CookieAuthenticationfaults.AuthenticationScheme, Roles = "Admin, Employee")]
        public class RoleController : BaseCrudController<RoleDto, IRoleRepository, IRoleService, RoleEditVM, RoleDetailsVM>
        {
            public RoleController(IRoleService service, IMapper mapper) : base(service, mapper)
            {

            }
        }
    }
}
