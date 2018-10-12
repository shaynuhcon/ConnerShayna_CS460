using System;
using System.Collections.Generic;
using System.Text;
using static System.Int32;

namespace HW3
{
    public class Program
    {
        /// <summary>
        /// Uses FIFO queue to perform a level order traversal of a virtual binary
        /// tree then stores each value in a list as it is visited. 
        /// </summary>
        /// <param name="n">Number of values</param>
        /// <returns>Binary string output</returns>
        private static LinkedList<string> GenerateBinaryRepresentationList(int n)
        {
            // Empty queue for traversal
            LinkedQueue<StringBuilder> q = new LinkedQueue<StringBuilder>();

            // Output list for binary values
            LinkedList<string> output = new LinkedList<string>();

            // Return empty list if input less than 1
            if (n < 1) return output;

            q.Push(new StringBuilder("1"));

            while (n-- > 0)
            {
                // Print front of queue
                StringBuilder sb = q.Pop();
                output.AddLast(sb.ToString());

                // Copy of string builder
                StringBuilder sbc = new StringBuilder(sb.ToString());

                // Left
                sb.Append("0");
                q.Push(sb);

                // Right
                sbc.Append("1");
                q.Push(sbc);
            }

            return output;
        }

        public static void Main(string[] args)
        {
            int n;
            if (args.Length < 1)
            {
                Console.WriteLine("Please provide a numeric input. Example below:");
                Console.WriteLine("\tHW3.exe 12");
                return;
            }

            try
            {
                n = Parse(args[0]);
            }
            catch (FormatException e)
            {
                Console.WriteLine($"Exception caught: {e.Message}");
                return;
            }

            LinkedList<string> output = GenerateBinaryRepresentationList(n);
            int maxLength = output.Last.List.Count;

            foreach (var s in output)
            {
                for (int i = 0; i < maxLength - s.Length; ++i)
                {
                    Console.Write(" ");
                }

                Console.WriteLine(s);
            }

            Console.WriteLine("Press \"Enter\" key to exit...");
            Console.Read();
        }
    }
}
