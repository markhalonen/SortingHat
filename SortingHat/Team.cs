using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingHat
{
    public class Team : List<TeamMember>
    {
        //public  members = new List<TeamMember>();

        public void AddMember(TeamMember mem)
        {
            mem.team = this;
            Add(mem);
        }
        
        public double getFitness()
        {
            double fitness = 0.0;
            foreach (TeamMember member in this)
                fitness += member.getFitness();
            return fitness;
        }

        internal Team Clone()
        {
            Team t = new Team();
            foreach (TeamMember member in this)
                t.AddMember(member.Clone());
            return t;
        }

        public Boolean hasCommonMemberWith(Team team)
        {
            foreach(TeamMember member in team)
            {
                foreach(TeamMember member2 in this)
                {
                    if (member.Email.Equals(member2.Email))
                        return true;
                }
            }
            return false;
        }

        public Boolean containsMember(TeamMember member)
        {
            foreach(TeamMember mem in this)
            {
                if (mem.Email.Equals(member.Email))
                    return true;
            }
            return false;
        }

        public override string ToString()
        {
            String s = "";
            foreach (TeamMember member in this)
                s += member.Email + "\n";
            return s;
        }

    }
}
