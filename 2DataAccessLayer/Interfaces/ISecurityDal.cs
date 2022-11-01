using _1CommonInfrastructure.Models;

namespace _2DataAccessLayer.Interfaces
{
    public interface ISecurityDal
    {
        SecurityModel GetUserSecurityModel(string userId);
    }
}