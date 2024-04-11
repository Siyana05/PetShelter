using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShelterMVC.Controllers
{
    public class BreedController : BaseCrudController<BreedDto, IBreedRepository, IBreedService, BreedEditVM, BreedDetailsVM>
    {
        public BreedController(IBreedsService service, IMapper mapper) : base(service, mapper)
        {

        }
    }
    public class LocationController : BaseCrudController<LocationDto, ILocationRepository, ILocationService, LocationEditVM, LocationDetailsVM>
    {
        public LocationController(ILocationService service, IMapper mapper) : base(service, mapper)
        {

        }
    }
}
