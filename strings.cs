using System;
using System.Collections.Generic;
using System.Text;

namespace server_manager
{
    class strings
    {
        public enum dicts
        {
            errors,
            notice,
        }

        public Dictionary<string, string> errors = new Dictionary<string, string>();
        public Dictionary<string, string> notice = new Dictionary<string, string>();
        
        public void setStrings(string loc)
        {
            if(loc == "en" || loc == "default")
            {
                // Errors
                errors.Add("noValue", "No value set!");
                errors.Add("notInArgs", "Arguement not found in args");
                errors.Add("invalidDict", "Dictonary invalid");

                // Notices
                notice.Add("startingWeb", "Starting webserver");
            }
            else
            {
                Console.WriteLine("Invalid language, using default");
            }
        }
    }
}
