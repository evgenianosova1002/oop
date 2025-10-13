using System;

class Program
{
    static void Main()
    {
        Team team = new Team("Team");

        team.AddWorker(new Developer("Oleg"));
        team.AddWorker(new Manager("Alex"));

        team.ShowTeamInfo();

        Console.WriteLine("\nDetailed Workday Report");
        team.ShowDetailedInfo();
    }
}
