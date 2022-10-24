using _1CommonInfrastructure.Enums;

namespace Infrastructure.Application.Models.Auth
{
    public class UserModel
    {
        
        public int? UserId { get; set; } 
        public string Username { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public string Email { get; set; }              
        public IList<SystemActions> SystemAuthorisedActions { get; set; }
        
    }
}
