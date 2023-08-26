using MovieCollection.Models.Authentication;

namespace MovieCollection.Services.UserService
{
    public interface IUserService
    {
        Task<bool> RegisterNew(Register r, string role);

    }
}
