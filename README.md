# Intern-Week1-
Updating the dailytasks Handled in Internship
1.Have installed the the new version of unity and setup the github with unity and undersstand how to keep the project folders orangized (Date:4/9/2025)
2.Have Implemeted a weaponSytstem using Scriptable objects for 3 different weapons and switching inbetween the game using number Keys(1,2,3) and also implemented a UI to show what weapon we are using right now ,how much ammo does each weapon has and also how much damage does each weapon does is shown is game scene top left corner. (Date:5/9/2025)

Day -3 - Date(8/9/2025)

Why Object Pooling is Important?
* Object pooling is a great way to optimize the project and processing memory of cpu.
* In some types of game we have to create and destroy many gameobjects for that scenario we use object pooling
* In object pooling,we can set the number of gameobjects inactive and active in the game only when we needed and reuse the same objects again and again
* In normal cases,we use instantiate and destroy gameobjects but it uses more memory power and reduces the perfomance of the game.
* objectpooling just pre-instantiates all the set no.of objects we needed before gameplay and make it active as we needed
* by using this one we can increase the performance of our game and reduce cpu memory.
* Eg: For an top down Shooting game can be mainly used for bullets.

Create a pool Manager Script
* Learned about what is dictionary and queue and how they are used effiecintly for object pooling
* created the pool manager script with inactive squares at first when the game begins.
* added the logic for spawning the squares in the scene(now we need get a refernce from other script)
* Blocker:After intailize the dictionary and list in the script but when i save a go back into unity it was not visible but after watching the given reference video i missed the keyword(system.Serialzible) and after that i worked as i excepted 

