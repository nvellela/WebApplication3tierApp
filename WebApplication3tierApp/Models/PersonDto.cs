using _1CommonInfrastructure.Models;

namespace WebApplication3tierApp.Models
{
    public class PersonDto
    {
        public int PersonId { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public string? PreferredName { get; set; }
        public DateTime? DateOfBirth { get; set; }                
    }

    public static class PersonDtoMapExtensions
    {
        public static PersonDto ToPersonDto(this PersonModel src)
        {
            var dst = new PersonDto();
            dst.PersonId = src.PersonId;
            dst.GivenName = src.GivenName;
            dst.FamilyName = src.FamilyName;
            dst.PreferredName = src.PreferredName;
            dst.DateOfBirth = src.DateOfBirth;            
            return dst;
        }

        public static PersonModel ToPersonModel(this PersonDto src)
        {
            var dst = new PersonModel();
            dst.PersonId = src.PersonId;
            dst.GivenName = src.GivenName;
            dst.FamilyName = src.FamilyName;
            dst.PreferredName = src.PreferredName;
            dst.DateOfBirth = src.DateOfBirth;            
            return dst;
        }
    }
}
