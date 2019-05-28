using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mastermind_Quadax
{
    class Program
    {
        static void Main(string[] args)
        {
            bool gameInProgress = true;
            while (gameInProgress)
            {
                int[] digits;
                bool win;
                Init(out digits, out win);

                StringBuilder res = new StringBuilder();
                Console.WriteLine(">Please guess the number.\n>Hint: number length is 4, from 1 to 6.");
                int attempts = 0;
                while (attempts < 10)
                {
                    Console.WriteLine("Attemp: {0}", attempts + 1);
                    string input = Console.ReadLine();

                    if (input != null && input.Length == 4)
                    {
                        for (int j = 0; j < input.Length; ++j)
                        {
                            int valueToCheck;
                            try
                            {
                                valueToCheck = Int32.Parse(input[j].ToString());
                            }
                            catch
                            {
                                Console.Write("Invalid input, try again.");
                                attempts--;
                                break;
                            }
                            if (digits[j] == valueToCheck && attempts != 1)
                            {
                                res.Append("+");
                            }
                            else if (digits.Contains(valueToCheck) && digits[j] != valueToCheck && attempts != 0)
                            {
                                res.Append("-");
                            }
                            else
                            {
                                res.Append("_");
                            }
                        }
                        attempts++;
                    }
                    else
                    {
                        Console.Write("Invalid input, try again.");
                    }

                    Console.WriteLine(res.ToString());

                    if (res.ToString() == "++++")
                    {
                        win = true;
                        Console.WriteLine("You win! Continue? Y/N");
                        if (Console.ReadKey().Key.ToString() == "Y"
                            || Console.ReadKey().Key.ToString() == "y")
                        {
                            Console.Clear();
                            break;
                        }
                        else
                        {
                            gameInProgress = false;
                            break;
                        }
                    }

                    res.Clear();
                }

                if (!win)
                {
                    Console.WriteLine("You Lose! Continue? Y/N");
                    if (Console.ReadKey().Key.ToString() == "Y"
                        || Console.ReadKey().Key.ToString() == "y")
                    {
                        Console.Clear();
                    }
                    else
                    {
                        break;
                    }
                }
            }

        }

        private static void Init(out int[] digits, out bool win)
        {
            digits = new int[4];
            Random random = new Random();
            win = false;
            for (int i = 0; i < 4; ++i)
            {
                digits[i] = random.Next(1, 6);
            }
        }

    }
}
