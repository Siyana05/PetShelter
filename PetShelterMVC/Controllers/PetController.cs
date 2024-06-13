using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetShelter.Data.Entities;
using PetShelter.Services;
using PetShelter.Shared;
using PetShelter.Shared.Dtos;
using PetShelter.Shared.Repos.Contracts;
using PetShelter.Shared.Services.Contracts;
using PetShelterMVC.Controllers;
using PetShelterMVC.ViewModel;
using PetShelterMVC.ViewModels;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PetShelter.Controllers
{

    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Roles = "Admin, Employee, User")]
    public class PetController : BaseCrudController<PetDto, IPetRepository, IPetService, PetEditVM, PetDetailsVM>
    {
        private readonly IPetTypeService _petTypeService;
        private readonly IShelterService _shelterService;
        private readonly IBreedsService _breedService;
        private readonly IUserService _userService;
        private readonly IVaccineService _vaccinesService;

        public PetController(IPetService service, IMapper mapper, IPetService petService, IPetTypeService petTypeService, IBreedsService breedService, IShelterService shelterService, IUserService userService, IVaccineService vaccinesService) : base(service, mapper)
        {
            _breedService = breedService;
            _petTypeService = petTypeService;
            _shelterService = shelterService;
            _userService = userService;
            _vaccinesService = vaccinesService;
        }
        protected override async Task<PetEditVM> PrePopulateVMAsync(PetEditVM editVM)
        {
            editVM.BreedList = (await _breedService.GetAllAsync())
            .Select(x => new SelectListItem(x.Name, x.Id.ToString()));

            editVM.PetTypeList = (await _petTypeService.GetAllAsync())
           .Select(x => new SelectListItem(x.Name, x.Id.ToString()));

            editVM.ShelterList = (await _shelterService.GetAllAsync())
            .Select(x => new SelectListItem(x.PetCapacity.ToString(), x.Id.ToString()));

            return editVM;
        }
        [HttpGet]
        public virtual async Task<IActionResult> GivePet()
        {
            var editVM = await PrePopulateVMAsync(new PetEditVM());

            return View(editVM);
        }

        [HttpPost]
        public virtual async Task<IActionResult> GivePet(PetEditVM editVM)
        {
            var errors = await Validate(editVM);

            if (errors != null)
            {
                return View(editVM);
            }
            string loggedUsername = User.FindFirst(ClaimTypes.Name)?.Value;
            var user = await this._userService.GetByUsernameAsync(loggedUsername);
            var model = this._mapper.Map<PetDto>(editVM);
            await this._service.GivePetAsync(user.Id, model.ShelterId.Value, model);

            return await List();
        }
        [HttpGet]
        public virtual async Task<IActionResult> VaccinatePet(int? id)
        {
            if (id == null)
            {
                return BadRequest(Constants.InvalidId);
            }
            var model = await this._service.GeyByIdIfExistsAsync(id.Value);
            if (model == default)
            {
                return BadRequest(Constants.InvalidId);
            }
            var vaccinatedPet = new VaccinatePetVM();
            vaccinatedPet.PetId = id.Value;
            vaccinatedPet.VaccineList = (await _vaccinesService.GetAllAsync())
                .Select(x => new SelectListItem($"{x.Name}", x.Id.ToString()));
            return View(vaccinatedPet);
        }
        [HttpPost]
        public virtual async Task<IActionResult> VaccinatePet(int id, VaccinatePetVM editVM)
        {

            await this._service.VaccinatePetAsync(editVM.PetId, editVM.VaccineId);
            return await List();
        }

    }
}