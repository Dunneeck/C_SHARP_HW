using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar_4
{
    internal class HomeWork
    {
        
        public static void PrintAllTriplets(int[] nums, int target)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                dict[nums[i]] = i;
            }

            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    int val = target - (nums[i] + nums[j]);

                    if (dict.ContainsKey(val))
                    {
                        if (dict[val] != i && dict[val] != j)
                        {
                            Console.WriteLine($"{val} + {nums[i]} + {nums[j]} = {target}");
                        }
                    }
                }
            }
        }

        public static void MySolution(int[] nums, int target) {
            for (int i = 0; i < nums.Length - 2; i++)
            {
                for (int j = i + 1; j < nums.Length - 1; j++)
                {
                    for (int k = j + 1; k < nums.Length; k++)
                    {
                        if (nums[i] + nums[j] + nums[k] == target)
                        {
                            Console.WriteLine($"{nums[i]} + {nums[j]} + {nums[k]} = {target}");
                        }
                    }
                }
            }
        }
    }
}

