﻿using Microsoft.CodeAnalysis;
using PetShelter.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Location = Microsoft.CodeAnalysis.Location;

namespace PetShelterMVC.ViewModels
{
    public class ShelterDetailsVM : BaseVM
    {
        public int PetCapacity { get; set; }

        public int LocationId { get; set; }

        public virtual Location Location { get; set; }

        public virtual List<User> Employees { get; set; }

        public virtual List<Pet> Pets { get; set; }
    }
}
