namespace _2026_02_21;

public class Employee : Person
{
    private long salary;

    public Employee(string name, int age, long salary)
        : base(name, age)
    {
        this.salary = salary;
    }
    
    public override string ToString()
    {
        return $"{name} nevű munkás vagyok és {Age} éves. A fizetésem:  {salary}";
    }
}