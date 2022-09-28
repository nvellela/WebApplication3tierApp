using _1CommonInfrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3BusinessLogicLayer.Interfaces
{
    public interface IStudentService
    {
        Task<StudentModel?> GetById(int StudentId);
        Task<List<StudentModel>> GetAll();

        Task<int> CreateStudent(StudentModel Student);
        Task UpdateStudent(StudentModel Student);
        Task DeleteStudent(int StudentId);
    }
}
