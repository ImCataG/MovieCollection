using MovieCollection.DTOs;
using MovieCollection.Models.Authentication;

namespace MovieCollection.Services.UserService
{
    public interface IUserService
    {
        Task<bool> RegisterNew(Register r, string role);
        Task<IEnumerable<UserGetDTO>> GetUsers();
    }
}
