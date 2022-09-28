using _1CommonInfrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DataAccessLayer.Interfaces
{
    public interface IStudentDal
    {
        // Getters
        StudentModel? GetById(int StudentId);
        List<StudentModel> GetAll();

        // Actions
        int CreateStudent(StudentModel Student);
        void UpdateStudent(StudentModel Student);
        void DeleteStudent(int StudentId);
    }
}
