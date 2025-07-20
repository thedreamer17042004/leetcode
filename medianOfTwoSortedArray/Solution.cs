using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace medianOfTwoSortedArray
{
    public class Solution
    {
        /*
         --giải thích đề bài là tìm số ở giữa 1 mảng đã được merge lại
        --nếu mảng đó có sô phần tử là lẻ thì trả về phần tử ở giữa
        --nếu mảng đó có số phần tử là chẵn thì trả về trung bình cộng của 2 phần tử ở giữa

        + cách để merge 2 mảng đã sắp xếp lại với nhau
        a = [1,4]; b = [2,5]
        //cách 1 là ta sẽ duyệt mảng đến đâu thì sort tới đo
        -> ta sẽ tự định nghĩa 2 con trỏ i và j để duyệt mảng a và b

        ? khi nào thì i tăng lên -> khi mà khong có thằng nào nằm trong mảng b bé hơn i ,
        ? khi nào thì j tăng lên -> khong có thằng nào của mảng a bé hơn j

        - i, j khởi tạo sẽ là 0,0

        -b1: kiểm tra điều kiện xem a, b có data không nếu 1 trong 2 mảng không có data thì trả về mảng còn lại
        -b2: nếu hai mảng đều có data thì ta sẽ cho vào vong while để xử lý
        ? ta cần điều kiện gì cho i, j trong vòng while này -> i or j phải nhỏ hơn lenght của mảng nha
        
        -b3. ta sẽ lấy giá trị của a[i] và b[j] để so sánh với nhau
        vd: a[0] = 1 , b[0] = 2  , i < j -> ta push giá trị của i vào 1 mảng c -> tăng i lên
            a[1] = 4 , b[0] = 2 , i > j -> ta push giá trị của j vào mảng c -> tăng j lên
            a[1] = 4 , b[1] = 5 , i < j -> ta push giá của của i vào mảng c -> tăng i lên
            i khong thỏa mãn điều kiện out of index rồi ta lấy phần tử còn lại của mảng b theo j để push vào mảng c nhé

        -b4: sau khi đã sắp xếp xong thì ta đến bước tiếp theo nha

        //cách 2 là ta merge vào luông rồi áp dụng qui tắc sort nha


        + cách kiểm tra xem là mảng này có tổng số phần tử chẵn hay lẻ --> .length thôi
       
        + nếu là lẻ thì cách để trả về phần tử ở giữa

        [1,2,3] (size = 3) -> lẻ -> trả ra index = 1 = 2; 
        [1,2,3,4,5] (size = 5) -> lẻ trả ra index =  2 = 3
        [1,2,3,4,5,6,7] (size = 7) -> lẻ trả ra index = 3 = 4
        [1,2,3,4,5,6,7,8,9] (size = 9) -> lẻ trả ra index = 4 = 5;
        [1,2,3,4,5,6,7,8,9,10,11] (size = 11) -> lẻ trả ra index = 5 = 6;
        --> ra quy tắc là khi mà số lượng phần tử là lẻ thì ta sẽ lấy  --> suy ra số median của mảng là = (size - 1) / 2
       
        + nếu là chẵn thì cách để xác định 2 phần tử ở giữa 
            [1,2,3,4] (size = 4) -> chẵn -> trả ra index 1,2 = 2,3
            [1,2,3,4,5,6] (size = 6) -> chẵn -> trả ra index 2,3 = 3,4
            [1,2,3,4,5,6,7,8] (size = 8) -> chẵn -> trả ra index 3,4 = 4,5
            [1,2,3,4,5,6,7,8,9,10] (size = 10) -> chẵn -> trả ra index 4,5 = 5,6
        --> ra quy tắc là khi mà số lượng phần tử là chẵn thì ta sẽ lấy --> lấy (size / 2) - 1 và  size / 2; 
        --> tính trung cộng của hai số đó (để trả về số median của mảng)
         */
        //2ms second Time complexity
        public double FindMedianOfTwoSortedArray(int[] nums1, int[] nums2)
        {
            //merge sorted
            int i = 0; int j = 0; int[] c = new int[nums1.Length+ nums2.Length];int k = 0;

            while (i < nums1.Length || j < nums2.Length)
            {
                if (i < nums1.Length && j < nums2.Length)
                {
                    if (nums1[i] < nums2[j])
                    {
                        c[k] = nums1[i];
                        i++;

                    }
                    else
                    {
                        c[k] = nums2[j];
                        j++;
                    }
                }
                else if (i < nums1.Length)
                {
                    c[k] = nums1[i];
                    i++;

                }
                else if (j < nums2.Length)
                {
                    c[k] = nums2[j];
                    j++;
                }
                k++;
            }


            //check size of c
            int size = c.Length;

            //chẵn
            if(size % 2 == 0)
            {
                int number1 = c[(size / 2) - 1];
                int number2 = c[size / 2];
                return (number1 + number2) / 2.0;
            }
            else
            {
                //lẻ
                int indexOfMedian = (size - 1) / 2;
                return c[indexOfMedian];
            }

        }

        //15ms Time complexity
        public double FindMedianOfTwoSortedArrayQuickSort(int[] nums1, int[] nums2)
        {
            int[] c = nums1.Concat(nums2).ToArray();


            Array.Sort(c);

            //check size of c
            int size = c.Length;

            //chẵn
            if (size % 2 == 0)
            {
                int number1 = c[(size / 2) - 1];
                int number2 = c[size / 2];
                return (number1 + number2) / 2.0;
            }
            else
            {
                //lẻ
                int indexOfMedian = (size - 1) / 2;
                return c[indexOfMedian];
            }

        }

    }
}
