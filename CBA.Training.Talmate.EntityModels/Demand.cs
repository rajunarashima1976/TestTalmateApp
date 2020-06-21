using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace CBA.Training.Talmate.EntityModels
{
    public class Demand
    {
        [Key]        
        public int DemandId { get; set; }
        [Required]
        public string PrimarySkills { get; set; }
        [Required]
        public string SecondarySkills { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public DateTime? Start_By_Date { get; set; }
        [Required]
        public int Experience { get; set; }
    }
}
