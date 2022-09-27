using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _1CommonInfrastructure.Models
{
    public class PersonModel
    {
        public int PersonId { get; set; } // int
        public string GivenName { get; set; } // nvarchar(400)
        public string FamilyName { get; set; } // nvarchar(400)
        public string? PreferredName { get; set; } // nvarchar(400)
        public DateTime? DateOfBirth { get; set; } // datetime2(7)       
        public bool IsDeleted { get; set; } // bit
    }
}
