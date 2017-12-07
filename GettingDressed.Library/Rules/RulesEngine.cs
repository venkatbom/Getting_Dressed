using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GettingDressed.TemperatureType;
using GettingDressed.Library.Errors;

namespace GettingDressed.Rules
{
    public class RulesEngine : IRulesEngine
    {
        string IRulesEngine.processRules(string temperatureType, string commandList)
        {
            string returnValue = string.Empty;
            StringBuilder sbErrors = new StringBuilder();
            if (String.IsNullOrWhiteSpace(temperatureType))
            {
                sbErrors.Append(ErrorConstants.VALID_TEMPERATURE);
                sbErrors.Append(Environment.NewLine);
            }
            if (string.IsNullOrWhiteSpace(commandList))
            {
                sbErrors.Append(ErrorConstants.VALID_COMMANDS);
                sbErrors.Append(Environment.NewLine);
            }
            if (sbErrors != null && sbErrors.Length > 0)
            {
                return sbErrors.ToString();
            }

            if (temperatureType.ToLowerInvariant().Equals(
                EnumTemperatureType.Hot.ToString().ToLowerInvariant()))
            {
                returnValue = processHotRules(temperatureType, commandList);
            }
            else if (temperatureType.ToLowerInvariant().Equals(
                EnumTemperatureType.Cold.ToString().ToLowerInvariant()))
            {
                returnValue = processColdRules(temperatureType, commandList);
            }
            else
            {
                returnValue = ErrorConstants.GENERIC_INPUT_ERROR;
            }
            return returnValue;
        }
        private string processHotRules(string temperatureType, string commandList)
        {
            List<String> rejectedCommands = new List<String>() { "3", "5" };
            List<string> finalResponseList = new List<string>();
            string response = string.Empty;
            var commands = commandList.Split(',');
            if (commands.Length > 0)
            {
                if (commands[0] != "8") { return "Fail"; }

                if (commands.Distinct().Count() < commands.Length)
                {
                    return generateResponse(temperatureType, commands.Distinct().ToArray(),
                        ref finalResponseList, ErrorConstants.DUPLICATE_COMMAND);
                }

                HashSet<String> masterIds = new HashSet<string>(MasterData.getData().Select(s => s.Id.Trim()));
                var results = commands.Where(x => !masterIds.Contains(x.Trim())).ToList();
                if (results != null && results.Count() > 0)
                {
                    return generateResponse(temperatureType, commands,
                        ref finalResponseList, ErrorConstants.INVALID_COMMAND);
                }

                // put on socks or put on jacket - send fail
                if (commands.Contains("6") && commands.Contains("1"))
                {
                    var pantsIndex = Array.FindIndex(commands, row => row == "6");
                    var footwearIndex = Array.FindIndex(commands, row => row == "1");
                    if (pantsIndex > footwearIndex)
                    {
                        return generateResponse(temperatureType, commands,
                            ref finalResponseList, ErrorConstants.SOCKS_MUST_BE_PUT_ON);
                    }
                }
                if (commands.Contains("4") && commands.Contains("2"))
                {
                    var shirtIndex = Array.FindIndex(commands, row => row == "4");
                    var headIndex = Array.FindIndex(commands, row => row == "2");
                    if (shirtIndex > headIndex)
                    {
                        return generateResponse(temperatureType, commands,
                            ref finalResponseList, ErrorConstants.SHIRT_MUSTBEPUT_BEFORE_HEADWEAR);
                    }
                }

                response = generateResponse(temperatureType, commands, ref finalResponseList);

            }
            return response;
        }
        private string processColdRules(string temperatureType, string commandList)
        {
            List<string> finalResponseList = new List<string>();
            string response = string.Empty;
            var commands = commandList.Split(',');
            if (commands.Length > 0)
            {
                if (commands[0] != "8") { return ErrorConstants.FAILED; }

                if (commands.Distinct().Count() < commands.Length)
                {
                    return generateResponse(temperatureType, commands.Distinct().ToArray(),
                        ref finalResponseList, ErrorConstants.DUPLICATE_COMMAND);
                }

                // check whether the command ids are not in the golden data
                HashSet<String> masterIds = new HashSet<string>(MasterData.getData().Select(s => s.Id.Trim()));
                var results = commands.Where(x => !masterIds.Contains(x.Trim())).ToList();
                if (results != null && results.Count() > 0)
                {
                    return generateResponse(temperatureType, commands,
                        ref finalResponseList, ErrorConstants.INVALID_COMMAND);
                }

                // put on socks or put on jacket - send fail
                if (commands.Contains("6") && commands.Contains("1"))
                {
                    var pantsIndex = Array.FindIndex(commands, row => row == "3");
                    var footwearIndex = Array.FindIndex(commands, row => row == "1");
                    if (pantsIndex > footwearIndex)
                    {
                        return generateResponse(temperatureType, commands,
                            ref finalResponseList, ErrorConstants.SOCKS_MUST_BE_PUT_ON);
                    }
                }
                if (commands.Contains("3") && commands.Contains("1"))
                {
                    var socksIndex = Array.FindIndex(commands, row => row == "3");
                    var footWearIndex = Array.FindIndex(commands, row => row == "1");
                    if (socksIndex > footWearIndex)
                    {
                        return generateResponse(temperatureType, commands,
                            ref finalResponseList, ErrorConstants.PANTS_MUSTBEPUT_BEFORE_FOOTWEAR);
                    }
                }
                if (commands.Contains("4"))
                {
                    var shirtIndex = Array.FindIndex(commands, row => row == "4");
                    if (commands.Contains("2"))
                    {
                        var headWearIndex = Array.FindIndex(commands, row => row == "2");
                        if (shirtIndex > headWearIndex)
                        {
                            return generateResponse(temperatureType, commands,
                                ref finalResponseList, ErrorConstants.SHIRT_MUSTBEPUT_BEFORE_HEADWEAR);
                        }
                        var jacketIndex = Array.FindIndex(commands, row => row == "5");
                        if (shirtIndex > jacketIndex)
                        {
                            return generateResponse(temperatureType, commands,
                                ref finalResponseList, ErrorConstants.SHIRT_MUSTBEPUT_BEFORE_JACKET);
                        }
                    }
                }

                response = generateResponse(temperatureType, commands, ref finalResponseList);

            }
            return response;
        }
        private string generateResponse(string temperatureType, string[] commands,
            ref List<String> finalResponse, string errorDesc = "")
        {

            foreach (var item in commands)
            {
                var command = MasterData.getDescription(item);
                if (command != null)
                {
                    if (temperatureType.ToLowerInvariant().Equals(
                        EnumTemperatureType.Hot.ToString().ToLowerInvariant()))
                    {
                        finalResponse.Add(command.HotResponse);
                        if (command.HotResponse.Equals("fail"))
                        {
                            finalResponse.Add("fail");
                            return string.Join(",", finalResponse.Distinct());
                        }

                    }
                    else if (temperatureType.ToLowerInvariant().Equals(
                        EnumTemperatureType.Cold.ToString().ToLowerInvariant()))
                    {
                        finalResponse.Add(command.ColdResponse);
                    }

                }
            }
            switch (errorDesc)
            {
                case "invalidcommand":
                case "socksputonbeforefootwear":
                case "duplicate":
                case "shirtmustbeputbeforeheadwear":
                case "shirtmustbeputonbeforejacket":
                case "pantsmustbeputbeforefootwear":
                    finalResponse.Add("fail");
                    break;
            }

            if (commands[commands.Length - 1] != "7" && String.IsNullOrWhiteSpace(errorDesc))
            {
                finalResponse.Add("fail");
            }
            if (temperatureType.ToLowerInvariant().Equals(
                EnumTemperatureType.Cold.ToString().ToLowerInvariant()) &&
                !finalResponse.Contains("fail") &&
                commands.Count() != MasterData.getData().Count())
            {
                finalResponse.Add("fail");
            }
            return String.Join(",", finalResponse.Distinct());
        }
    }
}
