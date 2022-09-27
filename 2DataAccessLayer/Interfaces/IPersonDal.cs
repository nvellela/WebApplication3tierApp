using _1CommonInfrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DataAccessLayer.Interfaces
{
    public interface IPersonDal
    {
        // Getters
        PersonModel? GetById(int personId);
        List<PersonModel> GetAll();

        // Actions
        int CreatePerson(PersonModel person);
        void UpdatePerson(PersonModel person);
        void DeletePerson(int personId);
    }
}
