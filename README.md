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
* How to Tune player movements smoothly so everybody can enjoy the game

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
* Tuned in some values for dash and sprint since it was not recongiable in eyes after the tunning it was smooth and also visible 


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

Summary:
* Additionally i learned more about the new input system where it used across various platforms like gamepad,joystick,touch,keyboardetc... 
* In old system it was only easy to implement it in keyboards but in new system it is across various systems

Day - 5(Date:10/9/2025)

Task:
Implement a countdowntimer using events and delegates

What I learned:
* I have leanred about C# events and delegates
* Events are used for communicating between two objects
* Delegates acts as  connector for two objects
* delegates are very important for creating events
* How to add a countdown timer in the Game and how to implement it in UI and update it in every frame until it reaches zero
* How to use Coroutines and implement it correctly in a Game
* How to use Delegates and events in a Game and how to call them,declare them etc..
* How to add UI in game by setting it true and false

Important POINTS In Today Intern Notes:
* In delegates the return type and paramters should be same for publisher and subscriber
* Without delegates the events cant be handled
* If one event is created we can call it in multiple scripts


Implementation(Step by Step)
* First leanred the concepts of events and delgates an how to implement it and where to use in our projects
* Created a Script as CountDown Timer and make it reduces it until it goes zero
* Also added a simple UI to see the Timer in game scene so it everybody can view it
* Created a new Coroutine method for the delay and for better performance
* Increased the timer for around 2 seconds for better balancing
* Created a new script event handler which acts as a subscriber and used countdown as publisher
* created a new delegate and event as HandlegameEnd and in event handler script called it
* when timer goes zero the timercountdown triggered the event and check if there is any subscribers
* when the subscriber is called game over shows in console
* In Game over panel added the text and in code
* In code the game over panel is set to true and false when event it called
  
Features implemented:
* Added a Countdown Timer as it reduces slowly
* Used a coroutine method to less the timer for a better performance
* using delegate and events to trigger gameover effect
* Using events function how to trigger the UI screens 

Blocker:
* In This CountdownTimer implementation,when i first added it normally but it showed me in decimal value and i go to unity documentation to learn about Mathf.Ceil which is used to get the whole number around it and then it worked normally


Summary:
* Today i learned about delegates and events which i have not worked no before and understood how it works  and how use them and thier main purpose
* Also i learned more about UI specifally how slider area works and how to implement them in game scene


Day 6(Date:11/9/2025)

Task:
GameManager and AudioManager using Singleton Pattern

What I Learned:
* Learned about Singleton patterns and how to use it also learned about private getter and setter so that no issues come in Singleton Part like memory leakage 
* Why to use it in Projects so we dont want create many scripts one script global accessible to all others
* Drawbacks: In Complex or large projects is very difficult to handle and may confuse people
* How to implemeent a UI menu and call it using GameManager Singleton Pattern and how the button on click event is working
* Learned newly about audio system how it works in game and how to implement it
* Learned how to add specific sound effects to when ceratin event happens like pressing dash for that event alone
* How to make the game pause and resume when certain event is trigerred and how to pause and play the game music and sound


Implementation(Step by Step)
* For creating a Simple singleton example i have created a new c# script and then created a new public static reference to the instamce data.
* In Awake Method we say like if instance is not equal to null then get the instance of this class and dont destroy on load to have it across game scenes
* I created two empty gameobjects and UImanager and Gamemanager and then created a simple UI to show how the gamemanager singleton works
* In gamemanager created the singleton in which calls the resume and restart method in another script
* so when the button is pressed the methods allows the logic to happen
* Created a Audiomanger script and added a audio source component to the gameobject
* imported the musics and added in the script and then played the scene
* In UI panel added some colours effects for the button when highlighted or pressed
* In Gamepause logic whenthe "escape" button is pressed the game pauses and by clicking the buttons you can get back again to game by resuming or restarting 


Features Implemented:
* Created a simple UI menu with resume and restart buttons to see how the singleton works on gamemanager
* Created a audiomanager to play the desired music when the game starts
* Added soundeffect for the dash event happened (using yesterday player movement ) script
* Added the UI a little polish for button pressing 

Blocker: 
When playing the sound effects first play at oneshot was used i was using normal pLay button which was not that good so i go to unity documentation and learned about keywords for the certain effects and changed and then it worked.










