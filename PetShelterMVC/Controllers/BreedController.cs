using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShelterMVC.Controllers
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationfaults.AuthenticationScheme, Roles = "Admin, Employee")]
    public class BreedController : BaseCrudController<BreedDto, IBreedRepository, IBreedService, BreedEditVM, BreedDetailsVM>
    {
        public BreedController(IBreedsService service, IMapper mapper) : base(service, mapper)
        {

        }
    }
}
