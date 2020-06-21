using System;
using System.ComponentModel.DataAnnotations;

namespace CBA.Training.Talmate.Models
{
    public class UserDTO
    {       
        [Required]
        public string Username { get; set; }        
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }        
    }
}
