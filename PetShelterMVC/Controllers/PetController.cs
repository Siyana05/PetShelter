using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShelterMVC.Controllers
{
    public class PetController
    {
        [Authorize(AuthenticationSchemes = CookieAuthenticationfaults.AuthenticationScheme, Roles = "Admin, Employee")]
        public class PetController : BaseCrudController<PetDto, IPetRepository, IPetService, PetEditVM, PetDetailsVM>
        {
            public PetController(IPetService service, IMapper mapper) : base(service, mapper)
            {

            }
        }
    }
}
