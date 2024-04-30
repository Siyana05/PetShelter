using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShelterMVC.Controllers
{
    public class VaccineController
    {
        [Authorize(AuthenticationSchemes = CookieAuthenticationfaults.AuthenticationScheme, Roles = "Admin, Employee")]
        public class VaccineController : BaseCrudController<VaccineDto, IVaccineRepository, IVaccineService, VaccineEditVM, VaccineDetailsVM>
        {
            public VaccineController(IVaccineService service, IMapper mapper) : base(service, mapper)
            {

            }
        }
    }
}
