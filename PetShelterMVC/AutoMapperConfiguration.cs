using AutoMapper;
using PetShelter.Data.Entities;
using PetShelter.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShelterMVC
{
    internal class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<Breed, BreedDto>().ReverseMap();
            CreateMap<BreedDto, BreedEditVM>().ReserveMap();
            CreateMap<BreedDto, BreedDetailsVM>().ReserveMap();

            CreateMap<Location, LocationDto>().ReverseMap();
            CreateMap<LocationDto, LocationEditVM>().ReserveMap();
            CreateMap<LocationDto, LocationDetailsVM>().ReserveMap();

            CreateMap<Pet, PetDto>().ReverseMap();
            CreateMap<PetDto, PetEditVM>().ReserveMap();
            CreateMap<PetDto, PetDetailsVM>().ReserveMap();

            CreateMap<PetType, PetTypeDto>().ReverseMap();
            CreateMap<PetTypeDto, PetTypeEditVM>().ReserveMap();
            CreateMap<PetTypeDto, PetTypeDetailsVM>().ReserveMap();

            CreateMap<PetVaccine, PetVaccineDto>().ReverseMap();
            CreateMap<PetVaccineDto, PetVaccineEditVM>().ReserveMap();
            CreateMap<PetVaccineDto, PetVaccineDetailsVM>().ReserveMap();

            CreateMap<Role, RoleDto>().ReverseMap();
            CreateMap<RoleDto, RoleEditVM>().ReserveMap();
            CreateMap<RoleDto, RoleDetailsVM>().ReserveMap();

            CreateMap<Shelter, ShelterDto>().ReverseMap();
            CreateMap<ShelterDto, ShelterEditVM>().ReserveMap();
            CreateMap<ShelterDto, ShelterDetailsVM>().ReserveMap();

            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<UserDto, UserEditVM>().ReserveMap();
            CreateMap<UserDto, UserDetailsVM>().ReserveMap();

            CreateMap<Vaccine, VaccineDto>().ReverseMap();
            CreateMap<VaccineDto, VaccineEditVM>().ReserveMap();
            CreateMap<VaccineDto, VaccineDetailsVM>().ReserveMap();
        }
    }
}
