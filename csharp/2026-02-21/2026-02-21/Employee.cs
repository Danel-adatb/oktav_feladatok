namespace _2026_02_21;

public class Employee : Person
{
    long Salary { get; set; } //private

    public Employee(string name, int age, long salary)
        : base(name, age)
    {
        Salary = salary;
    }
    
    public override string ToString()
    {
        return $"{Name} nevű munkás vagyok és {Age} éves. A fizetésem:  {Salary}";
    }
}