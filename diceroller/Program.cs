using System;

internal class Program
{
    static Random random = new Random();

    static void Main(string[] args)
    {
        int sides;
        do
        {
            Console.Write("Enter the number of sides for a pair of dice: ");
            string input = Console.ReadLine();
            if (!int.TryParse(input, out sides))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
            else if (sides <= 0)
            {
                Console.WriteLine("Number of sides should be positive. Please enter a valid number.");
            }
            else
            {
                RollDice(sides);
                Console.Write("Do you want to roll the dice again? (Y/N): ");
            }
        } while (Console.ReadLine().ToUpper() == "Y");
    }

    static void RollDice(int sides)
    {
        try 
        {
            int dice1 = RandomNumber(1, sides);
            int dice2 = RandomNumber(1, sides);
            int total = dice1 + dice2;
            Console.WriteLine($"Dice 1: {dice1}\nDice 2: {dice2}\nTotal: {total}");

            if (sides == 6)
            {
                string combo = CheckCombo(dice1, dice2);
                if (combo != "") Console.WriteLine(combo);
                else if (total == 7 || total == 11) Console.WriteLine("Win!");
                else if (total == 2 || total == 3 || total == 12) Console.WriteLine("Craps!");
            }
        }
        catch (FormatException ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static int RandomNumber(int min, int max)
    {
        return random.Next(min, max + 1);
    }

    static string CheckCombo(int dice1, int dice2)
    {
        if (dice1 == 1 && dice2 == 1) return "Snake Eyes!";
        else if (dice1 == 1 && dice2 == 2 || dice1 == 2 && dice2 == 1) return "Ace Deuce!";
        else if (dice1 == 6 && dice2 == 6) return "Box Cars!";
        else return "";
    }
}
