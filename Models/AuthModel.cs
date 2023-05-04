using Funix.HannahAssistant.Api.Entities;

namespace Funix.HannahAssistant.Api.Models
{
    public class AuthModel
    {
        public User User { get; set; }
        public string Token { get; set; }
    }
}
