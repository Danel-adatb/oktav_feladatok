namespace _2026_02_21;

using System;

public class Person
{
    protected string Name { get; set; }

    private int _age;

    public int Age
    {
        get { return _age; }
        set
        {
            if (value < 0)
                throw new ArgumentException("The age cannot be negative!");
            _age = value;
        }
    }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public override string ToString()
    {
        return $"{Name} vagyok és {Age} éves.";
    }
}