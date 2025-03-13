
using Midterm.Models;

namespace Midterm.Services
{
    public interface IUserService
    {
        Task<MsgResponse> CreateUser(RegisterRequest req);
        Task<MsgResponse> GetAuthenticatedUser(LoginRequest req);
        Task<bool> LogUserOut();
    }
}