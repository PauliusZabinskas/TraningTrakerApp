using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraningTrakerApp.Backend.Models;

namespace TraningApp.Backend.Models.DTOs.SessionDTOs
{
    public class SessionDetailsDTO : BaseSessionDTO
    {
        public int Id { get; set; }
    
        public virtual IEnumerable<Exercise> Exercises { get; set; } 
    }
}