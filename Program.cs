using System;
using Newtonsoft.Json;
using System.IO;
using System.Linq;

namespace server_manager
{
    class Program
    {
        public static strings s = new strings();

        // Settings
        public static bool Remote = false;
        public static string loc = "default";
        public static int port = 8080;

        static void Main(string[] args)
        {
            s.setStrings(loc);

            string settingsloc = "./config/settings.json";
            if(args.Contains("-c"))
            {
                settingsloc = getarg("-c", args);
            }
            string jsonContent = File.ReadAllText(settingsloc);
            var settingsObject = JsonConvert.DeserializeObject<dynamic>(jsonContent);
            Remote = (bool)settingsObject.remote;
            loc = (string)settingsObject.loc;
            port = (int)settingsObject.port;
            if (Remote)
            {
                Console.WriteLine(getstring("startingWeb", strings.dicts.notice));
                webserver Server = new webserver(port);
            }

            Console.Title = "Server Manager by LucasAmmer";
            while (true)
            {

            }
        }

        public static string getstring(string key, strings.dicts dict)
        {
            if (dict == strings.dicts.errors)
            {
                s.errors.TryGetValue(key, out string temp);
                return temp;
            }
            else if(dict == strings.dicts.notice){
                s.notice.TryGetValue(key, out string temp);
                return temp;
            }
            else
            {
                s.errors.TryGetValue("invalidDict", out string temp);
                throw new Exception(temp);
            }
        }

        public static string getarg(string argname, string[] args)
        {
            if (args.Contains(argname) && args.Length - 1 > Array.IndexOf(args, argname))
            {
                return args[Array.IndexOf(args, argname) + 1];
            }else if(args.Contains(argname) && args.Length - 1 !> Array.IndexOf(args, argname))
            {
                string e;
                s.errors.TryGetValue("noValue", out e);
                throw new Exception(e);
            }
            else if(!args.Contains(argname))
            {
                string e;
                s.errors.TryGetValue("notInArgs", out e);
                throw new Exception(e);
            }
            return "";
        }
    }
}
