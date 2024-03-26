using PetShelter.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShelterMVC.ViewModels
{
    public class BreedDetailsVM : BaseVM
    {
        public string Name { get; set; }
        public BreedSize Size { get; set; }
        public List<PetDetailsVM> Pets { get; set; }
    }
}
