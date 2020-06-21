using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CBA.Training.Talmate.Models
{
    public class DemandDTO
    {
        public int DemandId { get; set; }
        public string PrimarySkills { get; set; }
        public string SecondarySkills { get; set; }
        public string Location { get; set; }
        public DateTime? Start_By_Date { get; set; }
        public int Experience { get; set; }
    }
}
