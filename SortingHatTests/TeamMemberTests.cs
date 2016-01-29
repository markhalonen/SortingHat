using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortingHat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingHat.Tests
{
    [TestClass()]
    public class TeamMemberTests
    {
        //is this from mark
        [TestMethod()]
        public void getFitnessTest()
        {
            //make a test 
            TeamMember mem1 = new TeamMember("Mem1");
            TeamMember mem2 = new TeamMember("Mem2");
            mem1.preferredTeammates.Add(mem2);
            mem2.unprefferedTeammates.Add(mem1);
            Team t1 = new Team();
            t1.AddMember(mem1);
            t1.AddMember(mem2);
            Assert.AreEqual(Settings.PreferredTeammateWeight, mem1.getFitness());
            Assert.AreEqual(Settings.UnpreferredTeammateWeight, mem2.getFitness());
        }

        [TestMethod()]
        public void CloneTest()
        {
            TeamMember mem = new TeamMember("Mem1");
            TeamMember clone = mem.Clone();
            Assert.AreNotEqual(mem, clone);
            Assert.AreEqual(mem.preferredTeammates, clone.preferredTeammates);
            Assert.AreEqual(mem.unprefferedTeammates, clone.unprefferedTeammates);
        }
    }
}