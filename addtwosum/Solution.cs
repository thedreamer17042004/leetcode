using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addtwosum
{
    public class Solution
    {
        //33ms
        public int[] TwoSum(int[] nums, int target)
        {

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        return new int[] { i, j };
                    }
                }
            }
            return new int[] { -1, -1 };
        }

        //chậm hơn hơn 2 for lồng nhau = 1s
        public int[] TwoSum2(int[] nums, int target)
        {

            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                var result = map.Where(item => item.Value + nums[i] == target).Select(item => item.Key).FirstOrDefault();
                if (result != 0)
                {
                    return new int[] { result-1, i };

                }
                else
                {
                    map.Add(i+1, nums[i]);
                }
            }

            return new int[] { -1, -1 };
        }


        //siêu nhanh 1ms
        public int[] TwoSum3(int[] nums, int target)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (map.ContainsKey(target - nums[i]))
                {
                    return new int[] { map[target - nums[i]], i };
                }
                else
                {
                    map[nums[i]] = i;
                }
            }

            return new int[] { -1, -1 };
        }
    }
}


