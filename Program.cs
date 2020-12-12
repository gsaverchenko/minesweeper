using System;

namespace minesweeper
{
    class Program
    {
        static void Main(string[] args)
        {
            var map = new int[10];
            map[4] = 1;
            map[7] = 1;
            var answer = string.Empty;
            Console.WriteLine("Type a number 1-10");
            
            while (answer.ToUpper() != "EXIT")
            {
                int guess;
                answer = Console.ReadLine();
                var result = int.TryParse(answer, out guess);
                if (guess == 5 || guess == 8)
                {
                    Console.WriteLine("BOOM!!!");
                }
                else
                {
                    Console.WriteLine("You're safe :D");
                }
            }
        }
    }
}
