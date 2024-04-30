using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShelterMVC.Controllers
{
    public class ShelterController
    {
        [Authorize(AuthenticationSchemes = CookieAuthenticationfaults.AuthenticationScheme, Roles = "Admin, Employee")]
        public class ShelterController : BaseCrudController<ShelterDto, IShelterRepository, IShelterService, ShelterEditVM, ShelterDetailsVM>
        {
            public ShelterController(IShelterService service, IMapper mapper) : base(service, mapper)
            {

            }
        }
    }
}
