using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShelterMVC.ViewModels
{
    public class PetVaccineEditVM : BaseVM
    {
        [Required]
        public int PetId { get; set; }
        [Required]
        public int VaccineId { get; set; }

    }
}
