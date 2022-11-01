using _1CommonInfrastructure.Models;

namespace _3BusinessLogicLayer.Interfaces
{
    public interface ISecurityService
    {
        Task<SecurityModel?> GetUserSecuirty();
        Task<bool> CheckUserActivity(List<string> screenCode);
    }
}