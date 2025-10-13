using System;

class Manager : Worker
{
    private Random random = new Random();

    public Manager(string name) : base(name, "Manager")
    {
    }

    public override void FillWorkDay()
    {
        int firstCalls = random.Next(1, 11);
        for (int i = 0; i < firstCalls; i++)
            Call();

        Relax();

        int secondCalls = random.Next(1, 6);
        for (int i = 0; i < secondCalls; i++)
            Call();
    }
}
