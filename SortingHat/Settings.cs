using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingHat
{
    public static class Settings
    {
        private static double preferredTeammateWeight = 10;
        public static double PreferredTeammateWeight
        {
            get
            {
                return preferredTeammateWeight;
            }

            set
            {
                preferredTeammateWeight = value;
            }
        }

        private static double unpreferredTeammateWeight = -10;
        public static double UnpreferredTeammateWeight
        {
            get
            {
                return unpreferredTeammateWeight;
            }

            set
            {
                unpreferredTeammateWeight = value;
            }
        }

        //public static int numTeams;

    }
}
