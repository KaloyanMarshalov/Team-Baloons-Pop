# Refactoring documentation of balloons pop project

## Member renaming
* Project
  * Solution ingr_baloni => BaloonsPopGame  
  * folder Baloons-Pop-1 => BaloonsPop
  * file and class baloonsState => BaloonsState
  * file ingra_baloni.csproj => BaloonsPop.csproj 
  * class GameState => Game

* file Game.cs
  * method displayScoreboard => DisplayScoreboard 
  * variable s => command
  * method executeCommand => ParseCommand
  * method sendCommand => SendCommand
  * method updateScoreboard => UpdateScoreboard
  * method restart => Restart

* file GameState.cs
  * variable cnt => turnCounter
  * variable __st => private state
  * scoreboard => highScores 
 
* file BaloonsState.cs
  * variable poleto => playField
  * variable rnd => randomGenerator
  * variable state => currentCell
  * method popBaloon => PopBaloon
  * method kraj => GameHasEnded
  * method printArray => PrintArray  

## Structure refactorings

* Moved all usings into the namespaces
* Added a ILogger interface in order to reduce coupling with console
* Added a ConsoleLogger class implementing the ILogger interface
* Logging is done with a ILogger instance in Program.cs
* Added a Score class to hold single game score information
* Added a HighScore class to hold highest scores
* Added a ILogger interface
* Added threadsafe ConsoleLogger class implementing the ILogger interface
* Introduced variables boardWidth and boardHeight in BaloonsState.cs

## Other refactorings

* Removed unnecessary comments in Program.cs
* Fixed bug in Game.cs that caused the game to end after each turn (missing round brackets around an if statement)
* DisplayScoreboard method in Game.cs uses StringBuilder and returns a string to improve testability

## Unit Tests

* Created a project BaloonsPopTests
* Added unit tests for class Score
* Added unit tests for class HighScore