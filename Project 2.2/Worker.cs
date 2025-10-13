using System;

abstract class Worker
{
    public string Name { get; set; }
    public string Position { get; set; }
    public int WorkDay { get; set; }

    public Worker(string name, string position)
    {
        Name = name;
        Position = position;
    }

    public void Call()
    {
        Console.WriteLine($"{Name} ({Position}) is calling a client.");
    }

    public void WriteCode()
    {
        Console.WriteLine($"{Name} ({Position}) is writing code.");
    }

    public void Relax()
    {
        Console.WriteLine($"{Name} ({Position}) is taking a break.");
    }

    public abstract void FillWorkDay();
}
