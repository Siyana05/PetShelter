using PetShelter.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public virtual Pet Pet { get; set; }

        public virtual Vaccine Vaccine { get; set; }

    }
}
