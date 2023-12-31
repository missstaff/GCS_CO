﻿using System.ComponentModel.DataAnnotations;

namespace GCS_CO.Models
{
    public class PostalCode
    {
        public required string CityName { get; set; }
        public required string Code { get; set; }

        public State? State { get; set; }
        public string? StateAbbrev { get; set; }
        public string? RegionAbbrev { get; set; }

        public City? City { get; set; }
    }
}