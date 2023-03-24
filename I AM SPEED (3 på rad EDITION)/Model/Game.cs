namespace I_AM_SPEED__3_på_rad_EDITION_.Model
{
    internal class Game
    {
        private string[] board = new string[9];
        private string curentPlayer = "O";
        private bool gameOver = false;

        public Game()
        {
            for (int i = 0; i < board.Length; i++) { board[i] = " "; }
        }

        public void StartGame()
        {
            drawBoard();
            gameLoop();
        }

        private void gameLoop()
        {
            swapPlayer();
            userSelectSquare();
            drawBoard();
            Console.WriteLine("Draw er " + draw());
            if (!doWeHaveAWINNER() || !draw())
            {
                gameLoop();
            }
            else
            {
                if (draw()) Console.WriteLine("Det blie uavgjort XD");
                else Console.WriteLine("Gratulerrer " + curentPlayer);
            }
        }

        private bool draw()
        {
            bool draw = true;
            for (int i = 0; i < board.Length; i++)
            {
                if (board[i] == " ") { draw = false; break; }
            }
            return draw;
        }

        private bool doWeHaveAWINNER()
        {
            for (int i = 0; i < 3; i++)
            {
                // Loddrett
                if (board[i] != " " && board[i] == board[i + 3] && board[i + 3] == board[i + 6]) { return true; }

                // Vann rett
                int offset = i * 3;
                if (board[offset] != " " && board[offset] == board[offset + 1] && board[offset + 1] == board[offset + 2]) { return true; }
            }

            // Diagonalen
            if (board[0] != " " && board[0] == board[4] && board[4] == board[8]) { return true; }
            if (board[2] != " " && board[2] == board[4] && board[4] == board[6]) { return true; }

            return false;
        }

        private void swapPlayer()
        {

            if (curentPlayer == "X") { curentPlayer = "O"; }
            else { curentPlayer = "X"; }
        }

        private void drawBoard()
        {
            Console.WriteLine($"{board[0]}{board[1]}{board[2]}");
            Console.WriteLine($"{board[3]}{board[4]}{board[5]}");
            Console.WriteLine($"{board[6]}{board[7]}{board[8]}");
        }

        private void userSelectSquare()
        {
            string userInput = Console.ReadLine();
            if (oneToNine(userInput) && userInput.Length == 1 && board[Int16.Parse(userInput) - 1] == " ")
            {
                board[Int16.Parse(userInput) - 1] = curentPlayer;
            }
            else
            {
                userSelectSquare();
            }

        }

        private bool oneToNine(string str)
        {
            foreach (char c in str)
            {
                if (c < '1' || c > '9')
                    return false;
            }

            return true;
        }
    }
}
