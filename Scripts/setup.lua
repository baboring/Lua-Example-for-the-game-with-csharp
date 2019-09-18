---
--- Setup Script
---
-- load_assembly("Lua_Example"); 
-- NPC = import_type("Lua_Example.NPC");

ClearScreen();

--Create the forest
start = CreateRoom("forest");
forest.this = start;
SetStartRoom(start);

--Create the Knight
npc = CreateNPC("knight");
knight.this = npc;

AddNPCToRoom(start, npc);

--Create the dungeon
room2 = CreateRoom("dungeon");
dungeon.this = room2;

--Create the passage from the forest to the dungeon
underground = CreatePassageWay("Steps surrounded by leaf litter", room2);
start:AddPassageWay(underground);

--Create the passage from the dungeon to the forest
overground = CreatePassageWay("a stone staircase", start);
room2:AddPassageWay(overground);