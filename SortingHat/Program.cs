using AForge.Genetic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingHat
{
    class Program
    {
        static void Main(string[] args)
        {
            TeamMember mem1 = new TeamMember("Mem1");
            TeamMember mem2 = new TeamMember("Mem2");
            TeamMember mem3 = new TeamMember("Mem3");
            TeamMember mem4 = new TeamMember("Mem4");
            TeamMember mem5 = new TeamMember("Mem5");
            TeamMember mem6 = new TeamMember("Mem6");
            TeamMember mem7 = new TeamMember("Mem7");
            TeamMember mem8 = new TeamMember("Mem8");
            TeamMember mem9 = new TeamMember("Mem9");
            TeamMember mem10 = new TeamMember("Mem10");
            mem1.preferredTeammates.Add(mem2);
            mem2.preferredTeammates.Add(mem3);
            mem3.preferredTeammates.Add(mem4);
            mem4.preferredTeammates.Add(mem5);

            mem6.preferredTeammates.Add(mem7);
            mem7.preferredTeammates.Add(mem8);
            mem8.preferredTeammates.Add(mem9);
            mem9.preferredTeammates.Add(mem10);

            List<TeamMember> pop = new List<TeamMember>();
            pop.Add(mem1);
            pop.Add(mem3);
            pop.Add(mem2);
            pop.Add(mem4);
            pop.Add(mem5);
            pop.Add(mem6);
            pop.Add(mem7);
            pop.Add(mem8);
            pop.Add(mem9);
            pop.Add(mem10);

            Console.WriteLine(TheSortingHat.sortTeamMembers(pop, 2).getFitness());
            Console.ReadKey();
        }
    }
}
