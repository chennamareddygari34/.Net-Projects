using BankAcountEstatementApp.Models.DTOs;

namespace BankAcountEstatementApp.Interfaces
{
    public interface IUserService
    {

        public UserDTO Login(UserDTO userDTO);
        public UserDTO Register(UserDTO userDTO);

    }
}
