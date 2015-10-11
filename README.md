# Refactoring documentation of Baloons Pop project

## Member renaming
1. Project
  * Solution ingr_baloni => BaloonsPopGame  
  * folder Baloons-Pop-1 => BaloonsPop
  * file and class baloonsState => BaloonsState
  * file ingra_baloni.csproj => BaloonsPop.csproj 
  * class GameState => Game

2. file Game.cs
  * method displayScoreboard => DisplayScoreboard 
  * variable s => command
  * method executeCommand => ParseCommand
  * method sendCommand => SendCommand
  * method updateScoreboard => UpdateScoreboard
  * method restart => Restart
  * method SendCommand input params "fst" and "scd" => int row; int column
	* Create variable the magic number "5" named  "maxRows"
	* bool end => bool endOfTheGame
  * in method UpdateScoreboard	
	* variable string s => string playerName
	* a => scoresOfPlayer
	* magic number 5 => variable int maxPlayersInHighScores

3. file GameState.cs
  * variable cnt => turnCounter
  * variable __st => private state
  * scoreboard => highScores 
 
4. file BaloonsState.cs
  * variable poleto => playField
  * variable rnd => randomGenerator
  * variable state => currentCell
  * method popBaloon => PopBaloon
  * method kraj => GameHasEnded
  * method printArray => PrintArray  
  * method pr => GetBaloonChar
  
5. file Program.cs => MainMenu.cs
 * Added Logo using strings
 * Added method StartMenu
 
6. file ListOfCommands.cs
  *method PrintListOFCommands
  
7. Files HighScore.cs, Score.cs and ScoreComparer.cs extracted from Game.cs

8. File Entry.cs extracted from Game.cs

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
* Introduced variables minBaloon and maxBallon in BaloonState.cs
* Created a method SwitchConsoleColor
* Exported constants in HighScore.cs
* Implemented Strategy Pattern in PopStrategy, RecursivePopStratgy for finding popped baloons. And
  in GravityStrategy, NormalPopStrategy for placing baloons in the empty space below them.
* Singleton Pattern is implemented in ConsoleRenderer.cs where by using locking and a check, only one instance of the class is created.
* Simple Factory Pattern - is implemented in Balloon.cs, BalloonMaker.cs. It makes different colors of balloons!
* Decorator Patternattern - Implemented in BoardComponentDecorator and BonusDecorator for setting new components.

## Other refactorings

* Removed unnecessary comments in Program.cs
* Fixed bug in Game.cs that caused the game to end after each turn (missing round brackets around an if statement)
* DisplayScoreboard method in Game.cs uses StringBuilder and returns a string to improve testability
* Introduced constants:
  Score\MinimumPlayerNameLength
  Score\MaximumPlayerNameLength
  Score\NameErrorStringFormat
  HighScore\MaxScoreCount
  HighScore\NullableScoreExMessage
  HighScore\EmptyScoreBoard

## Unit Tests

* Created a project BaloonsPopTests
* Added unit tests for class Score
* Added unit tests for class HighScore