using System.Text;

namespace Problem
{
    internal class Program
    {
        static StringBuilder printstr;
        public static void Move(int number, int start, int end)
        {
            if (number == 1)
            {
                int node = stick[start].Pop();
                stick[end].Push(node);
                printstr.Append((start + 1) + " " + (end + 1) + "\n");
                return;
            }
            int other = (3 - start - end);
            Move(number - 1, start, other);
            Move(1, start, end);
            Move(number - 1, other, end);
        }
        public static Stack<int>[] stick;

        static void Main(string[] args)
        {
            printstr = new StringBuilder("");
            int nodeCount = int.Parse(Console.ReadLine());
            stick = new Stack<int>[3];
            stick[0] = new Stack<int>();
            stick[1] = new Stack<int>();
            stick[2] = new Stack<int>();
            for (int i = nodeCount; i > 0; i--)
            {
                stick[0].Push(i);
            }
            Console.WriteLine(Math.Pow(2, nodeCount) - 1);
            Move(nodeCount, 0, 2);
            Console.WriteLine(printstr.ToString());
        }
    }
}