using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingDressed.Rules
{
    public static class MasterData
    {
        public static List<Command> getData()
        {
            return new List<Command>()
            {
                new Command()
                {
                    Id = "1",
                    Description = "Put on footwear",
                    HotResponse = "sandals",
                    ColdResponse = "boots"
                },
                new Command()
                {
                    Id = "2",
                    Description = "Put on Headwear",
                    HotResponse = "sunglasses",
                    ColdResponse = "hat"
                },
                new Command()
                {
                    Id = "3",
                    Description = "Put on Socks",
                    HotResponse = "fail",
                    ColdResponse = "socks"
                },
                new Command()
                {
                    Id = "4",
                    Description = "Put on shirt",
                    HotResponse = "shirt",
                    ColdResponse = "shirt"
                },
                new Command()
                {
                    Id = "5",
                    Description = "Put on Jacket" ,
                    HotResponse = "fail",
                    ColdResponse = "jacket"
                },
                new Command()
                {
                    Id = "6",
                    Description = "Put on Pants",
                    HotResponse = "shorts",
                    ColdResponse = "pants"
                },
                new Command()
                {
                    Id = "7",
                    Description = "Leave House",
                    HotResponse = "Leaving House" ,
                    ColdResponse = "Leaving House"
                },
                new Command()
                {
                    Id = "8",
                    Description = "Take off pajamas",
                    HotResponse = "Removing PJs",
                    ColdResponse = "Removing PJs"
                }
            };

        }
        public static Command getDescription(string id)
        {
            return getData().Where(x => x.Id == id).Select(x => x).FirstOrDefault();
        }
    }
}
