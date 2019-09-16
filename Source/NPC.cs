using System;
using MoonSharp.Interpreter;
using MoonSharp.VsCodeDebugger;

namespace Lua_Example
{
    using Lua = Script;

    public class NPC
    {
        #region common format
        private Lua scriptPower;
        private string scriptName;
        private string name;

        #endregion


        // ----- interaction
        public string interactKey;


        public string Name
        {
            get
            {
               return (scriptPower.Globals[name] as Table).Get("name").String;
            }
        }

        public string Description
        {
            get
            {
               return (scriptPower.Globals[name] as Table).Get("description").String;
            }
        }


        public NPC(string name, Lua lua)
        {
            this.name = name;
            this.interactKey = name[0].ToString();
            scriptName = name + ".lua";
            scriptPower = lua;
            scriptPower.DoFile(RPG.SCRIPT_PATH + scriptName);
        }




        public void Interact()
        {
            string answer = "";
            while (answer != "x")
            {
                Console.WriteLine("You are interacting with " + Name);
                Console.WriteLine("\tx to exit");
                Console.WriteLine("\tt to talk");
                Console.WriteLine("\tl to look");

                Console.Write(">");
                answer = Console.ReadLine();

                if (answer == "l")
                {
                    Console.WriteLine(this.Description);
                }
            }
        }


    }

}