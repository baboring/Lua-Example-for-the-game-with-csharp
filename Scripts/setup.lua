---
--- Setup Script
---
--load_assembly("Lua_Example"); 

ClearScreen();

start = CreateRoom("forest");
SetStartRoom(start);
AddNPCToRoom(start, CreateNPC("knight"));
