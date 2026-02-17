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

            Stack<int> tempInc = new Stack<int>();

            while (included.Count > 0)
            {
                int value = included.Pop();
                Console.WriteLine(value);
                tempInc.Push(value);
            }

            // Restaurar pila
            while (tempInc.Count > 0)
            {
                included.Push(tempInc.Pop());
            }

            Console.WriteLine("Excluidos:");

            Stack<int> tempExc = new Stack<int>();

            while (excluded.Count > 0)
            {
                int value = excluded.Pop();
                Console.WriteLine(value);
                tempExc.Push(value);
            }

            while (tempExc.Count > 0)
            {
                excluded.Push(tempExc.Pop());
            }
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

        public static List<int> GenerateSortedSeries(int n)
        {
            List<int> result = new List<int>();

            for (int i = 1; i <= n; i++)
            {
                int value = i * i;

                if (i % 2 == 1)
                    value = -value;

                result.Add(value);
            }

            for (int i = 0; i < result.Count - 1; i++)
            {
                for (int j = 0; j < result.Count - i - 1; j++)
                {
                    if (result[j] > result[j + 1])
                    {
                        int temp = result[j];
                        result[j] = result[j + 1];
                        result[j + 1] = temp;
                    }
                }
            }

            return result;
        }


        public static bool FindNumberInSortedList(int target, in List<int> list)
        {
            List<int> copy = new List<int>();

            for (int i = 0; i < list.Count; i++)
                copy.Add(list[i]);

            for (int i = 0; i < copy.Count - 1; i++)
            {
                for (int j = 0; j < copy.Count - i - 1; j++)
                {
                    if (copy[j] < copy[j + 1])
                    {
                        int temp = copy[j];
                        copy[j] = copy[j + 1];
                        copy[j + 1] = temp;
                    }
                }
            }

            for (int i = 0; i < copy.Count; i++)
                if (copy[i] == target)
                    return true;

            return false;
        }

        public static int FindPrime(in Stack<int> list)
        {
            Stack<int> temp = new Stack<int>();

            int result = 0;

            while (list.Count > 0)
            {
                int value = list.Pop();
                temp.Push(value);

                if (IsPrime(value))
                {
                    result = value;
                    break;
                }
            }

            while (temp.Count > 0)
                list.Push(temp.Pop());

            return result;
        }


        public static bool IsPrime(int n)
        {
            if (n <= 1)
                return false;

            for (int i = 2; i < n; i++)
                if (n % i == 0)
                    return false;

            return true;
        }


        public static Stack<int> RemoveFirstPrime(in Stack<int> stack)
        {
            Stack<int> temp = new Stack<int>();
            bool removed = false;

            while (stack.Count > 0)
            {
                int value = stack.Pop();

                if (!removed && IsPrime(value))
                {
                    removed = true;
                    continue;
                }

                temp.Push(value);
            }

            Stack<int> result = new Stack<int>();

            while (temp.Count > 0)
                result.Push(temp.Pop());

            return result;
        }


        public static Queue<int> QueueFromStack(Stack<int> stack)
        {
            Queue<int> queue = new Queue<int>();
            Stack<int> temp = new Stack<int>();

            while (stack.Count > 0)
                temp.Push(stack.Pop());

            while (temp.Count > 0)
            {
                int value = temp.Pop();
                queue.Enqueue(value);
                stack.Push(value);
            }

            return queue;
        }

    }
}