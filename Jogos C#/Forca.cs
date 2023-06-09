using System;
using System.Linq;


class programas
{
    static string[] words = { "creatina", "whey", "deca", "durateston", "trembolona" };
    static Random random = new Random();
    static string wordToGuess="";
    static char[] guessedLetters = new char[10];

    static int attemptsLeft;

    static void Main(string[] args)
    {
        SelectRandomWord();
        InitializeGame();

        while (attemptsLeft > 0 && !WordGuessed())
        {
            DisplayGameState();
            char guess = GetPlayerGuess();
            ProcessPlayerGuess(guess);
        }

        DisplayEndGameMessage();
        Console.ReadLine();
    }

    static void SelectRandomWord()
    {
        int index = random.Next(0, words.Length);
        wordToGuess = words[index];
    }

    static void InitializeGame()
    {
        guessedLetters = new char[wordToGuess.Length];
        attemptsLeft = 6;

        for (int i = 0; i < wordToGuess.Length; i++)
        {
            guessedLetters[i] = '_';
        }
    }

    static void DisplayGameState()
    {
        Console.Clear();
        Console.WriteLine("Jogo da Forca");
        Console.WriteLine("===============");
        Console.WriteLine();

        for (int i = 0; i < wordToGuess.Length; i++)
        {
            Console.Write(guessedLetters[i] + " ");
        }

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Tentativas restantes: " + attemptsLeft);
        Console.WriteLine();
    }

    static char GetPlayerGuess()
    {
        Console.Write("Digite uma letra: ");
        return Console.ReadKey().KeyChar;
    }

    static void ProcessPlayerGuess(char guess)
    {
        bool foundMatch = false;

        for (int i = 0; i < wordToGuess.Length; i++)
        {
            if (wordToGuess[i] == guess)
            {
                guessedLetters[i] = guess;
                foundMatch = true;
            }
        }

        if (!foundMatch)
        {
            attemptsLeft--;
        }
    }

    static bool WordGuessed()
    {
        return !guessedLetters.Contains('_');
    }

    static void DisplayEndGameMessage()
    {
        Console.Clear();

        if (WordGuessed())
        {
            Console.WriteLine("Parabéns! Você adivinhou a palavra: " + wordToGuess);
        }
        else
        {
            Console.WriteLine("Você perdeu! A palavra era: " + wordToGuess);
        }
    }
}
