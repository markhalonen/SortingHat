using AForge.Genetic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingHat
{
    public class FitnessCalculator : IFitnessFunction
    {
        public double Evaluate(IChromosome chromosome)
        {
            League L = (League)chromosome;
            return L.getFitness();
        }
    }
}
