using CompanyWebApiApp.Models.DTOs;

namespace CompanyWebApiApp.Services.Interfaces
{
    public interface IUserService
    {
        public UserDTO Login(UserDTO userDTO);
        public UserDTO Register(UserDTO userDTO);
    }
}
