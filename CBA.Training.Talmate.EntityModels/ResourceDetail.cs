using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace CBA.Training.Talmate.EntityModels
{
    public class ResourceDetail
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PrimarySkills { get; set; }
        public string SecondarySkills { get; set; }
        public string Location { get; set; }        
        public int Experience { get; set; }
        public bool? IsRecommendedForTraining { get; set; }
    }
}
