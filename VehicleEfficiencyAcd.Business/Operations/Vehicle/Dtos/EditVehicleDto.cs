﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace VehicleEfficiencyAcd.Business.Operations.Vehicle.Dtos
{
    public class EditVehicleDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Plate { get; set; }
        public string ImagePath { get; set; } // To display the current image
    }
}
