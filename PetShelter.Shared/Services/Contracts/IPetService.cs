using PetShelter.Shared.Dtos;
using PetShelter.Shared.Repos.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShelter.Shared.Services.Contracts
{
    public interface IPetService : IBaseCrudService<PetDto, IPetRepository>
    {
        Task GivePetAsync(int userId, int shelterId, PetDto pet);
        Task VaccinatePetAsync(int vaccineId, int petId);
        Task AdoptPetAsync(int userId, int petId);
    }
}
