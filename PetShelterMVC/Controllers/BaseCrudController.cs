using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
    public abstract class BaseCrudController<TModel, TRepository, TService, TEditVM, TDetailsVM> : Controller
        where TModel : BaseModel
        where TRepository : IBaseRepository<TModel>
        where TService : IBaseCrudService<TModel, TRepository>
        where TEditVM : BaseVM
        where TDetailsVM : BaseVM
    {
        protected readonly TService _service;
        protected readonly IMapper _mapper;
        protected BaseCrudController(TService service, IMapper mapper)
        {
            this._service = service;
            _mapper = mapper;

        }
        protected const int DefaultPageSize = 10;
        protected const int DefaultPageNumber = 1;
        protected virtual Task<string?> Validate(TEditVM editVM)
        {
            return Task.FromResult<string?>(null);
        }
        protected virtual Task<TEditVM> PrePopulateVMAsync()
        {
            return Task.FromResylt(new TEditVM());
        }

        [HttpGet]
        public virtual async Task<IActionresult> List(int pageSize = DefaultPageSize, int pageNumber = DefaultPageNumber)
        {
            if(pageSize <= 0 ||
                pageSize > PaginationParameters.MaxPageSize ||
                pageNumber <= 0)
            {
                return BadRequest(Constants.InvalidPagination);
            }
            var models = await this._service.GetWithPaginationAsync(pageSize, pageNumber);
            var mapperModels = _mapper.Map<IEnumerable<TDetailsVM>>(models);
            return ViewModels(nameod(List), mapperModels);
        }
    }
}
