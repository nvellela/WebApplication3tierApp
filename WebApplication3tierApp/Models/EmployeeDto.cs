using _1CommonInfrastructure.Models;

namespace WebApplication3tierApp.Models
{
    public class EmployeeDto
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
                        
    }

    public static class EmployeeDtoMapExtensions
    {
        public static EmployeeDto ToEmployeeDto(this EmployeeModel src)
        {
            var dst = new EmployeeDto();
            dst.EmployeeId = src.EmployeeId;
            dst.EmployeeName = src.EmployeeName;            
            return dst;
        }

        public static EmployeeModel ToEmployeeModel(this EmployeeDto src)
        {
            var dst = new EmployeeModel();
            dst.EmployeeId = src.EmployeeId;
            dst.EmployeeName = src.EmployeeName;            
            return dst;
        }
    }
}
