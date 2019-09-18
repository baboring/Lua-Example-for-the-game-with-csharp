
----
--Our Dungeon Room
---

--Create a forest Table--
dungeon = {};

function onEnter()
 --print("You enter the dungeon.");
 seenTreasure = 1;
end;

dungeon.description = "A small room with irregular stone walls. It's damp and dark. Also there are piles of glittering treasure.";
dungeon.name = "Dank Dungeon";

dungeon.OnEnter = onEnter;