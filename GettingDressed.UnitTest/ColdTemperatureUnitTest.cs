using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GettingDressed.Rules;
using GettingDressed.Library.Errors;

namespace GettingDressed.UnitTest
{
    [TestClass]
    public class ColdTemperatureUnitTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            String actualValue = "Fail";
            String type = "COLD";
            String commands = "6";
            IRulesEngine iRules = new RulesEngine();
            String expectedValue = iRules.processRules(type, commands);
            Assert.AreEqual(actual: actualValue, expected: expectedValue);
        }

        [TestMethod]
        public void TestMethod2()
        {
            String actualValue = "Removing PJs,pants,socks,shirt,hat,jacket,Leaving House,fail";
            String type = "COLD";
            String commands = "8,6,3,4,2,5,7";
            IRulesEngine iRules = new RulesEngine();
            String expectedValue = iRules.processRules(type, commands);
            Assert.AreEqual(actual: actualValue, expected: expectedValue);
        }

        [TestMethod]
        public void TestMethod3()
        {
            String actualValue = "Removing PJs,pants,socks,shirt,hat,boots,jacket,Leaving House";
            String type = "COLD";
            String commands = "8,6,3,4,2,1,5,7";
            IRulesEngine iRules = new RulesEngine();
            String expectedValue = iRules.processRules(type, commands);
            Assert.AreEqual(actual: actualValue, expected: expectedValue);
        }
    }
}
