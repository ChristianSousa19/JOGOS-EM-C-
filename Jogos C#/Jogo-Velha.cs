using System;

class Program
{
    static char[] board = { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
    static char currentPlayer = 'X';

    static void Main(string[] args)
    {
        bool gameOver = false;

        while (!gameOver)
        {
            DrawBoard();
            Console.WriteLine($"É a vez do jogador {currentPlayer}. Insira a posição (1-9):");
            int position = int.Parse(Console.ReadLine()) - 1;

            if (IsValidMove(position))
            {
                board[position] = currentPlayer;

                if (CheckWin())
                {
                    DrawBoard();
                    Console.WriteLine($"O jogador {currentPlayer} venceu!");
                    gameOver = true;
                }
                else if (CheckTie())
                {
                    DrawBoard();
                    Console.WriteLine("Empate!");
                    gameOver = true;
                }
                else
                {
                    currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
                }
            }
            else
            {
                Console.WriteLine("Posição inválida. Tente novamente.");
            }
        }

        Console.ReadLine();
    }

    static void DrawBoard()
    {
        Console.Clear();
        Console.WriteLine($" {board[0]} | {board[1]} | {board[2]} ");
        Console.WriteLine("---+---+---");
        Console.WriteLine($" {board[3]} | {board[4]} | {board[5]} ");
        Console.WriteLine("---+---+---");
        Console.WriteLine($" {board[6]} | {board[7]} | {board[8]} ");
    }

    static bool IsValidMove(int position)
    {
        return board[position] == ' ';
    }

    static bool CheckWin()
    {
        return (board[0] == currentPlayer && board[1] == currentPlayer && board[2] == currentPlayer) ||
               (board[3] == currentPlayer && board[4] == currentPlayer && board[5] == currentPlayer) ||
               (board[6] == currentPlayer && board[7] == currentPlayer && board[8] == currentPlayer) ||
               (board[0] == currentPlayer && board[3] == currentPlayer && board[6] == currentPlayer) ||
               (board[1] == currentPlayer && board[4] == currentPlayer && board[7] == currentPlayer) ||
               (board[2] == currentPlayer && board[5] == currentPlayer && board[8] == currentPlayer) ||
               (board[0] == currentPlayer && board[4] == currentPlayer && board[8] == currentPlayer) ||
               (board[2] == currentPlayer && board[4] == currentPlayer && board[6] == currentPlayer);
    }

    static bool CheckTie()
    {
        foreach (char position in board)
        {
            if (position == ' ')
            {
                return false;
            }
        }
        return true;
    }
}
