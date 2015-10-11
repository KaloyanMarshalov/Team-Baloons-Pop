# TODO LIST: Teamwork High Quality Code

## 1. Completed Requirements:
	### Perform refactoring of the entire project 
	 * Refactoring structure - done;
	 * Refactoring project files - done;
	 * Refactoring source code - done;
	 * Refactoring classes - done;
	 * Refactoring interfaces - done;
	 * Refactoring methods - done;
	 * Refactoring properties - done;
	 * Refactoring fields - done; 
	 
	### Self-documentating code - done;
	
	### Good names:
		* Classes - done;
		* Methods - done;
		* Variables - done;
		
	### Strong cohesion - Almost;
	
	### Loose coupling - Almost;
	
	### All default StyleCop rules should pass without any warning - Almost!
	
## 2. Implement design patterns:
	### Creational patterns:
		* Singleton Pattern - implemented in ConsoleRenderer.cs where by using locking and a check, only one instance of the class is created.
		* Simple Factory Pattern - BaoonFactory is the directory where the creational pattern Simle Factory is implemented. It makes different colors of balloons!
		
	### Structural patterns:
		* Decorator Patternattern - Implemented in BoardComponentDecorator and BonusDecorator for setting new components.

	### Behavior patterns:
		* Strategy Pattern - Implemented in PopStrategy, RecursivePopStratgy for finding popped baloons. And
		in GravityStrategy, NormalPopStrategy for placing baloons in the empty space below them.
		
## 3. SOLID and DRY principles:
	* Single responsibility - done;
	* Open/close - done;
	* Liskov substitution - done;
	* Interface segregation - done; 
	* Dependency inversion - done;
	* Don't repeat yourself - done;

## 4. Implement unit tests:

	* The code coverage of the unit tests should be at least 90% - nope
	
	* At least 10 of your tests should use mocking (Moq, JustMock or other) - nope
	
## 5. Documentation and comments - done;

## 6. Add new functionalities
