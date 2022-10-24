

using _1CommonInfrastructure.Enums;
using _1CommonInfrastructure.Models;
using _1CommonInfrastructure.Validations;
using _2DataAccessLayer.Interfaces;
using _3BusinessLogicLayer.Interfaces;
using System.Data;

namespace _3BusinessLogicLayer.Services
{
    public class PersonService : BaseService,  IPersonService
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
            await ValidateAccess(SystemActions.PersonView);
            //write log to journal if required -- add to the base class if repeated calls

            return _personDal.GetAll();
        }

        public async Task<int> CreatePerson(PersonModel person)
        {
            //1 check security
            await ValidateAccess(SystemActions.PersonCreate);


            //2 [if required] write log to journal if required -- add to the base class if repeated calls
           // serilog.log()
            //3 do validations here @either fluent or by manual if/else + service calls
            CheckFluentValidation(await new PersonValidator().ValidateAsync(person));

            //4 do any business logic
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
