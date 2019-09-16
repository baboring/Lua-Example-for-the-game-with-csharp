----
--Our Forest Room
---

--Create a forest Table--
forest = {};

--What to do on entering the forest--
function onEnter()
 print("You enter the forest");
end;

--Add some text--
forest.description = "A deep dark foreboding forest. A bit scary.";
forest.name = "Dark Forest";

--Add a function pointer--
forest.OnEnter = onEnter;