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

Additional:
*I have implemented additonally a simple collision detector when bullet hits the enemy the bullet destroys
*First i thought of destroy enemies but output was not excepted(the enemies was destroying since i was pressing rapidly and queue got emptied)


Day-4(Date:9/9/2025)

Task : Implementation of Player Movement using Unity Package System

Controls:
Top Down Controller:
Movement : WASD or Arrow keys
Sprint: LEft Shift
Dash: LEft Crtl

Side Scroller:

Movement: AD or Arrow keys 
Sprint: LEft Shift
Dash: LEft Crtl

What I Learned:
* Learned How to install unity Package System.
* How To create Input Actions for Player(Input Actions can be used for even different characters(eg:enemy))
* I learned about three new Scetions(ActionMap,Actions,ActionProperties)
* ActionMap: Where it is the section which notes down the Name of Actionmap(eg:Player)
* Actions:This is where theactions are added like Move,Sprint etc....
* ActionProperties: This is where we are giving the keycode for that specific action.
* How to a implement player movement for a side scroller  and Top down COntroller 2D game
* How to implement a sprint and dash mechanic to a player in both side scroller and Top down controller 2D game 

Implementation(Step by Step)
* Installed Unity Package System in Package Manager.
* Then in Project settings in player tab set the input handling to both the Input handling .
* In Project window Right Click new input action rename it to "PlayerController"
* Click on Player Controller a new window opens with Three sections(ActionsMap,Actions,ActionProperties)
* In ActionMap Named the Object we want in this case it is Player
* Added Move and Sprint Actions for the player
* In Action properties added the keys to that specific action for Keyboard and GamePad
* Additionally Added a new scene and created a new input system for Topdown Controller
* Added the essential physics component to the player and added the script created
* Added the sprint and dash functionality to the player where the players moves fast 


Features Added
* Added Move and Sprint Input Actions (For KeyBoard and GamePad) [ Side Scrolling Game]
* Added Move Input Actions (For Keyborad) [Top down Controller]
* Player moving left and right using keyborad inputs.
* Player moving a Top down controller environment with keyboard inputs
* Added sprint and Dash To the player in both side scroller and topDown 

Blockers:
* First when i opened the input actions window and started adding the actions for player movement and confused only two bindings were given it should have four up,down,left and right and i watch the reference video and noted that in properties i didnt change the actiontype to value and controltype to Vector2.
* In Top down Contoller when i have done the script But in game scene the player keeps falling and does not move when i press the keys and then i noticed that in rigidbody i didnt scale the gravity to zero and does'nt add the script which handles the player logic
* In Implementing Sprint functanlity to player first i tried to multiply with the current speed but the speed keeps on multiplying and gone infinity and shows error and then tried adding the a little speed but that keeps on adding the speed and then created a variable in inscpector and set it value double the normal speed and then done it as if button pressed normal speed is equal to boost speed and then it changes the speed.


