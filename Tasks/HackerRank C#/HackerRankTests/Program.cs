using System;
namespace Solution
{
    public class Team
    {
        public Team(string teamName, int noOfPlayers)
        {
            this.TeamName = teamName;
            this.NoOfPlayers = noOfPlayers;
        }
        public string TeamName { get; set; }
        public int NoOfPlayers { get; set; }

        public void AddPlayer(int count)
        {
            this.NoOfPlayers += count;
        }

        public bool RemovePlayer(int count)
        {
            if (count > this.NoOfPlayers)
            {
                return false;
            }
            this.NoOfPlayers -= count;
            return true;

        }
    }

    public class Subteam : Team
    {
        public Subteam(string teamName, int noOfPlayers)
        : base(teamName, noOfPlayers)
        {
        }
        public void ChangeTeamName(string name)
        {
            this.TeamName = name;
        }

    }
    class Solution
    {
        static void Main(string[] args)
        {

            if (!typeof(Subteam).IsSubclassOf(typeof(Team)))
            {
                throw new Exception("Subteam class should inherit from Team class");
            }

            String str = Console.ReadLine();
            String[] strArr = str.Split();
            string initialName = strArr[0];
            int count = Convert.ToInt32(strArr[1]);
            Subteam teamObj = new Subteam(initialName, count);
            Console.WriteLine("Team " + teamObj.TeamName + " created");

            str = Console.ReadLine();
            count = Convert.ToInt32(str);
            Console.WriteLine("Current number of players in team " + teamObj.TeamName + " is " + teamObj.NoOfPlayers);
            teamObj.AddPlayer(count);
            Console.WriteLine("New number of players in team " + teamObj.TeamName + " is " + teamObj.NoOfPlayers);


            str = Console.ReadLine();
            count = Convert.ToInt32(str);
            Console.WriteLine("Current number of players in team " + teamObj.TeamName + " is " + teamObj.NoOfPlayers);
            var res = teamObj.RemovePlayer(count);
            if (res)
            {
                Console.WriteLine("New number of players in team " + teamObj.TeamName + " is " + teamObj.NoOfPlayers);
            }
            else
            {
                Console.WriteLine("Number of players in team " + teamObj.TeamName + " remains same");
            }

            str = Console.ReadLine();
            teamObj.ChangeTeamName(str);
            Console.WriteLine("Team name of team " + initialName + " changed to " + teamObj.TeamName);
        }
    }
}