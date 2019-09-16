using System;
using MoonSharp.Interpreter;
using MoonSharp.Interpreter.Loaders;
using MoonSharp.VsCodeDebugger;


namespace Lua_Example
{
    public class MyCustomScriptLoader : ScriptLoaderBase
    {
        public override object LoadFile(string file, Table globalContext)
        {
            return string.Format("print ([[A request to load '{0}' has been made]])", file);
        }

        public override bool ScriptFileExists(string name)
        {
            return true;
        }
    }
}