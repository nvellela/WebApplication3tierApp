

using _1CommonInfrastructure.Models;
using _2DataAccessLayer.Interfaces;
using _3BusinessLogicLayer.Interfaces;

namespace _3BusinessLogicLayer.Services
{
    public class PersonService :  IPersonService
    {
        private readonly IPersonDal _personDal;
       
        public PersonService(IPersonDal personDal
        //ILoggingService loggingService,
        //IPersonDal personDal,
        //IAuditDal auditDal
        ) 
        {
            _personDal = personDal;           
        }

        public async Task<PersonModel?> GetById(int personId)
        {           
            return _personDal.GetById(personId);
        }

        public async Task<List<PersonModel>> GetAll()
        {            
            return _personDal.GetAll();
        }

        public async Task<int> CreatePerson(PersonModel person)
        {
            //write validations here
            var newPersonId = _personDal.CreatePerson(person);
            return newPersonId;
        }

        public async Task UpdatePerson(PersonModel person)
        {
            //write validations here 
            _personDal.UpdatePerson(person);
        }

        public async Task DeletePerson(int personId)
        {            
            try
            {
                _personDal.DeletePerson(personId);
            }
            catch (Exception e)
            {
                //_loggingService.WriteLog(LoggingLevel.Error, "Layer", $"Error delete person Id:{personId}. {e.Message}", e.StackTrace);
            }
        }
    }
}
