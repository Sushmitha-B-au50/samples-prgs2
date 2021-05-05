using System;
using System.Collections.Generic;
using System.Text;
using TraansportManagementBLLibrary;

namespace TransportManagementSystem
{
    class EmployeeCRUD
    {
        IRepo<Employee> repo;
        
        public EmployeeCRUD(IRepo<Employee> repo)
        {
            this.repo = repo;
        }
        public void AddEmployee()
        {
            Employee employee = new Employee();
            employee.GetEmployeeDetails();
            repo.Add(employee);
        }

        public void PrintAllEmployees()
        {
            var employees = repo.GetAll();
            foreach(var item in employees)
            {
                Console.WriteLine(item);
            }
        }

        public void DeleteEmployee()
        {
            Console.WriteLine("please enter employee id to delete");
            int id = Convert.ToInt32(Console.ReadLine());
            Employee employee = repo.Get(id);
            if (employee == null)
                Console.WriteLine("no such employee");
            else
            {
                repo.Delete(id);
                Console.WriteLine("deleted");
            }
        }

        public void UpdateEmployees()
        {
            Console.WriteLine("Please enter the id the need to be updated");
            int id = Convert.ToInt32(Console.ReadLine());
            Employee employee = null;
            employee = repo.Get(id);

            int choice = 0;
            do
            {
                Console.WriteLine("1. Name");
                Console.WriteLine("2. Location");
                Console.WriteLine("3. Both");
                Console.WriteLine("4. Exit");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Please Enter the New Name:");
                        string name = Console.ReadLine();
                        employee.Name = name;
                        repo.Update(id, employee);
                        Console.WriteLine("Name Updated");
                        break;
                    case 2:
                        Console.WriteLine("Please Enter the New Location");
                        string location = Console.ReadLine();
                        employee.Location = location;
                        repo.Update(id, employee);
                        Console.WriteLine("Location Updated");
                        break;
                    case 3:
                        Console.WriteLine("Please Enter the New Name:");
                        name = Console.ReadLine();
                        employee.Name = name;
                        repo.Update(id, employee);
                        Console.WriteLine("Please Enter the New Location");
                        location = Console.ReadLine();
                        employee.Location = location;
                        repo.Update(id, employee);
                        Console.WriteLine("Name And Location Updated");
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            } while (choice != 4);

        }

    }

}
