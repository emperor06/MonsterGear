# MonsterGear
A gear planner for Monster Hunter World

Back when I was playing MHW on PC, I couldn't find any real feat/gear planner, that is a program that gives you the perfect armor set for the skills you request. So far, all I have found was webpages that do the opposite (you provide the armor, the program tells you the skills you get, which is already what the game does). So I decided to tackle this for my own purpose with sharing in mind.

How does it work?
You provide how many gem slots your weapon has, what skills you desire, and MonsterGear will find the best armor/gems combinations that suit your needs. Technically, it just browses all possible combinations of gear in a smart way. That smart way is what makes this gear planner possible (a brute force would be way to slow).

1. Is it free?
Yes it is. Free as in free beer and freedom. Please use, own, share, improve, do whatever you want with it. It is yours.

2. Bugs?
None that I've found so far. The main issue is the user interface being ugly :)

3. Why is it ugly?
Because I've made this for myself using CLI and some hardcoded values. Then I decided it worked pretty well and made a quick and (very) dirty GUI so that other people can use it. I suck at making user interfaces. And I suck at C# :)

4. Why source code on github rather than just an exe on Nexus/Whatever?
First of all, I wouldn't accept to run a binary from a random modder when I don't have the source code. If I want other people to use this program, then I have to provide them with the possibility to review it, and at the very least to make any fix/adjustment they want.
Secondly, the user interface is crap, the code would enjoy a rewrite, and these are things I will probably not do (I've lost interest in the game) so I'll be glad if the community can do something about it.

5. Can I modify/fork MonsterGear?
Yes please! Do it! Do it now!
As said in (4), I've lost interest in the game and won't maintain this project. It's here for you to take and improve. This project is no more mine than yours, you don't need any permission from me. I will be glad to review well-made pull requests but if you plan on rewriting a lot of things, best you fork the project. I will be more than happy to reference it.

6. Armor from <bossname> is missing, what can I do?
Just edit pieces.json and hope for the best. If you can provide me with the missing parts (name, set name, armor rating, skills, etc.), I will be glad to add them myself to the json so everyone can benefit from it. IIRC, I've stopped playing after the giant golden worm was released and before the Final Fantasy bull was a thing.
