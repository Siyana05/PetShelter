using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using PetShelter.Shared.Dtos;
using PetShelter.Shared.Repos.Contracts;
using PetShelter.Shared.Services.Contracts;
using PetShelterMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShelterMVC.Controllers
{
    
        [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Roles = "Admin, Employee")]
        public class PetController : BaseCrudController<PetDto, IPetRepository, IPetService, PetEditVM, PetDetailsVM>
        {
            public PetController(IPetService service, IMapper mapper) : base(service, mapper)
            {

            }
        }
}
