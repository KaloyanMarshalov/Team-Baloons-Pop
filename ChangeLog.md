# Refactoring documentataion of baloons pop project

## Member renaming
* Project
  * Solution ingr_baloni => BaloonsPopGame  
  * folder Baloons-Pop-1 => BaloonsPop
  * file and class baloonsState => BaloonsState
  * file ingra_baloni.csproj => BaloonsPop.csproj 
  * class GameState => Game

* file Game.cs
  * method displayScoreboard => DisplayScoreboard 

* file GameState.cs
  * cnt => turnCounter
  * __st => private state
  * scoreboard => highScores 
 
* file BaloonsState.cs
  * poleto => playField
  * rnd => randomGenerator
  * method popBaloon => PopBaloon
  * method kraj => GameHasEnded
  * method printArray => PrintArray  

## Structure refacgtorings

* Moved all usings into the namespaces
* Added a ILogger interface in order to reduce coupling with console
* Added a ConsoleLogger class implementing the ILogger interface
* Logging is done with a ILogger instance in Program.cs
* Added a Score class to hold single game score information

## Other refactorings

* Removed uneccesary comments in Program.cs
* DisplayScoreboard method in Game.cs uses StringBuilder and returns a string to improve testability

## Unit Tests

* Created a project BaloonsPopTests