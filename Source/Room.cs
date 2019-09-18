using System;
using MoonSharp.Interpreter;
using MoonSharp.VsCodeDebugger;
using System.Collections;
using MoonSharp.Interpreter.Interop;

namespace Lua_Example
{
    using Lua = Script;

    public class Room
    {
        private Lua scriptPower;
        private string scriptName;
        private string name;


        private ArrayList npcList = new ArrayList();
        private ArrayList wayList = new ArrayList();

        [MoonSharpVisible(true)]
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

        public Room(string name, Lua lua)
        {
            this.name = name;
            scriptName = name + ".lua";
            scriptPower = lua;
            scriptPower.DoFile(RPG.SCRIPT_PATH + scriptName);
        }


        public void AddPassageWay(PassageWay pw)
        {
            wayList.Add(pw);
        }

        public void DescribeOccupants()
        {

            foreach (PassageWay pw in wayList)
            {
                Console.WriteLine(pw.description);
            }

            foreach (NPC n in npcList)
            {
                Console.WriteLine("There is a " + n.Name + " here.");
            }


        }

        public void AddNPC(NPC npc)
        {
            npcList.Add(npc);
        }

        public void DisplayInteractions()
        {
            foreach (NPC n in npcList)
            {
                Console.WriteLine("Press " + n.interactKey +
                 " to interact with " + n.Name);
            }

            foreach (PassageWay pw in wayList)
            {
                Console.WriteLine("Press " + pw.key + " to use the "
                 + pw.description);
            }
        }

        public void CheckInteractions(ref Room currentRoom, string keypress)
        {
            foreach (NPC n in npcList)
            {
                if (n.interactKey == keypress)
                {
                    n.Interact();
                    return;
                }
            }

            foreach (PassageWay pw in wayList)
            {
                if (pw.key == keypress)
                {
                    currentRoom = pw.destination;
                    currentRoom.OnEnter();
                }
            }
        }

        public void OnEnter()
        {
            scriptPower.DoString(name + ":OnEnter()");
        }

        // OnLeave
        // OnPush
        // OnGive
        // OnStealFrom
        // OnDeath

    }

}