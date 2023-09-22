using BlazingSnake.Data;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;

namespace BlazingSnake.Pages
{
    public partial class Snake
    {
        #region [SNAKE DEFAULT VALUES]

        SnakeCell currentCell;

        Score score = new();

        // Define the Snake's initial direction
        Direction snakeDirection = Direction.RIGHT;

        readonly List<SnakeCell> snakeBody = new();
        #endregion

        #region [GAME DEFAULT SETTINGS]
        // Snake speed in milliseconds
        readonly int gameInterval = 800;

        // Define the food's initial position
        int foodRow = 5;
        int foodCol = 5;

        bool isGameOver;

        #endregion

        #region [METHODS]
        protected override async Task OnInitializedAsync()
        {
            InitializeGame();
            await StartGame();
        }

        private void InitializeGame()
        {
            // Define the Snake's initial position
            currentCell = new() { Row = 10, Col = 10 };

            // Initialize the snake's size to 1
            score.CurrentScore = 1;

            // Initialize the snake's body with one cell at the starting position
            snakeBody.Add(CloneSnakeCell());

            // Generate the initial food
            GenerateFood();
        }

        private async Task StartGame()
        {
            // Start the game loop
            while (!isGameOver)
            {
                UpdateSnakeDirection();
                if (IsFoodFound())
                {
                    score.CurrentScore++;
                    GenerateFood();
                }
                await Task.Delay(gameInterval);
                StateHasChanged();
            }
        }

        // Generate new food when the Snake eats it & when game starts.
        private void GenerateFood()
        {
            var random = new Random();
            foodRow = random.Next(0, 20);
            foodCol = random.Next(0, 20);
        }

        private void ControlSnakeDirection(KeyboardEventArgs e)
        {
            switch (e.Key)
            {
                case "ArrowUp":

                        snakeDirection = Direction.UP;
                    break;
                case "ArrowRight":

                        snakeDirection = Direction.RIGHT;
                    break;
                case "ArrowDown":

                        snakeDirection = Direction.DOWN;
                    break;
                case "ArrowLeft":

                        snakeDirection = Direction.LEFT;
                    break;
            }
        }

        // Update Snake position based on direction
        private void UpdateSnakeDirection()
        {
            switch (snakeDirection)
            {
                case Direction.UP: 
                    currentCell.Row--;
                    break;
                case Direction.RIGHT: 
                    currentCell.Col++;
                    break;
                case Direction.DOWN: 
                    currentCell.Row++;
                    break;
                case Direction.LEFT:
                    currentCell.Col--;
                    break;
            }

            // Add the new current Cell to the  of the snake's body
            snakeBody.Insert(0, CloneSnakeCell());

            //Check if Game is over
            IsGameOver();

            // Remove the last cell (tail) to maintain the snake's size
            if (snakeBody.Count > score.CurrentScore)
            {
                snakeBody.RemoveAt(snakeBody.Count - 1);
            }
        }

        private SnakeCell CloneSnakeCell()
        {
            return new SnakeCell() { Row = currentCell.Row, Col= currentCell.Col };
        }

        // Check for collision between the Snake and food
        private bool IsFoodFound()
        {
            return currentCell.Row == foodRow && currentCell.Col == foodCol;
        }

        private async Task IsGameOver()
        {
            if (currentCell.Row < 0 || currentCell.Row >= 20 || currentCell.Col < 0 || currentCell.Col >= 20)
            {
                isGameOver = true;
                bool isResetGame = await js.InvokeAsync<bool>("ResetGamePopup", score.CurrentScore);
                if (isResetGame)
                {
                    if (score.CurrentScore > score.TopScore)
                    {
                        score.TopScore = score.CurrentScore;
                    }
                    ResetGame();
                }
                else
                {
                    await js.InvokeVoidAsync("navigateToWebsite", $"https://rikampalkar.github.io/");
                }
            }
            isGameOver = false;
        }

        private void ResetGame()
        {
            snakeBody.Clear();
            isGameOver = false;
            OnInitializedAsync();
        }
        #endregion

        #region [CSS METHODS]
        //This method checks whether the cell at the given row and col coordinates belongs to the snake's body.
        private bool IsSnakeCell(int row, int col)
        {
            return snakeBody.Exists(cell => cell.Row == row && cell.Col == col);
        }

        //This method checks whether the cell at the given row and col coordinates matches the position of the food
        private bool IsFoodCell(int row, int col)
        {
            return row == foodRow && col == foodCol;
        }

        // Function to check if a cell is the snake head
        private bool IsSnakeHead(int row, int col)
        {
            return row == snakeBody[0].Row && col == snakeBody[0].Col;
        }
        #endregion
    }
}