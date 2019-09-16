using System;
using MoonSharp.Interpreter;
using MoonSharp.VsCodeDebugger;

namespace Lua_Example
{
    using Lua = Script;

    public class Room
    {
        private Lua scriptPower;
        private string scriptName;
        private string name;

        public string Name
        {
            get
            {
                return (string)scriptPower.Globals[name + ".name"];
            }
        }

        public string Description
        {
            get
            {
                return (string)scriptPower.Globals[name + ".description"];
            }
        }


        public Room(string name, Lua lua)
        {
            this.name = name;
            scriptName = name + ".lua";
            scriptPower = lua;
            scriptPower.DoFile("Scripts/" + scriptName);
        }


    }

}