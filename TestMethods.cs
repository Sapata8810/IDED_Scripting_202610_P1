namespace IDED_Scripting_202610_P1
{
    internal class TestMethods
    {
        public static void SeparateElements(Queue<int> input, out Stack<int> included, out Stack<int> excluded)
        {
            included = new Stack<int>();
            excluded = new Stack<int>();

            while (input.Count > 0)
            {
                int value = input.Dequeue();
                int abs = value < 0 ? -value : value;

                int root = 0;
                while (root * root < abs)
                {
                    root++;
                }

                bool isPerfectSquare = (root * root == abs);

                if (isPerfectSquare)
                {
                
                    if ((root % 2 == 0 && value >= 0) || (root % 2 != 0 && value < 0))
                    {
        
                        included.Push(value);
                    }
                    else
                    {
                        excluded.Push(value);
                    }
                }
                else
                {
                    excluded.Push(value);
                }
            }
        }

        public static List<int> GenerateSortedSeries(int n)
        {
            List<int> result = new List<int>();


            for (int i = 0; i < n; i++)
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
            if (n <= 1) return false;
            if (n == 2) return true; // El 2 es primo
            if (n % 2 == 0) return false; // Pares fuera

            for (int i = 3; i * i <= n; i += 2) // Solo probamos impares hasta la raíz cuadrada
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