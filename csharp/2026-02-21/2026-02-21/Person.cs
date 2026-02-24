namespace _2026_02_21;

using System;

public class Person
{
    protected string name;

    private int age;

    public int Age
    {
        get { return age; }
        set
        {
            if (value < 0)
                throw new ArgumentException("The age cannot be negative!");
            age = value;
        }
    }

    public Person(string name, int age)
    {
        this.name = name;
        Age = age;
    }

    public override string ToString()
    {
        return $"{name} vagyok és {Age} éves.";
    }
}