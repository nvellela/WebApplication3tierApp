

using _1CommonInfrastructure.Models;
using _2DataAccessLayer.Interfaces;
using _3BusinessLogicLayer.Interfaces;

namespace _3BusinessLogicLayer.Services
{
    public class StudentService :  IStudentService
    {
        private readonly IStudentDal _StudentDal;
        //private readonly IStudentBalService _StudentBalService;
        public StudentService(IStudentDal StudentDal
        //ILoggingService loggingService,
        //IStudentDal StudentDal,
        //IAuditDal auditDal
       // IStudentBalanceService balsvc
        ) 
        {
            _StudentDal = StudentDal;
            // _StudentBalService = balsvc;
        }

        public async Task<StudentModel?> GetById(int StudentId)
        {           
            return _StudentDal.GetById(StudentId);
        }

        public async Task<List<StudentModel>> GetAll()
        {            
            return _StudentDal.GetAll();
        }

        public async Task<int> CreateStudent(StudentModel Student)
        {
            //write validations here
            var newStudentId = _StudentDal.CreateStudent(Student);
            return newStudentId;
        }

        public async Task UpdateStudent(StudentModel Student)
        {
            //write validations here 
            _StudentDal.UpdateStudent(Student);
        }

        public async Task DeleteStudent(int StudentId)
        {            
            try
            {
                //if(balservice.getBal(StudentId) = 0)
                _StudentDal.DeleteStudent(StudentId);
            }
            catch (Exception e)
            {
                //_loggingService.WriteLog(LoggingLevel.Error, "Layer", $"Error delete Student Id:{StudentId}. {e.Message}", e.StackTrace);
            }
        }
    }
}
