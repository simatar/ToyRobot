# Toy Robot - Coding Challenge

A simulation of a Toy Robot moving in a square tabletop

## The instructions
* You are required to simulate a toy robot moving on a square tabletop, of dimensions 5 units x 5 units.
* There are no other obstructions on the table surface. The robot is free to roam around the surface of the table, but must be prevented from falling to destruction.
* Any movement that would result in the robot falling from the table must be prevented, however further valid movement commands must still be allowed.
* All commands should be discarded until a valid place command has been executed.
* The solution must be written in C#.
* The UI can be provided via CLI, however you are free to expand on this.

## Commands

All commands should provide output indicating whether or not they succeeded.

PLACE: X, Y, Direction
> **X** and **Y** are integers that indicate a location on the tabletop.  
> **Direction** is a string indicating which direction the robot should face. It it one of the four cardinal directions: NORTH, EAST, SOUTH or WEST.

MOVE
> Instructs the robot to move 1 square in the direction it is facing.

LEFT
> Instructs the robot to rotate 90° anticlockwise/counterclockwise.

RIGHT
> Instructs the robot to rotate 90° clockwise.

REPORT
> Outputs the robot's current location on the tabletop and the direction it is facing.

## Assumptions

Here are my assumptions:

* the ability to change the dimension
* the initial place the robot is placed is in row 1 column 1 (1,1), the first box

## Running the project

Clone this repository

1. Open Visual Studio
2. From the Git menu, select **Clone Repository**  
Note  
If you haven't interacted with the Git menu before, you might see Clone instead of Clone Repository. If so, select Clone.  
And, if Git isn't on the menu bar, go to Tools > Options > Source Control > Plug-in Selection, and then select Git from the Current source control plug-in dropdown ist.
3. In the Clone a repository window, under the Enter a Git repository URL section, add your repo info in the Repository location box.
Next, in the Path section, you can choose to accept the default path to your local source files, or you can browse to a different location.  
Then, in the Browse a repository section, select GitHub.
4. In the Open from GitHub window, you can either verify your GitHub account information or you can add it. To do so, select Sign in from the drop-down menu.
If you're signing in to GitHub from Visual Studio for the first time, an Authorize Visual Studio notice appears. Choose the options you want, and then select Authorize github.  
After you link your GitHub account with Visual Studio, a Success notification appears.  
5. After you sign in, Visual Studio returns to the Clone a repository dialog, where the Open from GitHub window lists all the repositories that you have access to. Select the one you want, and then select Clone.
Enter the location of your repo, and then select Clone.
6. Next, Visual Studio presents a list of solution(s) in the repository. Choose the solution you would like to load or open the Folder View in Solution Explorer.

Run the project

1. Press Ctrl-F5 to run the project

## UI

Here is a sample of how the console would look like.

![Toy Robot](https://lh4.googleusercontent.com/VAzBaIrh-aV6vobKUiiLW5ORaHGpqyHutaC4WbGASKNrN7DLrs5a0cJ07fS3j_KiXUo=w2400 "Toy Robot")
