using System.Collections.Generic;
using banan72.DrinkingGame.Core;
using banan72.DrinkingGame.Security.Models;

namespace banan72.DrinkingGame.Security
{
    public interface IAuthService
    {
        string GenerateJwtToken(LoginUser userUserName);
        string Hash(LoginUser user);
        List<Permission> GetPermissions(int userId);
        string CreateNewAccount(LoginUser newUser, Player userAccount);
        void EstablishPermissions(Player newAccount);
        LoginUser GetUserInfo(string username);
    }
}