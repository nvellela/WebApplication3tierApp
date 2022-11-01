

using _1CommonInfrastructure.Enum;
using _1CommonInfrastructure.Interfaces;
using _1CommonInfrastructure.Models;
using _1CommonInfrastructure.Validations;
using _2DataAccessLayer.Context.Models;
using _2DataAccessLayer.Interfaces;
using _3BusinessLogicLayer.Interfaces;

namespace _3BusinessLogicLayer.Services
{
    public class PersonService :   BaseService, IPersonService
    {
        private readonly IPersonDal _personDal;
       
        public PersonService(IPersonDal personDal,
            ISecurityService securityService,
            ILoggingService loggingService
        //IPersonDal personDal,
        //IAuditDal auditDal
        ) : base(securityService, loggingService)
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
            await IsAuthorisedToAccess("PersonView");  //good 

            await IsAuthorisedToAccess(SystemActionsEnum.PersonAdd.ToString());  //good 
                        
            try
            {
                //write validations here
                CheckFluentValidation(await new PersonValidator().ValidateAsync(person));

                //any logs 
                LogInformation("CreatePerson-starting", $"step1 create person", person);
                var newPersonId = _personDal.CreatePerson(person);
                LogInformation("CreatePerson-finished", $"step2 create person", person);
                return newPersonId;

            }
            catch (Exception e)
            {
                LogError("Error-CreatePerson", $"Error trying to create person", person, e);
            }           
           return 0;
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
