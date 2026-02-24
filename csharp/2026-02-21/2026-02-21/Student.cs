namespace _2026_02_21;

public class Student : Person
{
    private string neptun;

    public string Neptun
    {
        get { return neptun; }
        set
        {
            if (value.Length > 6)
                throw new ArgumentException("The neptun code cannot be longer than 6 characters!");
            neptun = value;
        }
    }

    public Student(string name, int age, string neptun)
        : base(name, age)
    {
        Neptun = neptun;
    }
    
    public override string ToString()
    {
        return $"{name} tanuló vagyok és {Age} éves. A neptunkódom:  {Neptun}";
    }
}