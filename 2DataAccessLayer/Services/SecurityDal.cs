using _1CommonInfrastructure.Models;
using _2DataAccessLayer.Context;
using _2DataAccessLayer.Context.Models;
using _2DataAccessLayer.Interfaces;
using _2DataAccessLayer.Maps;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DataAccessLayer.Services
{
    public class SecurityDal : ISecurityDal
    {
        //private readonly TestDBEntities context;
        private DBEntitiesContext _db;
        public SecurityDal(DBEntitiesContext dbctx)
        {
            this._db = dbctx; // new TestDBEntities();
        }


        public SecurityModel GetUserSecurityModel(string userId)
        {
            var result = _db.UserAccounts.Include(p => p.SystemActions).Where(x => x.UserId == userId).FirstOrDefault();

            var returnObject = new SecurityModel()
            {
                UserAccountID = result.UserAccountID,
                UserId = result.UserId,
                UserName = result.UserName,
                SystemActionCodes = result.SystemActions.Select(x => x.ActionCode).ToList() ?? new List<string>()
            };
            return returnObject;
        }     

    }
}
