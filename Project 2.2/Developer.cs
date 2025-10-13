using System;

class Developer : Worker
{
    public Developer(string name) : base(name, "Developer")
    {
    }

    public override void FillWorkDay()
    {
        WriteCode();
        Call();
        Relax();
        WriteCode();
    }
}
