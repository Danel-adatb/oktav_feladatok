using System;

namespace _2026_02_21
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Person p1 = new Person("Person One", 28);
                Student s1 = new Student("Student One", 27, "XUXEJO");
                Student s2 = new Student("Student Two", 37, "XUXEJU");
                Student s3 = new Student("Student Three", 19, "XUXEJA");
                Employee e1 = new Employee("Employee One", 49, 380000);
                
                var students = new List<Student>();
                students.Add(s1);
                students.Add(s2);
                students.Add(s3);

                Console.WriteLine(p1);
                foreach (var student in students)
                {
                    Console.WriteLine(student.ToString());
                }
                Console.WriteLine(e1);

                var ba = new BankAccount(100000);
                Console.WriteLine($"Balance: {ba.Balance}");
                Console.WriteLine($"Deposit: {ba.deposit(10000)}");
                Console.WriteLine($"Withdraw: {ba.withdraw(10000)}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error has occured: {e}");
                throw;
            }
        }
    }
}