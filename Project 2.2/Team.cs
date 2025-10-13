using System;
using System.Collections.Generic;

class Team
{
    private string teamName;
    private List<Worker> workers = new List<Worker>();

    public Team(string name)
    {
        teamName = name;
    }

    public void AddWorker(Worker worker)
    {
        workers.Add(worker);
    }

    public void ShowTeamInfo()
    {
        Console.WriteLine($"Team: {teamName}");
        foreach (var worker in workers)
        {
            Console.WriteLine($" - {worker.Name} ({worker.Position})");
        }
    }

    public void ShowDetailedInfo()
    {
        Console.WriteLine($"Team: {teamName}");
        foreach (var worker in workers)
        {
            Console.WriteLine($"\nWorkday of {worker.Name} ({worker.Position}):");
            worker.FillWorkDay();
        }
    }
}
