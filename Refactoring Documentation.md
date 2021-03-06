Refactoring Documentation for Project "BattleField-5"     

1.	Solution name changed 
	Battle-Field-5/bItka.sln -> Battle-Field-5/Battle Field Game.sln
	
2.	Code refactoring
	-	Removed unnecessary comments
	-	Removed all unneeded empty lines
	-	Formatted the curly braces **{** and **}** according to the best practices for the C\# language
	-   Put **{** and **}** after all conditionals and loops (when missing)
	-   Character casing: variables and fields made **camelCase**; types and methods made **PascalCase**
	-   Formatted all other elements of the source code according to the best practices introduced in the course High-Quality Programming Code
	
3.	Refractoring without changing program logic
	-	Added classes Helper and Field
	-	Ranamed GameServides to Enigine
	-	Removed BattleField
	-	Methods renamed and moved appropriately
	-	Changes to access modifiers and making things static
	
4.	Refractoring code in methods
	-	Fix up code without effecting program logic.
	-	Clean up useless code
	
5.	Renaming solution
	...e-Field-5/Battle-Field-5 Team Project.sln -> ...e-Field-5/Team Battle-Field-5 Project.sln
	
6.	Refactoring using StyleCop
	-	Inserting empty lines where necessary.
	-	Renaming variables (hungarian notation)
		*	upRightCorner -> rightUpCorner...
7.	Added Score class and Highscore logic
	-	Implemented singleton and lazy loading patterns
	
8.	Added documentation in Highscore.cs and Score.cs

9.	Added highscore unit tests

10.	Refactoring using design patterns
	-	Factory (for cells and commands)
	-	Facade (RandomGenerator is facade over the System.Random)
	-	Template Method (used in the ExplodeCommand class)
	-	Command pattern (used in the ExplodeCommand class)
	-	Null Object pattern (used for the ExplodeCommand class)
		
11.	Implementing class ExplodeCommandFactory

12.	Implemented game finish
	-	Added active mines counter and FinishGame method in Renderer
	-	Changed mine activation to be called by field
	
13.	Implementing CellRepresentation
	-	Added cell types in enum CellType
	-	Removed ExplosionType.cs
	-	Method IsValid in ExplodeCommand.cs changed
		Before:
			return this.Cell.Type == CellType.MINE;
		After:
			return this.Cell.Type != CellType.BOMBED;
	-	Implementing class RandomGenerator in RandomGenerator.cs
	
14.	Implemented Highscore to the game

15.	Fixed check by mine Type

16.	Added Huge, Big and Tiny ExplodeCommands
	-	GetRelativePositions() in SquareExplodeCommand.cs made protected
	
17.	Proposal for new structure in the project:
	-	Adding separate projects for Console and WPF
	
18.	Console project folder moved to correct place

19.	Added basic Start and High score windows

20.	Added Highscore file to Console Project

21.	Refactoring following classes
	-	ConsoleInputProvider
	-	Engine
	-	CellType
	-	SquareExplodeCommand
	-	GameField
	-	RandomGenerator
	-	ConsoleRender
	-	IRenderer
	-	HighscoreTests
	
22.	Merge branch 'master' into Structure-changes

23.	Merge pull request #13 from Ivorankov/Structure-changes
	-	Structure changes
	
24.	Added data object + rough implementation of Memento Pattern

25.	EndScreenWindow addition

26.	Add Mines, ICellDamageHandler and Adapter pattern for RandomGenerator
	-	All Mines as subclasses of Cell
	-	Cells can be damaged
	-	Cells have ICelldamgeHandler
	-	Adapter and Singleton patterns used for RandomGenerator
	
26.	GameField Refactoring

27.	Merge branch 'master' into Highscore

28.	Refactored HighscoreLogger
	-	Renaming class Highscore to HighscoreLogger
	
29.	Merge pull request #15 from Ivorankov/Highscore

30.	Add event WhenDamaged to Cell, Change Position, add MineDestroyedException
	-	Cells now have event WhenDamaged, this allows GameField to track destroyed mines
	-	Add == and != operators to Postion and renamed x and y with row and col
	-	New MineDestroyedException, thrown when a destroyed mine is told to explode
	
31.	Fatal Bugs Fiexed, working state.
	-	GameField.cs
	
	Before:
		this.Field[position.Col, position.Row] = mine;
	
	After:
		this.Field[position.Row, position.Col] = mine;
		
32.	RandomGenerator constructor changed from private to protected

33.	Merge pull request #16 from Ivorankov/cell-and-explosion-refactoring
	-	Cell and explosion refactoring
	
34.	Buildable solution
	-	Todo: Add user input validation, improve KPK
	
35.	Merge pull request #18 from Ivorankov/UI-Engine
	-	Buildable solution
	
36.	Added skeleton for Proxy pattern
	-	Added IEngine.cs
	-	Added ProxyEngine.cs (implements IEngine)
	
