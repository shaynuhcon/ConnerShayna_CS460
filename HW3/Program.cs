using System;
using System.Collections.Generic;
using System.Text;
using static System.Int32;

namespace HW3
{
    public class Program
    {
        private static LinkedList<string> GenerateBinaryRepresentationList(int n)
        {
            LinkedQueue<StringBuilder> q = new LinkedQueue<StringBuilder>();

            LinkedList<string> output = new LinkedList<string>();

            if (n < 1) return output;

            q.Push(new StringBuilder("1"));

            // Breadth first search
            while (n-- > 0)
            {
                // Print front of queue
                StringBuilder sb = q.Pop();
                output.AddFirst(sb.ToString());

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
            int n = 10;
            if (args.Length < 1)
            {
                Console.WriteLine("Please invoke with the max value to print binary up to, like this:");
                Console.WriteLine("\t--12 ");
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
        }
    }
}
