using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace PetShelterMVC.ViewModels
{
    public class VaccinatePetVM
    {
        public int PetId { get; set; }
        public int VaccineId { get; set; }
        public IEnumerable<SelectListItem> VaccineList { get; set; }
    }
}
