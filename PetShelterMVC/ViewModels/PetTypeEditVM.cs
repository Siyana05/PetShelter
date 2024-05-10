using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetShelterMVC.ViewModels
{
    public class PetTypeEditVM : BaseVM
    {
        [Required]
        public string Name { get; set; }

    }
}
