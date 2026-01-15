using System;
using System.Text.RegularExpressions;

public class Validator
{
    public static bool IsValidFormat(string input)
    {
        return Regex.IsMatch(input ?? "", @"^\d{8}-\d{4}$");
    }

    public static bool IsValidPersonnummer(string input)
    {
        if (!IsValidFormat(input)) 
        {
            return false;
        }

        string numbers = input.Replace("-", "");
        string luhnDigits = numbers.Substring(2); 
        int sum = 0;

        for (int i = 0; i < luhnDigits.Length; i++)
        {
            int digit = int.Parse(luhnDigits[i].ToString());

            if (i % 2 == 0)
            {
                digit *= 2;
                if (digit > 9) digit -= 9;
            }

            sum += digit;
        }
        return sum % 10 == 0;
    }
}

public class Program
{
    public static void Main()
    {
        Console.Write("Ange ett svenskt personnummer (YYYYMMDD-XXXX): ");
        string input = Console.ReadLine() ?? "";

        if (!Validator.IsValidFormat(input))
        {
            Console.WriteLine("Fel format! Personnumret måste vara YYYYMMDD-XXXX.");
        }

        else if (Validator.IsValidPersonnummer(input))
        {
            Console.WriteLine("Personnumret är korrekt!");
        }

        else
        {
            Console.WriteLine("Personnumret är ogiltigt!");
        }
    }
}

