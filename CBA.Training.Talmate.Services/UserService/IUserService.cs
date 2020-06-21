
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CBA.Training.Talmate.EntityModels;
using CBA.Training.Talmate.Models;

namespace CBA.Training.Talmate.Services.UserService
{
    public interface IUserService
    {
        Task<UserRolesDTO> Authenticate(string username, string password);
        Task<IQueryable<User>> GetAll();
        Task<User> GetById(int id);
    }
}