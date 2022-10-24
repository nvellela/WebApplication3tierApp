using _1CommonInfrastructure.Enums;
using Infrastructure.Application.Models.Auth;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace WebApplication3tierApp.Models
{
    public class UserAuthDto
    {
        public int? UserId { get; set; }
        public string Username { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public string Email { get; set; }       

        [JsonProperty(ItemConverterType = typeof(StringEnumConverter))]
        public IList<SystemActions> SystemAuthorisedActions { get; set; }
       
    }

    public static class UserAuthMapExtensions
    {
        public static UserAuthDto ToUserAuthDto(this UserModel src)
        {
            var dst = new UserAuthDto();

            dst.UserId = src.UserId;
            dst.Username = src.Username;
            dst.GivenName = src.GivenName;
            dst.FamilyName = src.FamilyName;
            dst.Email = src.Email;          
            
            dst.SystemAuthorisedActions = src.SystemAuthorisedActions;           
            return dst;
        }
    }
}
