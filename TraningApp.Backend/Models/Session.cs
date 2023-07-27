using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraningTrakerApp.Backend.Models;

namespace TraningApp.Backend.Models
{
    public class Session
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string? SessionName { get; set; }
        public string? TargetedMuscleGroups { get; set; }
        public IEnumerable<Exercise>? Exercise { get; set; } = new List<Exercise>();
        public int CreatedByUser { get; set; }
    }
}