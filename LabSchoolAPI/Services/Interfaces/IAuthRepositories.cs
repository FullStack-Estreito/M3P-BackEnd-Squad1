using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabSchoolAPI.Services.Interfaces
{
    public interface IAuthRepositories
    {
        Task<UsuarioModel> Register(UsuarioCreateDTO user, string password);
        Task<UsuarioModel> Login(UserLoginDTO userLoginDto);
        Task<bool> UserExists(string email);
        Task<bool> ChangePassword(string email, string oldPassword, string newPassword);
    }
}