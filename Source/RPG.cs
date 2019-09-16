using System;
using MoonSharp.Interpreter;
using MoonSharp.Interpreter.Loaders;
using MoonSharp.VsCodeDebugger;


namespace Lua_Example
{
    using Lua = Script;

    /// ---------------------------
    /// The main class for our superb RPG
    /// ---------------------------

    [MoonSharpUserData]
    public class RPG
    {
        public const string SCRIPT_PATH = "Scripts/";
        Lua lua = new Lua();
        bool quit = false;
        Room currentRoom;

        /// 
        /// The main entry point for the application.
        /// 

        [STAThread]
        static void Main(string[] args)
        {
            RPG rpg = new RPG();
            rpg.Go();
        }



        public RPG()
        {

            // lua.OpenTableLib();
            // lua.OpenBaseLib();            
            // lua.Options.ScriptLoader = new MyCustomScriptLoader() {
            //     ModulePaths = new string[] { "Data/?.lua" }
            // };


            // lua.RegisterFunction("CreateRoom", this, this.GetType().GetMethod("CreateRoom"));
            // lua.RegisterFunction("CreateNPC", this, this.GetType().GetMethod("CreateNPC"));
            // lua.RegisterFunction("AddNPCToRoom", this, this.GetType().GetMethod("AddNPCToRoom"));
            // lua.RegisterFunction("SetStartRoom", this, this.GetType().GetMethod("SetStartRoom"));
            UserData.RegisterType<Room>();
            UserData.RegisterType<NPC>();

            lua.Globals["CreateRoom"] = (Func<string, Room>)CreateRoom;
            lua.Globals["CreateNPC"] = (Func<string, NPC>)CreateNPC;
            lua.Globals["AddNPCToRoom"] = (Action<Room, NPC>)AddNPCToRoom;
            lua.Globals["SetStartRoom"] = (Action<Room>)SetStartRoom;
            lua.Globals["ClearScreen"] = (Action)ClearScreen;
            lua.DoFile(SCRIPT_PATH + "setup.lua");
        }

        public void Go()
        {
            Console.WriteLine("Welcome to the cool RPG Game");
            Console.WriteLine("\tPress q to quit!\n\r");
            while (quit == false)
            {
                Explore(currentRoom);
                Console.Write(">");
                string ans = Console.ReadLine();
                ClearScreen();

                currentRoom.CheckInteractions(ans);
                if (ans == "q")
                    quit = true;
            }

            Console.WriteLine("Goodbye");
        }


        public Room CreateRoom(string roomName)
        {
            return new Room(roomName, lua);
        }

        public NPC CreateNPC(string npcName)
        {
            return new NPC(npcName, lua);
        }

        public void SetStartRoom(Room r)
        {
            currentRoom = r;
        }

        public void AddNPCToRoom(Room r, NPC n)
        {
            r.AddNPC(n);
        }


        public void Explore(Room r)
        {
            Console.WriteLine("You are in: " + r.Name);
            Console.WriteLine(r.Description);
            r.DescribeOccupants();
            Console.WriteLine();
            r.DisplayInteractions();

        }

        //Write 50 blank lines should clear the terminal
        public void ClearScreen()
        {
            for (int i = 0; i < 50; i++)
                Console.WriteLine();
        }

    }


}