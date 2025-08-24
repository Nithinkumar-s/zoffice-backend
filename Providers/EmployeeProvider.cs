using backend.Models; 

namespace backend.Providers
{
    public interface IEmployeeProvider
    {
        Employee ManipulateEmployee(Employee employee);
    }

    public class EmployeeProvider : IEmployeeProvider
    {
        public Employee ManipulateEmployee(Employee employee)
        {   
            return employee; 
        }
    }
}
