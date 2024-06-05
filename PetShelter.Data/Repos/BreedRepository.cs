using AutoMapper;
using PetShelter.Data.Entities;
using PetShelter.Shared.Dtos;
using PetShelter.Shared.Repos.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShelter.Data.Repos
{
    public class BreedsRepository : BaseRepository<Breed, BreedDto>, IBreedRepository
    {
        public BreedsRepository(PetShelterDbContext context, IMapper mapper) : base(context, mapper)
        {

        }


    }
}
