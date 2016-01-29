using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingHat
{
    public class TeamMember
    {
        private String email;
        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }
        public TeamMember(String em)
        {
            Email = em;
        }
        public List<TeamMember> preferredTeammates = new List<TeamMember>();
        public List<TeamMember> unprefferedTeammates = new List<TeamMember>();
        public Team team;
        public TeamMember Clone()
        {
            TeamMember member = new TeamMember(email);
            member.preferredTeammates = preferredTeammates;
            member.unprefferedTeammates = unprefferedTeammates;
            return member;
        }

        public double getFitness()
        {
            double fitness = 0.0;
            foreach(TeamMember member in team)
            {
                if(member.Equals(this))
                    continue;
                foreach(TeamMember friend in preferredTeammates)
                {
                    if(friend.email.Equals(member.email))
                        fitness += Settings.PreferredTeammateWeight;
                }
                foreach(TeamMember enemy in unprefferedTeammates)
                {
                    if(enemy.email.Equals(member.email))
                        fitness += Settings.UnpreferredTeammateWeight;
                }
            }
            return fitness;
        }
    }

}