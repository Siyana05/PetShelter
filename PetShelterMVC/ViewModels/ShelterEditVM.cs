using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetShelterMVC.ViewModels
{
    public class ShelterEditVM : BaseVM
    {
        [Required]
        public int PetCapacity { get; set; }
        [Required]
        public int LocationId { get; set; }
    }
}
