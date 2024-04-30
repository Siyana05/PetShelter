using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShelterMVC.Controllers
{
    public class PetTypeController
    {
        [Authorize(AuthenticationSchemes = CookieAuthenticationfaults.AuthenticationScheme, Roles = "Admin, Employee")]
        public class PetTypeController : BaseCrudController<PetTypeDto, IPetTypeRepository, IPeTypeService, PetTypeEditVM, PetTypeDetailsVM>
        {
            public PetTypeController(IPetTypeService service, IMapper mapper) : base(service, mapper)
            {

            }
        }
    }
}
