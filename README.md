# ei-assignments

## Exercise-1

### 1. Observer Pattern: Weather Station Monitoring System

### **Pattern Type**: Behavioral
In a game with adaptive AI difficulty, The GameSession is the subject, while EnemyAI and AchievementSystem are observers. As the player's performance changes, the AI difficulty adjusts, and achievements are unlocked, demonstrating how multiple systems can react to the same state changes.

---

### 2. Strategy Pattern: Data Compression Tool

### **Pattern Type**: Behavioral
A data compression tool allows users to select different compression algorithms (ZIP, RAR, GZIP) dynamically. Each algorithm follows the same interface, but the user can switch between them based on file type. This demonstrates how the **Strategy Pattern** allows the compression algorithm to change without modifying the tool’s core logic.

---

### 3. Singleton Pattern: Configuration Manager in a Web Application

### **Pattern Type**: Creational
A web application's configuration manager loads settings (like database connection strings) only once. The **Singleton Pattern** ensures that only one instance of the configuration manager exists, which provides consistency and avoids redundant initialization.

---

### 4. Factory Method Pattern: Document Generator

### **Pattern Type**: Creational
In a document generator system, different types of documents (Word, PDF, HTML) are created based on user input. The **Factory Method Pattern** enables the creation of these different document types without requiring the client code to be aware of how they are created.

---

### 5. Adapter Pattern: Database Access Layer Unification

### **Pattern Type**: Structural
A database access layer unifies multiple databases (like MySQL, SQL Server) by using adapters to convert the database-specific APIs into a standard interface. This allows the system to interact with different databases seamlessly through the **Adapter Pattern**.

---

### 6. Decorator Pattern: Text Editor with Formatting Options

### **Pattern Type**: Structural
In a text editor, multiple formatting options (bold, italic, underline) are applied dynamically to a text object using decorators. Each formatting option wraps around the original text object, adding new functionality without modifying the original text class, demonstrating the **Decorator Pattern**.

---
## Exercise-2
1. **Grid Initialization**: The simulation initializes a grid of specified size (e.g., `10x10`), sets the Rover’s starting position, direction (N, E, S, W), and places obstacles at given coordinates.
2. **Commands**: The Rover follows commands (`M`, `L`, `R`) to move forward, turn left, and turn right respectively.
3. **Obstacle Detection**: The Rover avoids obstacles and halts its movement if one is detected in its path.
4. **Rover Status**: The current position and direction of the Rover can be displayed anytime using the `status` command.


## Input/Output

### Initialization Command
Initializes the grid, the rover's position, direction, and obstacles:
```
init <grid-size> <start-position> <start-direction> <obstacles>
```
- **grid-size**: Format `WxH` (e.g., `10x10`)
- **start-position**: Rover's initial coordinates `(x, y)` (e.g., `0,0`)
- **start-direction**: Rover's initial direction `N`, `E`, `S`, or `W`
- **obstacles**: Comma-separated list of obstacle coordinates in the format `(x1,y1),(x2,y2)` (e.g., `(2,2),(3,5)`)

**Example**:
```
init 10x10 0,0 N (2,2),(3,5)
```
- Initializes a 10x10 grid, sets the Rover at position (0,0), facing North, with obstacles at (2,2) and (3,5).

### Command Execution
Processes a sequence of commands to move and rotate the Rover:
```
command <command-sequence>
```
- **M**: Move forward in the current direction.
- **L**: Turn left.
- **R**: Turn right.

**Example**:
```
command m m r m l m
```
- Moves forward twice, turns right, moves forward once, turns left, and moves forward.

### Status Command
Displays the current status of the Rover, including its position, direction, and obstacle detection.
```
status
```


## Obstacle Detection
Before moving, the Rover checks if the next position contains an obstacle or is out of bounds. If an obstacle is detected, the Rover halts its movement and logs a message:
```csharp
 public bool IsPositionValid(int x, int y)
    {
        if (x < 0 || x >= width || y < 0 || y >= height)
            return false;

        return !obstacles.Contains((x, y));
    }
```
```csharp
 if (grid.IsPositionValid(newX, newY))
        {
            x = newX;
            y = newY;
            _logger.LogInformation($"Rover moved to ({x}, {y}).");
        }
```

## Example Walkthrough

### Input:

```plaintext
init 10x10 0,0 N (2,2),(3,5)
command m m r m l m
status
```

### Output:

```plaintext
> init 10x10 0,0,N (2,2),(3,5) 
info: Grid[0]
      Grid initialized with width 10, height 10 and 2 obstacles.
info: Rover[0]
      Rover initialized at (0, 0) facing N.
info: Program[0]
      Simulation initialized successfully.
> command m m r m l m
info: Rover[0]
      Rover moved to (0, 1).
info: Rover[0]
      Rover moved to (0, 2).
info: Rover[0]
      Rover turned right, now facing E.
info: Rover[0]
      Rover moved to (1, 2).
info: Rover[0]
      Rover turned left, now facing N.
info: Rover[0]
      Rover moved to (1, 3).
info: Program[0]
      Commands executed.
> status
info: Program[0]
      Rover is at (1, 3) facing N.
```
