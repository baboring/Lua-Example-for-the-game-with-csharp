using System;
using MoonSharp.Interpreter;
using MoonSharp.VsCodeDebugger;
using System.Collections;
using MoonSharp.Interpreter.Interop;

namespace Lua_Example
{
    public class PassageWay
    {
        public string description;
        public Room destination;
        public string key = "p";



        public PassageWay(string describe, Room leadsto)
        {
            destination = leadsto;
            description = describe;
        }


    }
}