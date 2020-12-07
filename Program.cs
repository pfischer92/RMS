using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace RMS
{
    public class Program
    {
        private static int _numberOfTasks = 0;
        private static List<SchedulableTask> _taskList;


        static void Main(string[] args)
        {
            Console.WriteLine("RMS simulator application");
            Console.WriteLine("How many Tasks should be handled?: ");
            _numberOfTasks = Convert.ToInt32(Console.ReadLine());
            _taskList = new List<SchedulableTask>();

            for (int i = 0; i < _numberOfTasks; i++)
            {
                Console.WriteLine("How long is the durance of the task?: ");
                int durance = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("In which periodic does the Task occur?: ");
                int periodic = Convert.ToInt32(Console.ReadLine());

                _taskList.Add(new SchedulableTask(durance, periodic));
            }

            // Order the list, highest priority first
            _taskList = _taskList.OrderBy(t => t.Periodic).ToList();

            // Calculate LCM to determine execution cycles
            int n = _taskList.Count;
            int[]arr = _taskList.Select(t => t.Periodic).ToArray();
            int lcm = GetLCM(n, arr);
        }

        private static int GetLCM(int n, int[] arr)
        {
            // Source: https://www.geeksforgeeks.org/finding-lcm-two-array-numbers-without-using-gcd/

            // Find the maximum value in arr[]  
            int max_num = 0;
            for (int i = 0; i < n; i++)
            {
                if (max_num < arr[i])
                {
                    max_num = arr[i];
                }
            }

            // Initialize result  
            int res = 1;

            // Find all factors that are present  
            // in two or more array elements.  
            int x = 2; // Current factor.  
            while (x <= max_num)
            {
                // To store indexes of all array  
                // elements that are divisible by x.  
                ArrayList indexes = new ArrayList();
                for (int j = 0; j < n; j++)
                {
                    if (arr[j] % x == 0)
                    {
                        indexes.Add(j);
                    }
                }

                // If there are 2 or more array elements  
                // that are divisible by x.  
                if (indexes.Count >= 2)
                {
                    // Reduce all array elements divisible  
                    // by x.  
                    for (int j = 0; j < indexes.Count; j++)
                    {
                        arr[(int)indexes[j]] = arr[(int)indexes[j]] / x;
                    }

                    res = res * x;
                }
                else
                {
                    x++;
                }
            }

            // Then multiply all reduced  
            // array elements  
            for (int i = 0; i < n; i++)
            {
                res = res * arr[i];
            }

            return res;
        }
    }
}
