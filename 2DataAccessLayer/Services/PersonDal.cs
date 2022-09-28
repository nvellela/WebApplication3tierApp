using _1CommonInfrastructure.Models;
using _2DataAccessLayer.Context;
using _2DataAccessLayer.Context.Models;
using _2DataAccessLayer.Interfaces;
using _2DataAccessLayer.Maps;
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
        private DBEntitiesContext _db;
        public PersonDal(DBEntitiesContext dbctx)
        {
            this._db = dbctx; // new TestDBEntities();
        }


        public List<PersonModel> GetAll()
        {
            var result = _db.People.Where(x => x.IsDeleted == false).ToList();

            var returnObject = new List<PersonModel>();
            foreach (var item in result)
            {
                returnObject.Add(item.ToPersonModel());
            }

            return returnObject;
        }

        public PersonModel? GetById(int personId)
        {
            var result = _db.People.SingleOrDefault(x => x.PersonId == personId && x.IsDeleted == false);
            return result?.ToPersonModel();
        }


        public int CreatePerson(PersonModel person)
        {
            var newPerson = person.ToPerson();
            _db.People.Add(newPerson);
            _db.SaveChanges();
            return newPerson.PersonId;
        }


        public void UpdatePerson(PersonModel person)
        {
            var existingPerson = _db.People
                .SingleOrDefault(x => x.PersonId == person.PersonId);

            if (existingPerson == null)
            {
                throw new ApplicationException($"Person {person.PersonId} does not exist.");
            }
            person.ToPerson(existingPerson);

            _db.Update(existingPerson);
            _db.SaveChanges();
        }

        public void DeletePerson(int personId)
        {
            //var efModel = _db.People.Find(personId);
            //_db.People.Remove(efModel);
            //_db.SaveChanges();


            var existingPerson = _db.People
                .SingleOrDefault(x => x.PersonId == personId && x.IsDeleted == false);

            if (existingPerson == null)
            {
                throw new ApplicationException($"Person {personId} does not exist.");
            }

            existingPerson.IsDeleted = true;
            _db.Update(existingPerson);
            _db.SaveChanges();
        }

    }

}
