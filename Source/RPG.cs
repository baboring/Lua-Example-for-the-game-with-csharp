using System;
using MoonSharp.Interpreter;
using MoonSharp.VsCodeDebugger;


namespace Lua_Example
{
    using Lua = Script;

    /// ---------------------------
    /// The main class for our superb RPG
    /// ---------------------------

    public class RPG
    {
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

                if (ans == "q")
                    quit = true;
            }

            Console.WriteLine("Goodbye");
        }

        public void Explore(Room r)
        {
            Console.WriteLine("You are in: " + r.Name);
            Console.WriteLine(r.Description);
        }

        //Write 50 blank lines should clear the terminal
        public void ClearScreen()
        {
            for (int i = 0; i < 50; i++)
                Console.WriteLine();
        }
    }
}