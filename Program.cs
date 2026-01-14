using System;
using System.Text.RegularExpressions;

Console.Write("Ange ett svenskt personnummer (YYYYMMDD-XXXX): ");
string input = Console.ReadLine() ?? "";

if (!Regex.IsMatch(input, @"^\d{8}-\d{4}$"))
{
    Console.WriteLine("Fel format.");
}

else
{
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

    if (sum % 10 == 0)
    {
        Console.WriteLine("Personnumret är korrekt!");
    }

    else
    {
        Console.WriteLine("Personnumret är ogiltigt!");
    }
}