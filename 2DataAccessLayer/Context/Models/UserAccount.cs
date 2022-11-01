using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DataAccessLayer.Context.Models
{
    

    public class UserAccount
    {
        public int UserAccountID { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        //Collection Navigation Reference
        public virtual ICollection<SystemAction> SystemActions { get; set; }
    }

    public class SystemAction
    {
        public int SystemActionID { get; set; }
        public string ActionCode { get; set; }
        public string ActionName { get; set; }
        //Collection Navigation Reference
        public virtual ICollection<UserAccount> UserAccounts { get; set; }
    }
}
