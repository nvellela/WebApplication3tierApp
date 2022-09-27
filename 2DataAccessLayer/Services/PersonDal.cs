using _1CommonInfrastructure.Models;
using _2DataAccessLayer.Context;
using _2DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DataAccessLayer.Services
{
    public class PersonDal : IPersonDal
    {
        //private readonly TestDBEntities context;
        private DBEntitiesContext context;
        public PersonDal(DBEntitiesContext cont)
        {
            this.context = cont; // new TestDBEntities();
        }


        public int CreatePerson(PersonModel person)
        {
            throw new NotImplementedException();
        }

        public void DeletePerson(int personId)
        {
            throw new NotImplementedException();
        }

        public List<PersonModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public PersonModel? GetById(int personId)
        {
            throw new NotImplementedException();
        }

        public void UpdatePerson(PersonModel person)
        {
            throw new NotImplementedException();
        }
    }



}
