using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDED_Scripting_202610_P1
{
    public static class Sandbox
    {
        public static void Main(string[] args)
        {
            
            Queue<int> queue = new Queue<int>(new[] { -1, 4, -9, 16, 25 });
            SeparateElements(queue, out Stack<int> included, out Stack<int> excluded);

            Console.WriteLine("Incluidos:");
            foreach (var item in included)
                Console.WriteLine(item);

            Console.WriteLine("Excluidos:");
            foreach (var item in excluded)
                Console.WriteLine(item);
        }

       
        public static void SeparateElements(Queue<int> input, out Stack<int> included, out Stack<int> excluded)
        {
            included = new Stack<int>();
            excluded = new Stack<int>();

            Stack<int> tempIncluded = new Stack<int>();
            Stack<int> tempExcluded = new Stack<int>();

            while (input.Count > 0)
            {
                int value = input.Dequeue();

                int abs = value < 0 ? -value : value;
                int root = 1;

                while (root * root < abs)
                {
                    root++;
                }

                bool isPerfectSquare = root * root == abs;

                if (isPerfectSquare)
                {
                    if ((root % 2 == 1 && value < 0) || (root % 2 == 0 && value > 0))
                        tempIncluded.Push(value);
                    else
                        tempExcluded.Push(value);
                }
                else
                {
                    tempExcluded.Push(value);
                }
            }

            while (tempIncluded.Count > 0)
                included.Push(tempIncluded.Pop());

            while (tempExcluded.Count > 0)
                excluded.Push(tempExcluded.Pop());
        }

       
    }

}