using BlazingTicTacToe.AI;
using Microsoft.JSInterop;
using static BlazingTicTacToe.AI.MinMaxAlgorithm;
using System.Linq;
using System.Threading;

namespace BlazingTicTacToe.Pages
{
    public partial class Index
    {
        char[,] board = { { ' ', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } };
        char player = 'o';
        int[][] winningCombos =
        {
            new int[3] {0,1,2},//00 01 02
            new int[3] {3,4,5},//10 11 12
            new int[3] {6,7,8},//20 21 22

            new int[3] {0,3,6},//00 10 20
            new int[3] {1,4,7},//01 11 21
            new int[3] {2,5,8},//02 12 22

            new int[3] {0,4,8},//00 11 22
            new int[3] {2,4,6}//02 11 20
        };

        List<List<int[]>> combos = new()
        {
            new List<int[]>() {new int[] { 0,0 }, new int[] { 0, 1 }, new int[] { 0, 2} },
            new List<int[]>() {new int[] { 1,0 }, new int[] { 1, 1 }, new int[] { 1, 2} },
            new List<int[]>() {new int[] { 2,0 }, new int[] { 2, 1 }, new int[] { 2, 2} },

            new List<int[]>() {new int[] { 0,0 }, new int[] { 1, 0 }, new int[] { 2, 0} },
            new List<int[]>() {new int[] { 0,1 }, new int[] { 1, 1 }, new int[] { 2, 1} },
            new List<int[]>() {new int[] { 0,2 }, new int[] { 1, 2 }, new int[] { 2, 2} },

            new List<int[]>() {new int[] { 0,0 }, new int[] { 1, 1 }, new int[] { 2, 2} },
            new List<int[]>() {new int[] { 0,2 }, new int[] { 1, 1 }, new int[] { 2, 0} },
        };

        public Index()
        {
            Move move = MinMaxAlgorithm.findBestMove(board);
            board[move.row, move.col] = 'x';
        }

        private async Task SquareCliked(int row, int col)
        {
            board[row, col] = player;
            //player = player == 'X' ? 'O' : 'X';

            Move move = MinMaxAlgorithm.findBestMove(board);
            if(! (move.row == -1 && move.col == -1))
            board[move.row, move.col] = 'x';
            

            foreach (var combo in combos)
            {
                int[] first = combo[0];
                int[] second = combo[1];
                int[] third = combo[2];
                if (board[first[0], first[1]] == ' ' || board[second[0], second[1]] == ' ' || board[third[0], third[1]] == ' ') continue;
                if (board[first[0], first[1]] == board[second[0], second[1]] && board[second[0], second[1]] == board[third[0], third[1]] && board[first[0], first[1]] == board[third[0], third[1]])
                {  
                    string winner = player == 'o' ? "AI" : "Player ONE";
                    await JS.InvokeVoidAsync("ShowSwal", winner);
                    await Task.Delay(1000);
                    ResetGame();
                }
            }

            if (IsGameReset())
            {
                await JS.InvokeVoidAsync("ShowTie");
                ResetGame();
            }
        }


            private bool IsGameReset()
        {
            bool isReset = true;
            
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if(board[i, j] == ' ')
                    {
                        isReset = false;
                    }
                }
            }
            return isReset;
        }

        private void ResetGame()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = ' ';
                }
            }
        }
    }

}