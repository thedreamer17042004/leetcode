using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace containerWithMostWater
{
    public class Solution
    {
     
        //tối ưu
        public int MaxArea(int[] height)
        {

            var max = 0;
            int length = height.Length - 1;
            int i = 0; int j = length;
            while (i < j)
            {
                //kiểm tra xem phần tử i so với phần tử j xem cái nào nhỏ hơn thì gán max cho nó
                //điều kiện tăng i khi mà height i <=height j vì giá trị max trc đó đã là max rồi á cho dù ta lấy giá trị i đó so vs các cái tiếp theo nó không thể lớn hơn
                //điều  kiện tăng j khi mà height i> height j vì giá trị max trc đó đã là max rồi á cho dù ta lấy giá trị j đó so vs các cái tiếp theo nó không thể lớn hơn
              
                //kết luận cột thấp hơn là giới hạn chiều cao vậy muốn tìm ccột cao hơn hay diện tích lớn hơn ta phải di chuyển nó nhé----fighting
                max = Math.Max(max, Math.Min(height[i], height[j]) * (j - i));

                if (height[i] <= height[j])
                {
                    i++;

                }else
                {
                    j--;
                }
            }

            return max;
        }
    }
}
