﻿namespace WP01.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private static List<Employee> _employeeList;

        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>(){
            new Employee() { Id = 1, Name = "Mary", Department = Dept.HR, Email = "mary@CDACtech.com" },
            new Employee() { Id = 2, Name = "John", Department = Dept.IT, Email = "john@CDACtech.com" },
            new Employee() { Id = 3, Name = "Sam", Department = Dept.IT, Email = "sam@CDACtech.com" },
             };
        }

        public Employee Add(Employee employee)
        {
            employee.Id = _employeeList.Max(e => e.Id) + 1;
            _employeeList.Add(employee);
            return employee;
        }
        public Employee Delete(int Id)
        {
            Employee employee = _employeeList.FirstOrDefault(e => e.Id == Id);
            if (employee != null)
            {
                _employeeList.Remove(employee);
            }
            return employee;
        }
        public IEnumerable<Employee> GetAllEmployee()
        {
            return _employeeList;
        }
        public Employee GetEmployee(int Id)
        {
            return _employeeList.FirstOrDefault(e => e.Id == Id);
        }
        public Employee Update(Employee employeeChanges)
        {
            Employee employee = _employeeList.FirstOrDefault(e => e.Id == employeeChanges.Id);
            if (employee != null)
            {
                employee.Name = employeeChanges.Name;
                employee.Email = employeeChanges.Email;
                employee.Department = employeeChanges.Department;
            }
            return employee;
        }

    }
}
