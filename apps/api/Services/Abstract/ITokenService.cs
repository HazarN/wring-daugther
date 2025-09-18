using api.Entities;

namespace api.Services.Abstract
{
    public interface ITokenService
    {
        string CreateAccessToken(User user);
        string CreateRefreshToken();
    }
}
