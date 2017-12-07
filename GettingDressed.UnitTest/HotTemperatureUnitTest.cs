using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GettingDressed.Rules;
using GettingDressed.Library.Errors;

namespace GettingDressed.UnitTest
{
    [TestClass]
    public class HotTemperatureUnitTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            String actualValue = "Removing PJs,shorts,shirt,sunglasses,sandals,Leaving House";
            String type = "HOT";
            String commands = "8,6,4,2,1,7";
            IRulesEngine iRules = new RulesEngine();
            String expectedValue = iRules.processRules(type, commands);
            Assert.AreEqual(actual: actualValue, expected: expectedValue);
        }

        [TestMethod]
        public void TestMethod2()
        {
            String actualValue = "Removing PJs,shorts,fail";
            String type = "HOT";
            String commands = "8,6,6";
            IRulesEngine iRules = new RulesEngine();
            String expectedValue = iRules.processRules(type, commands);
            Assert.AreEqual(actual: actualValue, expected: expectedValue);
        }

        [TestMethod]
        public void TestMethod3()
        {
            String actualValue = "Removing PJs,shorts,fail";
            String type = "HOT";
            String commands = "8,6,3";
            IRulesEngine iRules = new RulesEngine();
            String expectedValue = iRules.processRules(type, commands);
            Assert.AreEqual(actual: actualValue, expected: expectedValue);
        }


        [TestMethod]
        public void TestMethod4()
        {
            String actualValue = "Removing PJs,shorts,fail";
            String type = "HOT";
            String commands = "8,6,20";
            IRulesEngine iRules = new RulesEngine();
            String expectedValue = iRules.processRules(type, commands);
            Assert.AreEqual(actual: actualValue, expected: expectedValue);
        }


        [TestMethod]
        public void TestMethod5()
        {
            String actualValue = "Removing PJs,shorts,shirt,fail";
            String type = "HOT";
            String commands = "8,6,4,3,5,2,1,7";
            IRulesEngine iRules = new RulesEngine();
            String expectedValue = iRules.processRules(type, commands);
            Assert.AreEqual(actual: actualValue, expected: expectedValue);
        }


        [TestMethod]
        public void TestMethod6()
        {
            String actualValue = ErrorConstants.FAILED;
            String type = "HOT";
            String commands = "6";
            IRulesEngine iRules = new RulesEngine();
            String expectedValue = iRules.processRules(type, commands);
            Assert.AreEqual(actual: actualValue, expected: expectedValue);
        }
    }
}