37.	Better file structure + KPK improvements
	-	BattleField-WPF/EndScreenWindow.xaml.cs ->...Field-WPF/Windows/EndScreenWindow.xaml.cs
	-	BattleField-WPF/GameInitWindow.xaml.cs -> ...eField-WPF/Windows/GameInitWindow.xaml.cs
	-	BattleField-WPF/HighscoreWindow.xaml.cs -> ...Field-WPF/Windows/HighscoreWindow.xaml.cs
	-	BattleField-WPF/MainWindow.xaml.cs -> BattleField-WPF/Windows/MainWindow.xaml.cs
	-	BattleField-WPF/GameWindow.xaml.cs -> BattleField-WPF/Windows/GameWindow.xaml.cs
	
38.	BattleFIeld-Console
	-	Validating if player input for field size is int number.
	
39.	Fixed wrong unit test
	-	In HighscoreTests.cs test method CheckIfHighscorerSortsScoresByScore()
		-	"first" renamed to "third" ; "third" renamed to "first"
		
40.	Fixed the memento pattern and refactored GameObjData
	-	added some documentation
	
41.	Organized usings in
	-	RandomMineFactory.cs, GameObjData.cs, DataCollection.cs, GameObjMemento.cs, Originator.cs, Engine.cs, Engine.cs, ProxyEngine.cs, GameField.cs, ConsoleInputProvider.cs, WpfInputProvider.cs, Program.cs, Cell.cs, WpfRenderer.cs
	
42.	Fixed field size validation + added radio button for explosion chaining
	
43.	Implement ShowGameField()

44.	Add more console functionality
	-	SetWindowPosition()
	-	Implemented ShowGameOver(GameObjData data)
	-	Implemented  ShowHighscores(GameObjData data)
	
45.	Added unit tests for ConsoleInputProvider's method

46.	Refactoring + Improving UX of application
	-	Refactoring - removed unneeded usings
		- dependencies passed thru constructro rather then class field
		- some poorly made if statements
	-	UX
		- added background images to windows
		- remodeled end screen
		- made improvments on buttons and text field sizes and positions
		
47.	Add InputPosition event

48.	Quick fix for window + added last background image

49.	Removed ChainDamageHandler and field prop from Cell
	-	Small change in gameField reactToExplosion method to decrease
	minesCounter
	
50.	Implemented decorator pattern
	-	Added enum CellStatus
	-	Added CellDecorator.cs
	-	IMineFactory.cs changed 
		-	Before: Mine Create(Position position, GameField field);
		-	After: Mine Create(Cell cell);
	-	All implementations of IMineFactory also changed
	
51.	Removed cellStatus dependency from the main project

52.	Removed faked one
	-	CellType.cs
	
53.	Updating Refactoring Documentation.md

54.	Added GameFieldTests. Tested methods IsInRange and HasMinesLeft.

55.	Merge remote-tracking branch 'refs/remotes/origin/master' into cell-and-explosion-refactoring

56.	Merge pull request #26 from Ivorankov/cell-and-explosion-refactoring
	-	Cell and explosion refactoring
	
57.	Merge pull request #27 from Ivorankov/temp

58.	Updated Readme with design patterns

59.	Improved High Qality Code

60.	Merge remote-tracking branch 'refs/remotes/origin/master' into Addint-Flyweight-in-wpfrenderer-
	-	Conflicts: BattleField-WPF/WpfRenderer.cs
	
61.	Merge conflict resoved
	-	TODO: improve CellBrush
	
62.	Merge pull request #28 from Ivorankov/Addint-Flyweight-in-wpfrenderer-
	-	Added flyweight in wpfrenderer
	
63.	Fixed StyleCop warnings
	-	TODO: Documentation
	
64.	Added documentation

65.	Merge remote-tracking branch 'origin/master'
	-	Conflicts:
			-	Battle-Field-5/Cells/Cell.cs
			-	Battle-Field-5/Cells/CellDecorator.cs
			-	Battle-Field-5/Cells/Mines/MineDestroyedException.cs
			-	Battle-Field-5/Engines/Engine.cs
			-	Battle-Field-5/Engines/IEngine.cs
			-	Battle-Field-5/Engines/ProxyEngine.cs
			-	Battle-Field-5/GameField.cs
			-	Battle-Field-5/Position.cs
			-	Battle-Field-5/RNGs/RandomGenerator.cs
			
66.	Update README.md

67.	Refactoring in FlyWeight pattern

68.	Finished documentation

69.	Added tests for GetPlayerName method

70.	Merge remote-tracking branch 'origin/master'
	-	Conflicts: BattleField-WPF/WpfRenderer.cs
	
71.	Merge remote-tracking branch 'origin/master'
	-	Conflicts: BattleFIeld-Console/ConsoleRenderer.cs
	
72.	Updating Refactoring Documentation.md

73.	Added unit tests
	-	Coverage = 90%
	
74.	Added chaining
	-	Not the best place for it, but there is no time for improvements
		-	In constructor GameField added parameter: bool isExplosionChained = false

75.	Recursion solve, Add console colors
		
76.	Merge branch 'master' into ConsoleRenderer-improvements

77.	Added missing documentation/ removed proxy
	-	Removed	ProxyEngine.cs
	
78.	ConsoleRenderer mostly finished.

79.	Engine big fix
	
80.	Merge pull request #30 from Ivorankov/ConsoleRenderer-improvements
	-	Console renderer improvements
	
81.	Added proper user input validations + cool diagrams

82.	Added sandcastle doc

