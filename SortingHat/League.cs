using AForge.Genetic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingHat
{
    public class League : IChromosome
    {
        public List<Team> teams = new List<Team>();
        //public List<TeamMember> population = new List<TeamMember>();
        public int numTeams;
        Random rand = new Random();

        public League(List<TeamMember> pop, int numTeams)
        {
            this.numTeams = numTeams;
            for(int i = 0; i < pop.Count; i++)
            {
                if(teams.Count < numTeams)
                {
                    Team t1 = new Team();
                    t1.AddMember(pop.ElementAt(i));
                    teams.Add(t1);
                }
                else
                {
                    teams.ElementAt(i % numTeams).AddMember(pop.ElementAt(i));
                }
            }
        }

        public List<TeamMember> getPopulationClone()
        {
            List<TeamMember> list = new List<TeamMember>();
            foreach(Team t in teams)
            {
                list.AddRange(t.Clone());
            }
            return list;
        }

        public List<TeamMember> getPopulation()
        {
            List<TeamMember> list = new List<TeamMember>();
            foreach (Team t in teams)
            {
                list.AddRange(t);
            }
            return list;
        }

        public double Fitness
        {
            get
            {
                return getFitness();
            }
        }

        public IChromosome Clone()
        {
            League l = new League(getPopulationClone(), numTeams);
            return l;
        }

        public int CompareTo(Object obj)
        {
            League l = (League)obj;
            return Fitness - l.Fitness > 0 ? -1 : 1;
        }

        public IChromosome CreateNew()
        {
            League league = new League(getPopulationClone(), numTeams);
            return league;
        }

        public void Crossover(IChromosome pair)
        {
            //strategy: 
            //1. A new league is to be formed. 
            //2. Team 1 is added from this league to the new league
            //3. From the input league, if a team is mutually exclusive to all team members in the new team.
            //4. From this league, do the same thing.
            //5. Continue until teams run out.
            //6. Fill in the remaining teams randomly.
            League L2 = (League)pair;
            League hybrid = new League(getPopulationClone(), numTeams);
            hybrid.teams = new List<Team>();
            //hybrid.teams.Add(teams.ElementAt(0));

            for(int i = 0; i < teams.Count; i++)
            {
                Team L1Team = teams.ElementAt(i);
                Team L2Team = L2.teams.ElementAt(i); //they should have the same number of teams.
                if (!hybrid.teamsHaveCommonMemberWith(L1Team))
                    hybrid.teams.Add(L1Team);
                if (!hybrid.teamsHaveCommonMemberWith(L2Team))
                    hybrid.teams.Add(L2Team);
            }

            //fill existing teams into hybrid.
            List<TeamMember> remainingMembers = hybrid.membersNotOnATeam();
            int previousTeams = hybrid.teams.Count;
            int idx = 0;
            while (remainingMembers.Count > 0)
            {
                TeamMember remove = remainingMembers.ElementAt(0);
                remainingMembers.RemoveAt(0);
                if (numTeams > hybrid.teams.Count)
                {
                    Team addTeam = new Team();
                    addTeam.AddMember(remove);
                    hybrid.teams.Add(addTeam);
                }
                else
                {
                    hybrid.teams.ElementAt(previousTeams - 1 + idx % (numTeams - previousTeams)).AddMember(remove);
                }
                idx++;
            }
            this.teams = hybrid.teams;
            //L.teams
            //crossover does nothing right now
        }

        public void Evaluate(IFitnessFunction function)
        {
            //Console.WriteLine(getFitness());
            FitnessCalculator c = (FitnessCalculator)function;
            c.Evaluate(this);
        }

        public void Generate()
        {
            throw new NotImplementedException();
        }

        public double getFitness()
        {
            double fitness = 0.0;
            foreach (Team team in teams)
            {
                //Console.WriteLine("Team Fitness: " + team.getFitness());
                fitness += team.getFitness();
            }
            return fitness;
        }

        public void Mutate()
        {
            List<TeamMember> pop = getPopulation();
            TeamMember mem1 = pop.ElementAt(rand.Next(0, pop.Count - 1));
            TeamMember mem2 = pop.ElementAt(rand.Next(0, pop.Count - 1));
            while (mem1.team.Equals(mem2.team))
            {
                mem2 = pop.ElementAt(rand.Next(0, pop.Count - 1));
            }
            //switch the members teams.
            Team mem1Team = mem1.team;
            Team mem2Team = mem2.team;
            mem1Team.Remove(mem1);
            mem1Team.AddMember(mem2);

            mem2Team.Remove(mem2);
            mem2Team.AddMember(mem1);
        }

        private bool teamsHaveCommonMemberWith(Team inputTeam)
        {
            bool common = false;
            foreach(Team team in teams)
            {
                if (team.hasCommonMemberWith(inputTeam))
                {
                    common = true;
                    break;
                }
            }
            return common;
        }

        private List<TeamMember> membersNotOnATeam()
        {
            List<TeamMember> list = new List<TeamMember>();
            foreach(TeamMember member in getPopulationClone())
            {
                if (!memberIsOnATeam(member))
                    list.Add(member);
            }
            return list;
        }

        private bool memberIsOnATeam(TeamMember member)
        {
            foreach(Team t in teams)
            {
                if(t.containsMember(member))
                    return true;
            }
            return false;
        }

        public override string ToString()
        {
            String s = "";
            for(int i = 0; i < teams.Count; i++)
            {
                s += "Team " + i.ToString() + ":\n" + teams.ElementAt(i).ToString();
            }
            return s;
        }
    }
}
