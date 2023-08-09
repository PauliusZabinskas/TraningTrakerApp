using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TraningApp.Backend.Models.DTOs.SessionDTOs
{
    public abstract class BaseSessionDTO
    {
        public DateTime Date { get; set; } = DateTime.Now;
        [Required]
        public string? Name { get; set; } = "Default";
        public string? TargetedMuscleGroups { get; set; } = "Default";
    
        public int? CreatedBy { get; set; }
    }
}