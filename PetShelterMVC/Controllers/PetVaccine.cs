using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShelterMVC.Controllers
{
    public class PetVaccine
    {
        [Authorize(AuthenticationSchemes = CookieAuthenticationfaults.AuthenticationScheme, Roles = "Admin, Employee")]
        public class PetVaccineController : BaseCrudController<PetVaccineDto, IPetVaccineRepository, IPetVaccineService, PetVaccineEditVM, PetVaccineDetailsVM>
        {
            public PetVaccineController(IPetVaccineService service, IMapper mapper) : base(service, mapper)
            {

            }
        }
    }
}
