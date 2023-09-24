using System;
using System.Collections.Generic;
using System.Text;

namespace server_manager
{
    class project
    {
        public string name { get; set; } = "";
        public string location { get; set; } = "projects/";
        public string command { get; set; } = "";
        public string desc { get; set; } = "";
        public bool autostart { get; set; } = false;
        public string[] options { get; }

        private strings dict;

        public project(string o, strings dict)
        {
            this.dict = dict;
            options = o.Trim().ToLower().Split(";");
        }

        public void init()
        {
            if(command == "")
            {
                throw new Exception(Program.getstring("noCmd", strings.dicts.errors).Replace("{name}", name));
            }
        }
        
        public void start()
        {
            throw new NotImplementedException();
        }
    }
}
