﻿using System.ComponentModel.DataAnnotations;

namespace GCS_CO.Models
{
    public class Region
    {
        [Key]
        public required string Abbreviation { get; set; }
        public required string Name { get; set; }
    }
}
