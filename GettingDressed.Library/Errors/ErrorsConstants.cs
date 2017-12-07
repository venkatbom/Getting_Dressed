using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingDressed.Library.Errors
{
    public static class ErrorConstants
    {
        public static string DUPLICATE_COMMAND = "duplicate";
        public static string VALID_TEMPERATURE = "Please input valid (Hot/Cold) Temperature Type";
        public static string VALID_COMMANDS = "Please input valid (range starting from 1 to 8) commands";
        public static string GENERIC_INPUT_ERROR = "Please enter valid temperature / commands to process";
        public static string INVALID_COMMAND = "invalidcommand";
        public static string SOCKS_MUST_BE_PUT_ON = "socksputonbeforefootwear";
        public static string SHIRT_MUSTBEPUT_BEFORE_HEADWEAR = "shirtmustbeputbeforeheadwear";
        public static string PANTS_MUSTBEPUT_BEFORE_FOOTWEAR = "pantsmustbeputbeforefootwear";
        public static string SHIRT_MUSTBEPUT_BEFORE_JACKET = "shirtmustbeputonbeforejacket";
        public static string FAILED = "Fail";

    }
}
