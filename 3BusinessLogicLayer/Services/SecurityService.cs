

using _1CommonInfrastructure.Interfaces;
using _1CommonInfrastructure.Models;
using _2DataAccessLayer.Interfaces;
using _3BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Http;

namespace _3BusinessLogicLayer.Services
{

    public class SecurityService :  ISecurityService
    {
        private readonly ISecurityDal _securityDal;
        private readonly IUserNameResolver _userNameResolver;

        public SecurityService(ISecurityDal securityDal, IUserNameResolver userNameResolver
        //ILoggingService loggingService,
        //ISecurityDal SecurityDal,
        //IAuditDal auditDal
        ) 
        {
            _securityDal = securityDal;
            _userNameResolver = userNameResolver;
        }

        public async Task<SecurityModel?> GetUserSecuirty()
        {
            var userIdentity = _userNameResolver.GetUsername();

            if(userIdentity == null)
            {
                throw new UnauthorizedAccessException("User identity not found");
            }
            return _securityDal.GetUserSecurityModel(userIdentity);

        }

        public async Task<bool> CheckUserActivity(string[] screenCode)
        {        
            var authenticatedUser = await GetUserSecuirty();
            return authenticatedUser.SystemActionCodes.Any(screenCode.Contains);
        }

    }
}
