namespace _2026_02_21;

public class Student : Person
{
    private string _neptunCode;

    public string NeptunCode
    {
        get { return _neptunCode; }
        set
        {
            if (value.Length > 6)
                throw new ArgumentException("The neptun code cannot be longer than 6 characters!");
            _neptunCode = value;
        }
    }

    public Student(string name, int age, string neptunCode)
        : base(name, age)
    {
        NeptunCode = neptunCode;
    }
    
    public override string ToString()
    {
        return $"{Name} tanuló vagyok és {Age} éves. A neptunkódom:  {NeptunCode}";
    }
}