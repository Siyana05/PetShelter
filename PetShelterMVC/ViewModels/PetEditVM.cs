using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShelterMVC.ViewModels
{
    public class PetEditVM : BaseVM
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Color { get; set; }

        public int PetTypeId { get; set; }

        public int BreedId { get; set; }

        public int? AdopterId { get; set; }

        public int? GiverId { get; set; }

        public int? ShelterId { get; set; }

    }
}
