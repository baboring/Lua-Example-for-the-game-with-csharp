----
--Knight NPC
---

--load_assembly("RPGLUA"); 
--NPC = import_type("RPGLUA.NPC");


--Create a knight Table--
if(knight == nil) then
    knight = {};
end
   

knight.description = "A tall knight wrapped in bulky armour. He seems to be shaking.";
knight.name = "A Knight";

function knight.OnTalk()
    if(seenTreasure == 0) then
        knight.this:Say("Ah I'm so scared! I have to find the kings treasure but I'm paralyzed "        
         .. "with fear! Please help me!"); 
       else
        knight.this:Say("What you found my treasure that's great. I'm so happy. I'll get it in a "       
         .. "bit! By the way game over");
       end;
end;