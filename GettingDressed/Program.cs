using GettingDressed.Rules;
using System;
using Ninject;
using Ninject.Modules;
namespace GettingDressed
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                processHotTemperature();
                processColdTemperature();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.Read();
            }
        }

        private static void processHotTemperature()
        {
            Console.WriteLine();
            Console.WriteLine("Process Hot temperature");
            String type = "HOT";
            String commands = string.Empty;

            IRulesEngine iRules = new RulesEngine();
            Console.WriteLine(iRules.processRules(type, commands));

            Console.WriteLine("SUCCESS:");
            commands = "8,6,4,2,1,7";

            Console.WriteLine(iRules.processRules(type, commands));
            Console.WriteLine();

            Console.WriteLine("FAILURE:");

            commands = "8,6,5";
            Console.WriteLine(iRules.processRules(type, commands));

            commands = "8,6,3";
            Console.WriteLine(iRules.processRules(type, commands));

            commands = "8,6,5,1";
            Console.WriteLine(iRules.processRules(type, commands));

            Console.WriteLine();
        }
        private static void processColdTemperature()
        {
            Console.WriteLine("Process Cold temperature");
            Console.WriteLine();
            String type = "COLD";
            String commands = string.Empty;
            IRulesEngine iRules = new RulesEngine();
            Console.WriteLine("SUCCESS: ");
            
            commands = "8,6,3,4,2,5,1,7";
            Console.WriteLine(iRules.processRules(type, commands));

            Console.WriteLine("FAILURE:");
            commands = "8,6,3,4,2,5,7";
            Console.WriteLine(iRules.processRules(type, commands));
            
            commands = "6";
            Console.WriteLine(iRules.processRules(type, commands));
            Console.WriteLine();
        }

    }
}
