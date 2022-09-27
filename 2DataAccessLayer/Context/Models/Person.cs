using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DataAccessLayer.Context.Models
{
    public class Person
    {
        public int PersonId { get; set; } // int
        public string GivenName { get; set; } // nvarchar(400)
        public string FamilyName { get; set; } // nvarchar(400)
        public string? PreferredName { get; set; } // nvarchar(400)
        public DateTime? DateOfBirth { get; set; } // datetime2(7)       
        public bool IsDeleted { get; set; } // bit
    }
}
