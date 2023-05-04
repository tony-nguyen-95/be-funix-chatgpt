namespace Funix.HannahAssistant.Api.Models
{
    public class UserModel
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FunixId { get; set; }
        public string FunixEmail { get; set; }
    }
}
