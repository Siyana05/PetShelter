using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShelterMVC.Controllers
{
    public class LocationController
    {
        [Authorize(AuthenticationSchemes = CookieAuthenticationfaults.AuthenticationScheme, Roles = "Admin, Employee")]
        public class LocationController : BaseCrudController<LocationDto, ILocationRepository, ILocationService, LocationEditVM, LocationDetailsVM>
        {
            public LocationController(ILocationService service, IMapper mapper) : base(service, mapper)
            {

            }
        }
    }
}
