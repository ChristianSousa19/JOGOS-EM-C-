using System;
using System.Threading;

class programa
{
    static int width = 40;
    static int height = 20;
    static int paddleWidth = 1;
    static int paddleHeight = 4;
    static int ballX;
    static int ballY;
    static int ballSpeedX = 1;
    static int ballSpeedY = 1;
    static int player1Y;
    static int player2Y;
    static int player1Score;
    static int player2Score;
    static bool gameover = false;

    static void Main(string[] args)
    {
        InitializeGame();

        while (!gameover)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                HandleInput(key);
            }

            MoveBall();
            MovePlayer1();
            MovePlayer2();
            CheckCollision();
            DrawBoard();

            Thread.Sleep(50);
        }

        Console.Clear();
        Console.WriteLine("Game Over!");
        Console.WriteLine($"Player 1: {player1Score} pontos");
        Console.WriteLine($"Player 2: {player2Score} pontos");
        Console.ReadLine();
    }

   static void InitializeGame()
    {
        ballX = width / 2;
        ballY = height / 2;
        player1Y = height / 2;
        player2Y = height / 2;
        player1Score = 0;
        player2Score = 0;
        gameover = false;
    }

    static void HandleInput(ConsoleKeyInfo key)
    {
        switch (key.Key)
        {
            case ConsoleKey.W:
                if (player1Y > 0)
                {
                    player1Y--;
                }
                break;
            case ConsoleKey.S:
                if (player1Y < height - paddleHeight)
                {
                    player1Y++;
                }
                break;
            case ConsoleKey.UpArrow:
                if (player2Y > 0)
                {
                    player2Y--;
                }
                break;
            case ConsoleKey.DownArrow:
                if (player2Y < height - paddleHeight)
                {
                    player2Y++;
                }
                break;
            case ConsoleKey.Escape:
                gameover = true;
                break;
        }
    }

    static void MoveBall()
    {
        ballX += ballSpeedX;
        ballY += ballSpeedY;
    }

    static void MovePlayer1()
    {
        // P1 movimento
    }

    static void MovePlayer2()
    {
        // P2 movimento
    }

    static void CheckCollision()
    {
        // verificar a colisão
    }

    static void DrawBoard()
    {
        Console.Clear();

        // Resultado
    }
}
