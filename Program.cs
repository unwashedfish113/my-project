using System;
using System.Collections.Generic;

// Абстрактный базовый класс (Абстракция)
abstract class Employee
{
    public string Name { get; set; }
    public string Id { get; set; }

    public Employee(string name, string id)
    {
        Name = name;
        Id = id;
    }

    // Абстрактный метод, который должны реализовать наследники
    public abstract double CalculateSalary();
}

// Производный класс: Штатный сотрудник (Наследование)
class FullTimeEmployee : Employee
{
    public double MonthlySalary { get; set; }

    public FullTimeEmployee(string name, string id, double monthlySalary) : base(name, id)
    {
        MonthlySalary = monthlySalary;
    }

    // Полиморфизм: переопределение метода
    public override double CalculateSalary() => MonthlySalary;
}

// Производный класс: Сотрудник на полставки (Наследование)
class PartTimeEmployee : Employee
{
    public double HourlyRate { get; set; }
    public double HoursWorked { get; set; }

    public PartTimeEmployee(string name, string id, double hourlyRate, double hoursWorked) : base(name, id)
    {
        HourlyRate = hourlyRate;
        HoursWorked = hoursWorked;
    }

    // Полиморфизм: переопределение метода
    public override double CalculateSalary() => HourlyRate * HoursWorked;
}

class Program
{
    static void Main()
    {
        // Полиморфизм: список базового типа хранит объекты наследников
        List<Employee> employees = new List<Employee>
        {
            new FullTimeEmployee("Melanie Duro", "FT001", 30000),
            new PartTimeEmployee("Neliza Gajo", "PT001", 150, 56)
        };

        foreach (Employee emp in employees)
        {
            // Вызов переопределённого метода в зависимости от реального типа объекта
            Console.WriteLine($"{emp.Name} | Зарплата: {emp.CalculateSalary():C2}");
        }
    }
}