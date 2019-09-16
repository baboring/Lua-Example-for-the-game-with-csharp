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
            Console.WriteLine("\tPress q to quit!");
            while (quit == false)
            {
                Console.Write(">");
                string ans = Console.ReadLine();

                if (ans == "q")
                    quit = true;
            }

            Console.WriteLine("Goodbye");
        }
    }
}