using System;
using System.Collections.Generic;
using System.Linq;

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Position { get; set; }
    public decimal Salary { get; set; }

    public Employee(int id, string name, string position, decimal salary)
    {
        Id = id;
        Name = name;
        Position = position;
        Salary = salary;
    }

    public override string ToString()
    {
        return $"ID: {Id}, Name: {Name}, Position: {Position}, Salary: {Salary:C}";
    }
}

public class EmployeeManager
{
    private List<Employee> employees = new List<Employee>();

    // Create: Add a new employee
    public void CreateEmployee(int id, string name, string position, decimal salary)
    {
        if (employees.Any(e => e.Id == id)) // Check if an employee with this ID already exists
        {
            Console.WriteLine("An employee with this ID already exists.");
            return;
        }

        var newEmployee = new Employee(id, name, position, salary);
        employees.Add(newEmployee);
        Console.WriteLine("Employee added successfully.");
    }

    // Read: List all employees
    public void ListAllEmployees()
    {
        if (employees.Count == 0)
        {
            Console.WriteLine("No employees found.");
        }
        else
        {
            Console.WriteLine("\nEmployee List:");
            foreach (var emp in employees)
            {
                Console.WriteLine(emp);
            }
        }
    }

    // Read: Find an employee by ID
    public void FindEmployeeById(int id)
    {
        var employee = employees.FirstOrDefault(e => e.Id == id);
        if (employee != null)
        {
            Console.WriteLine($"Employee found: {employee}");
        }
        else
        {
            Console.WriteLine("Employee not found.");
        }
    }

    // Update: Update an existing employee's details by ID
    public void UpdateEmployee(int id, string newName, string newPosition, decimal newSalary)
    {
        var employee = employees.FirstOrDefault(e => e.Id == id);
        if (employee != null)
        {
            employee.Name = newName;
            employee.Position = newPosition;
            employee.Salary = newSalary;
            Console.WriteLine("Employee updated successfully.");
        }
        else
        {
            Console.WriteLine("Employee not found.");
        }
    }

    // Delete: Remove an employee by ID
    public void DeleteEmployee(int id)
    {
        var employee = employees.FirstOrDefault(e => e.Id == id);
        if (employee != null)
        {
            employees.Remove(employee);
            Console.WriteLine("Employee deleted successfully.");
        }
        else
        {
            Console.WriteLine("Employee not found.");
        }
    }
}

public class Program
{
    public static void Main()
    {
        var manager = new EmployeeManager();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Employee Management System ===");
            Console.WriteLine("1. Add New Employee");
            Console.WriteLine("2. List All Employees");
            Console.WriteLine("3. Find Employee by ID");
            Console.WriteLine("4. Update Employee");
            Console.WriteLine("5. Delete Employee");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option: ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    // Add a new employee
                    Console.Write("Enter Employee ID: ");
                    int id = int.Parse(Console.ReadLine());
                    Console.Write("Enter Employee Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter Employee Position: ");
                    string position = Console.ReadLine();
                    Console.Write("Enter Employee Salary: ");
                    decimal salary = decimal.Parse(Console.ReadLine());
                    manager.CreateEmployee(id, name, position, salary);
                    break;

                case "2":
                    // List all employees
                    manager.ListAllEmployees();
                    break;

                case "3":
                    // Find an employee by ID
                    Console.Write("Enter Employee ID: ");
                    int searchId = int.Parse(Console.ReadLine());
                    manager.FindEmployeeById(searchId);
                    break;

                case "4":
                    // Update an employee's details
                    Console.Write("Enter Employee ID to update: ");
                    int updateId = int.Parse(Console.ReadLine());
                    Console.Write("Enter new Employee Name: ");
                    string newName = Console.ReadLine();
                    Console.Write("Enter new Employee Position: ");
                    string newPosition = Console.ReadLine();
                    Console.Write("Enter new Employee Salary: ");
                    decimal newSalary = decimal.Parse(Console.ReadLine());
                    manager.UpdateEmployee(updateId, newName, newPosition, newSalary);
                    break;

                case "5":
                    // Delete an employee
                    Console.Write("Enter Employee ID to delete: ");
                    int deleteId = int.Parse(Console.ReadLine());
                    manager.DeleteEmployee(deleteId);
                    break;

                case "6":
                    // Exit
                    Console.WriteLine("Exiting...");
                    return;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}

