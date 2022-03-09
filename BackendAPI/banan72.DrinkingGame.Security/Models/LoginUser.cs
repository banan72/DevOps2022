using System.Collections.Generic;

namespace banan72.DrinkingGame.Security.Models
{
    public class LoginUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string HashedPassword { get; set; }
        
        public List<Permission> Permissions { get; set; }
        public int AccountId { get; set; }

        public string Salt { get; set; }
    }
}