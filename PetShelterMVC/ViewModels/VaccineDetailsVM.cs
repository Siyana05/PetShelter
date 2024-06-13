using PetShelter.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShelterMVC.ViewModels
{
    public class VaccineDetailsVM : BaseVM
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual List<PetVaccine> PetVaccines { get; set; }
        public virtual List<Pet> Pets { get; set; }
    }
}
