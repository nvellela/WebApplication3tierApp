using _1CommonInfrastructure.Models;
using _2DataAccessLayer.Context.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _2DataAccessLayer.Maps
{
    public static class PersonMapExtensions
    {
        public static PersonModel ToPersonModel(this Person src)
        {
            var dst = new PersonModel();

            dst.PersonId = src.PersonId;
            dst.GivenName = src.GivenName;
            dst.FamilyName = src.FamilyName;
            dst.PreferredName = src.PreferredName;
            dst.DateOfBirth = src.DateOfBirth;
           // dst.Gender = src.Gender.ParseNullableEnum<Gender>();
            dst.IsDeleted = src.IsDeleted;

            return dst;
        }

        public static Person ToPerson(this PersonModel src, Person dst = null)
        {
            if (dst == null)
            {
                dst = new Person();
            }

            dst.PersonId = src.PersonId;
            dst.GivenName = src.GivenName;
            dst.FamilyName = src.FamilyName;
            dst.PreferredName = src.PreferredName;
            dst.DateOfBirth = src.DateOfBirth;           
            dst.IsDeleted = src.IsDeleted;

            return dst;
        }
    }
}
