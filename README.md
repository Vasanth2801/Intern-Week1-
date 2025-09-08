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

Implement Bullet Pooling System
* created a new circle object and named it "Bullet" and make it as a prefab and then drag and drop it in object pooler to spawn the bullets from reference.
* Then a created a Empty gameobject Gun and a child firepoint where the bullet will be spawned.
* Created two new scripts bullet and gun where gun is used get the refrence of the object pool manager to spawn the bullets
* Bullet script is for the behaviour of the bullet to move the bullet in the game view.
* Blocker: when the scripts are done and test the play button first the bullet was not moving only when i pressed 6 to 7 times the space bar it was moving then i have gone through the script throughly and noticed that i was reseting the velocity eveytime in script that was the issue adn i removed the line it worked mormally 
CONTROLS : SPACE TO FIRE

Implement Enemy Pooling System
* I have created a Enemy sprite(Square) and make it as a prefab and add it to the object pooling in inspector and then two scripts one is enemy and enemy spawner
* I have create a empty object and placed it at a distance and then added the enemy spawner script to it where it has refernce of the object pool manager to spawn enemies
* Also created enemy script for enemy behaviour 

Test efficieny for both enemy and Bullets
* First i have reduced the no.of objects to spawned and interval time for enemy but still the spawning is same as before i dont feel any difference that spawning very effective
* For bullet i have rapdily pressed space bar for long time but still the bullet spawning has no difference on the spawning speed very effective for firing a bullet and had fun testing with this one
* Even when i check this with game mode stats the Fps did'nt even cross more than 61 fps with was really impressive.
* Then i have gone to window and using profiler i checked the cpu memory usage that is around  30fps
* I have also created a new scene to use instantiate and checked the fps of the game the minimum fps i would get was around 76 fps with is the minimum the maximum numbers i got was around 90 fps
* With compary both the scenes object pooling gave the best reult and output 

