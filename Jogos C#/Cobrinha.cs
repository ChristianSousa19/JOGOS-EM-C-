using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    static int width = 20;
    static int height = 10;
    static int score = 0;
    static bool gameOver = false;
    static Direction direction = Direction.Right;
    static List<int> snakeX = new List<int>();
    static List<int> snakeY = new List<int>();
    static Random random = new Random();
    static int foodX;
    static int foodY;

    static void Main(string[] args)
    {
        Console.WindowHeight = height + 2;
        Console.WindowWidth = width + 2;
        Console.BufferHeight = Console.WindowHeight;
        Console.BufferWidth = Console.WindowWidth;

        InitializeSnake();
        GenerateFood();

        while (!gameOver)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                HandleInput(key);
            }

            MoveSnake();
            if (CheckCollision())
            {
                gameOver = true;
            }
            else
            {
                if (snakeX[0] == foodX && snakeY[0] == foodY)
                {
                    EatFood();
                    GenerateFood();
                }

                DrawBoard();

                Thread.Sleep(100);
            }
        }

        Console.Clear();
        Console.WriteLine($"Game Over! Pontuação: {score}");
        Console.ReadLine();
    }

    static void InitializeSnake()
    {
        int startX = width / 2;
        int startY = height / 2;

        for (int i = 0; i < 3; i++)
        {
            snakeX.Add(startX - i);
            snakeY.Add(startY);
        }
    }

    static void GenerateFood()
    {
        foodX = random.Next(0, width);
        foodY = random.Next(0, height);
    }

    static void DrawBoard()
    {
        Console.Clear();

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                if (x == foodX && y == foodY)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("F");
                }
                else if (snakeX.Contains(x) && snakeY.Contains(y))
                {
                    int index = snakeX.IndexOf(x);
                    if (index == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("O");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("o");
                    }
                }
                else
                {
                    Console.Write(" ");
                }
            }
            Console.WriteLine();
        }

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($"Pontuação: {score}");
    }

    static void HandleInput(ConsoleKeyInfo key)
    {
        switch (key.Key)
        {
            case ConsoleKey.UpArrow:
                if (direction != Direction.Down)
                {
                    direction = Direction.Up;
                }
                break;
            case ConsoleKey.DownArrow:
                if (direction != Direction.Up)
                {
                    direction = Direction.Down;
                }
                break;
            case ConsoleKey.LeftArrow:
                if (direction != Direction.Right)
                {
                    direction = Direction.Left;
                }
                break;
            case ConsoleKey.RightArrow:
                if (direction != Direction.Left)
                {
                    direction = Direction.Right;
                }
                break;
        }
    }

    static void MoveSnake()
    {
        int headX = snakeX[0];
        int headY = snakeY[0];

        switch (direction)
        {
            case Direction.Up:
                headY--;
                break;
            case Direction.Down:
                headY++;
                break;
            case Direction.Left:
                headX--;
                break;
            case Direction.Right:
                headX++;
                break;
        }

        snakeX.Insert(0, headX);
        snakeY.Insert(0, headY);

        snakeX.RemoveAt(snakeX.Count - 1);
        snakeY.RemoveAt(snakeY.Count - 1);
    }

    static bool CheckCollision()
    {
        int headX = snakeX[0];
        int headY = snakeY[0];

        // Verificar colisão com as paredes
        if (headX < 0 || headX >= width || headY < 0 || headY >= height)
        {
            return true;
        }

        // Verificar colisão com o próprio corpo
        for (int i = 1; i < snakeX.Count; i++)
        {
            if (headX == snakeX[i] && headY == snakeY[i])
            {
                return true;
            }
        }

        return false;
    }

    static void EatFood()
    {
        score++;
        snakeX.Add(snakeX[snakeX.Count - 1]);
        snakeY.Add(snakeY[snakeY.Count - 1]);
    }

    enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }
}
