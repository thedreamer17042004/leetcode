using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace longestSubstringwithoutRepeatingCharacters
{
    public class Solution
    {
        public int LengthOfLongestSubstringMyCode(string s)
        {
            // s = "abcabcbb"
            //s = "pwwkew";
            //khi mà gặp  ký tự trùng thì ta có thể lấy index từ ký tự đó rồi tiếp tục triển khai tìm các ký tự sau để check có được không

            //pw -> 2
            //wke-> 3
            //w -> 1

            //pw -> 2
            //w -> 1
            //wke-> 1
            //kew->3
            //ew-> 3
            //w

            //abc -> 3
            //abc -> 3
            //b -> 1

            //khi mà gặp ký tự nào trùng thì

            // output = 3 -> abc lenght là 3 nhé
            // tách từng ký tự trong chuỗi s
            // duyệt qua mảng ký tự đó để lấy từng ký tự

            // ta sẽ tạo 1 mảng lưu lại các ký tự vào mảng sẵn đó
            // ta sẽ tạo ra 1 biến lưu lại max các char khong lặp lại

            //khi lấy ra ký tự đầu tiên trong for thì ta thêm nó vào mảng ta đã tạo để lưu lại
            //rồi bên trong ta tạo for nữa  để duyệt các ký tự tiếp theo trong mảng
            //rồi lấy từng ký trong mảng chars đó rồi ta xem mảng ta tạo có chứa nó khong
            ///nếu không thì ta thêm vào và gán max length =  lenght của mảng (so sánh max length vs max length trước đó nha)
            /////nếu mà trùng thì ta sẽ dừng lặp và xóa hết item trong mảng đã tạo đi
            // rồi tiếp lặp tới phần tử tiếp theo và loop tiếp 
            if (string.IsNullOrEmpty(s) || s.Length == 0)
            {
                return 0;
            }
            int maxLength = 0;
            char[] chars = new char[s.Length];
            chars = s.ToCharArray();
            // tạo mảng để lưu lại các ký tự không lặp lại
            List<char> uniqueChars = new List<char>();

            for (int i = 0; i< chars.Length; i++)
            {
                uniqueChars.Add(chars[i]);
                for(int j = i+1; j< chars.Length; j++)
                {
                    if (!uniqueChars.Contains(chars[j]))
                    {
                        uniqueChars.Add(chars[j]);
                        maxLength = Math.Max(maxLength, uniqueChars.Count);
                    }else
                    {
                        uniqueChars.Clear();
                        break;
                    }
                }
               
            }

            return maxLength==0?maxLength+1:maxLength;
        }

        public int LengthOfLongestSubstringMyCodeV1(string s)
        {
            //s = "pwkelke";
            //s1="dvdf"
            //?)khi mà gặp  ký tự trùng thì ta có thể lấy index từ ký tự đó  rồi tiếp tục ta substring index của nó + 1 và triển khai tiếp


            //duyệt để lấy từng index của chars rồi ta sẽ check xem s hiện tại cs chứa ký tự giống vs idx hiện tại không
            //nếu mà khong thì ta sẽ check max lenght của chuỗi hiện tại so vs max length cũ 
            //rồi nếu mà trùng thì tìm idx của cái trung + 1 rồi cắt chuỗi xong tăng idx lên tiếp tục while nhé

            //rồi loop vô tận

            if (string.IsNullOrEmpty(s) || s.Length == 0)
            {
                return 0;
            }

            int maxLength = 0;
            int idx = 0;
            string s1 = "";

            char[] chars = new char[s.Length];
            chars = s.ToCharArray();

            while (idx < chars.Length)
            {
                if (!s1.Contains(chars[idx]))
                {
                    s1+=chars[idx];
                    maxLength = Math.Max(maxLength, s1.Length);
                    idx++;

                }else
                {
                    s1= s1.Substring(s1.IndexOf(chars[idx]) + 1);
                    s1 += chars[idx];
                    idx++;
                }
            }

            return maxLength;
        }

        public int LengthOfLongestSubstringHashSet(string s)
        {
            //Optimized Approach
            if (string.IsNullOrEmpty(s) || s.Length == 0)
            {
                return 0;
            }
            //create two pointers 
            int start = 0;
            int end = 0;

            int maxLength = 0;

            HashSet<char> charSet = new HashSet<char>();

            while (end < s.Length)
            {
                if (!charSet.Contains(s[end]))
                {
                    //add it
                    charSet.Add(s[end]);

                    end++;

                    maxLength = Math.Max(maxLength, (end - start));
                }
                else
                {
                    charSet.Remove(s[start]);

                    start++;
                }
            }
            return maxLength;
        }
    }
}
