# BilliardProject

**User Interaction Technology Course Project**

**Cyber Billiard**

## Preview

![](https://pic.imgdb.cn/item/64770b90f024cca173ce61b5.jpg)

![](https://pic.imgdb.cn/item/64770c2ff024cca173cf082b.jpg)

![](https://pic.imgdb.cn/item/64770c4df024cca173cf2bac.jpg)

User is first person

![](https://pic.imgdb.cn/item/648aa2e91ddac507ccfeb7de.jpg)


**Right click to open 3x mirror**

Click the left button to enter the batting mode for 3 seconds.Moving the mouse back and forth at this point will move the cue stick.

![img](https://pic.imgdb.cn/item/6489d16f1ddac507cc542921.jpg)

**When the user hits the H key, the help menu will be invoked.**

**When the user hits the R key, the ball's position will be reset.**

**When the user clicks the Q key, the game will exit.**

![](https://pic.imgdb.cn/item/648aa5841ddac507cc05d686.jpg)

Special effects will be generated when the user hits the ball

![img](https://s2.loli.net/2023/06/09/XJSthYPkrTv1BwW.jpg)

**When the user scores a goal, the striped ball or full-color ball that needs to be hit will be highlighted**

![](https://pic.imgdb.cn/item/648aa54b1ddac507cc053d25.jpg)

**When the user enters the black eight, it will judge failure or success, and will give a prompt**

![](https://pic.imgdb.cn/item/648aa4831ddac507cc02db30.jpg)

And there will be a TV playing background music and displaying the current score

![](https://pic.imgdb.cn/item/648aa50a1ddac507cc048487.jpg)

## Structure && Modules

#### structures

There are mainly two scenes, UI scene (demo) and billiard scene (playground)

The UI scene is the start interface.

The billiard scene is the main playing scene.

the structure of the game is:

In Assets Folder:

- Resources
  - This directory is to place some necessary resources (with the package body and need to be loaded dynamically).Such as pictures, entities, materials, etc.
- Scripts
  - Scripts required for various games to run
- Others
  - Resource packs on the network, including various resources such as UI

#### modules

The program consists of the following mainly modules:

* A global script that defines three static variables: hole_balls, goalsNum and playerType, which represent the total number of balls that have been hit into the holes, the score of the user and the type of the user (solid or striped). The script also defines three delegates and three events to notify other scripts when these variables change.
* A text mesh script that subscribes to the global events and updates the text on the screen to show the current status of the game, such as the score, the type and the remaining balls.
* A cue script that handles the input from the mouse and keyboard, and controls the movement and rotation of the cue. The script also implements two functions: zooming in the view when holding down the right mouse button, and entering the hitting mode when clicking the left mouse button. In the hitting mode, the user can adjust the force and angle of hitting by moving the mouse up and down.
* A ball script that applies physics to each ball on the table, and detects when a ball goes into a hole. The script also updates the global variables and plays sound effects and special effects accordingly.
* A TV script that displays the current score and the number of remaining balls on a TV screen in the room.
* A help script that shows a help interface when pressing the H key, which contains the rules and instructions of the game.
* A reset script that resets all positions of billiards to their initial values and restarts the game when pressing the R key.
* A rule script that defines the static rules of the game, such as the order of hitting balls, the penalty for fouls, the conditions for winning or losing, etc. The script also checks the game state and triggers the corresponding events and effects.
* A bounce script that enhances the physical effects of the game by applying a force to the balls when they hit the edges of the table, making them bounce more realistically.

## Implemented Requirements

This game is a billiards game based on Unity, targeting users who like billiards sports, especially those who want to experience real billiards operations on their computers. Users can control the character in the first-person perspective, holding a cue in their hands, and use the mouse and keyboard to hit the ball and move. This game implements the following functions:

* When the user holds down the right mouse button, the view is zoomed in by 3 times, and you can see the position and direction of the ball more clearly.
* When the user clicks the left mouse button, enter the hitting mode for 3 seconds. In these 3 seconds, the user can control the movement of the rod according to the up and down movement of the mouse, thereby adjusting the force.
* When the ball goes into the hole, the corresponding ball of the same color will light up with special effects, indicating that the ball of that color has been hit in. At the same time, the TV will show the current score.
* There will be sound effects and special effects when hitting the ball, increasing realism and fun.
* There will be fireworks effects and UI prompts when winning or losing, giving users feedback and rewards.
* Users can press the H key to call up the help interface and check the rules and operation instructions of the game.
* Users can press the R key to restore all positions of billiards to their initial values and restart the game.

The highlights of this game are:

* Adopted a first-person perspective, giving users a immersive feeling.
* Provided functions such as zooming in and hitting mode, allowing users to control the details of hitting more accurately.
* Added elements such as sound effects, special effects and TV, enhancing the atmosphere and fun of the game.
* Provided help interface and reset function, convenient for users to learn and restart the game.

## Advantages and Disadvantages

The advantages of this program are:

* The interface is simple and clear, and easy to understand.
* The logic is clear and reasonable, in line with the rules and physical principles of billiards sports.
* The effects are rich and colorful, improving user experience and satisfaction.

The disadvantages of this program are:

* The function is relatively single, with only one mode and one difficulty level.
* The interaction is relatively simple, without considering user needs such as  pausing games, saving progress, etc.
* The compatibility is poor, without adapting to different resolutions, different operating systems, different input devices, etc.

## How to Improve

In order to make this program more perfect and optimized, you can consider the following improvement directions:

* Add more modes and difficulty options, such as double-player battle, timing mode, random layout, etc., to give users more choices and challenges.
* Add more interactive functions, such as, adding pause, save, load buttons, supporting voice control or gesture input methods etc., giving users more freedom and convenience.
* Add more compatibility tests and adaptation work, such as adjusting interface layout according to different resolutions, optimizing performance according to different operating systems, adjusting operation methods according to different input devices etc., allowing users to play games smoothly on different platforms and devices.
