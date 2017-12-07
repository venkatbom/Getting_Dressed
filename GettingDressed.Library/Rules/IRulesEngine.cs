using GettingDressed.TemperatureType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingDressed.Rules
{
    public interface IRulesEngine
    {
        string processRules(string temperatureType, string commandList);
    }
}
