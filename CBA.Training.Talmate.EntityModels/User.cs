using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
namespace CBA.Training.Talmate.EntityModels
{
    public class User
    {
        [Key]
        public int Id { get; set; }       
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }        
        
    }
}
