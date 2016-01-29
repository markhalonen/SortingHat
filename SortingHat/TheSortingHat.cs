using AForge.Genetic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingHat
{
    public static class TheSortingHat
    {
        public static League sortTeamMembers(List<TeamMember> members, int numTeams)
        {
            League league = new League(members, numTeams);

            Population population = new Population(members.Count, league, new FitnessCalculator(), new EliteSelection());
            population.MutationRate = .5;
            population.CrossoverRate = .2;
            population.RunEpoch();
            //run epoch until you get the same best chromosome 10 times
            double bestFitness = -Double.MaxValue;
            int count = 0;
            while(count < 5000)
            {
                population.RunEpoch();
                double fitness = ((League)population.BestChromosome).getFitness();
                Console.WriteLine("Fitness: " + fitness);
                if (fitness > bestFitness)
                {
                    
                    bestFitness = fitness;
                    count = 0;
                }
                else
                {
                    count++;
                }
            }

            //while (((League)population.BestChromosome).getFitness() != 80.0)
            //    population.RunEpoch();
            League best = ((League)population.BestChromosome);
            return best;
        }
    }
}
