# Final Fantasty 13-2 Clock Puzzle Solver
---

This is a solver for the annoying clock puzzles in Final Fantasty 12-2. Someone used to host a solver as a website but that site no longer exits. So after living through some mild hell I decided to write a solver. While this is a console app right now if someone knows how to put this on github pages easily please do and if you let me know I will link it.
You might be seeing this and be thinking "these puzzles are not that bad" and you would be wrong. These are hell. 

---
## How to use
This is written in .net and will hopefully be updated semi frequently to the latest LTS .net version. If for some reason that has not happened follow [these instrustions that are hopefully still up](https://learn.microsoft.com/en-us/dotnet/core/install/upgrade)

If you are not a coder and find this I AM SO SORRY this is not a plug and play solution. The good news is you can probally follow a hello world tutorial and then run this as it is also a C# console application.

You should be able to see the full clock without starting the timer (if the puzzle has one).

So say you have a clock that starting at the noon/0 position (noon/0 is what I am calling where the hand starts for the puzzle which points to the exit) a clock that is 
```
        3
     6     5
  2           5
4               4
  6           5
     6     5
        2
```
(taken from the game)

you would plug in 
`3,6,2,4,6,6,2,5,5,4,5,5`

afterwords you should get an output with possible solutions like this.
```
Positions: 0 -> 9 -> 5 -> 11 -> 6 -> 8 -> 1 -> 7 -> 2 -> 4 -> 10 -> 3
Numbers: 3 -> 4 -> 6 -> 5 -> 2 -> 5 -> 6 -> 5 -> 2 -> 6 -> 5 -> 4

Positions: 2 -> 4 -> 10 -> 5 -> 11 -> 6 -> 8 -> 3 -> 7 -> 0 -> 9 -> 1
Numbers: 2 -> 6 -> 5 -> 6 -> 5 -> 2 -> 5 -> 4 -> 5 -> 3 -> 4 -> 6

Positions: 6 -> 8 -> 1 -> 7 -> 2 -> 0 -> 9 -> 5 -> 11 -> 4 -> 10 -> 3
Numbers: 2 -> 5 -> 6 -> 5 -> 2 -> 3 -> 4 -> 6 -> 5 -> 6 -> 5 -> 4

Positions: 8 -> 1 -> 7 -> 2 -> 0 -> 9 -> 5 -> 11 -> 6 -> 4 -> 10 -> 3
Numbers: 5 -> 6 -> 5 -> 2 -> 3 -> 4 -> 6 -> 5 -> 2 -> 6 -> 5 -> 4
```

This is telling you what position starting at noon/0 and counted clockwise (this is so if you have less than 12 spots you just count from the top).
The numbers are also included so you can have a reference on what number you are hitting.

##How the puzzle works.
---

Ok instead of reading 2 walls of text im gonna break it down easily.

- Your goal is to remove all of the numbers from the clock.
- Once you remove a number you cant use it.
- The clock hand at the number you select (so say its at the noon position in the example above) will move left and rigth from that number.
  - So above at the 3 it will move the left and right clock hand to the 4 at what would be 9 o'clock and the 4 at 3 o'clock.
  - If the hands end up on the same number you can only select that number.
    
You then just shampoo (rinse, lather and repeat) the process until you clear or both hands hit empty spots. If that happens you press X/Square/Whatever the key is on the keyboard and it resests the puzzle to a different random puzzle with a different solution. Sometimes there is no timer and the puzzle wont reset when you reset. 
---


This is gonna attempt to be as SEO friendly as possible so someone can find this and use it. Just for some ideas on how bad this is... right now I have about tenth of my playtime just dedicated to these puzzles.

