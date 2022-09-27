using _1CommonInfrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3BusinessLogicLayer.Interfaces
{
    public interface IPersonService
    {
        Task<PersonModel?> GetById(int personId);
        Task<List<PersonModel>> GetAll();

        Task<int> CreatePerson(PersonModel person);
        Task UpdatePerson(PersonModel person);
        Task DeletePerson(int personId);
    }
}
