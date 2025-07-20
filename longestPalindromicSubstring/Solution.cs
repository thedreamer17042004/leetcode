using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace longestPalindromicSubstring
{
    public class Solution
    {
        public string FindLongestPalindromic(string s)
        {
            //s = babad
            //output:bab

            /**
             * Điều kiện nha
             * để tìm chuỗi xuôi ngc thì phải chuỗi liền kề nhau á!!!
             * 
             * nếu chuỗi là rỗng thì return 0
             * nếu chuỗi là 1 thì return chuỗi đó luôn
             */

            //? làm thế nào để lấy bab (chuỗi con) từ chuõi s
            /*
                --> thì ta sẽ dùng substring cắt chuỗi s từ start index 0 -> tới end index 1 chả hạn (start index và end index)
                --> ?khi nào thì start index tăng lên --> khi mà cắt hết 1 vòng tới end index của chuỗi s nhớ
            --> ta sẽ dùng while cái startindex >= lenght - 1 của chuỗi
            -->khi end index bằng lenght -1 thì ta sẽ tăng startindex lên nha
             */

            //?cách để  kiểm tra chuỗi lấy dc là xuôi ngược
            /*là chuỗi ban đâu sẽ bằng chuõi khi đảo ngược
             * --> làm thế nào để đảo ngược
             --> bab = bab
                 012 = 012
            --> lấy item ở index thứ 0 so sánh với item ở index thứ 0 + 2; nếu lenght là lẻ
            --> item ở index thứ 1 thì so sánh với chính nó 1 + 0
            = babc = cbab
              0123 = 0123
            --> nếu item là chẵn thì 
            --> lấy item ở index số 0 so sánh với item ở index thứ 0 + 3 ( 3 = lenght - 1 = 4 - 1 )-->lưu lại last index vào là 3
            --> item ở index số 1 so sánh với item ở index thứ 1 + 1; ( 1 = 3 - 2)

            = abcde = edcba --> lẻ
              01234 = 01234
            --> lấy item ở index số 0 so sánh với item ở index thứ 0 + 4 ( 4 = lenght - 1 = 5  - 1)
            --> lấy item ở index 1 so sánh với item ở index 1 + 2 ( là 4 - 2)
            -->lấy item ở index 2 so sánh với item ở index 2 + 0 ( 0 = 2 - 2)

            --> kết luận ta chỉ cần duyệt một nửa chuối để check xuôi ngược thôi á < lenght / 2 -> làm tròn xuống á

             */

            //---->LẬP TRÌNH NHA
            //ta sẽ tạo ra 2 biến 1 biến là start index, và 1 biến là end index nhá
            //rồi ta duyệt while điều kiện dừng khi start index >= lennght - 1 || (start index > end index)
            //khi mà start index tăng thì end index cũng tăng nha
            //ta sẽ thực hiện cắt chuỗi từ vị trí start index đến end index
            //rồi ta sẽ thực hiện check xem có đứng là xuôi ngược không nếu đúng thì lưu lại chuỗi đó vào biến biến kq
            //rồi cứ thiếp tục cho đến khi kiểm tra mà cs chuõi tm điều kiện xuoi ngược và có lenght > max lenght của chuỗi đã thực hiện nha

            //abcd ; lenght = 4
            //start = 0; end = 2
            if (string.IsNullOrEmpty(s) || s.Length == 1)
            {
                return s;
            }
            var lenght = s.Length;
            var startIndex = 0; var endIndex = 2; var currentMaxPalim = "a";

            while (startIndex < endIndex && endIndex <= s.Length)
            {
                if (currentMaxPalim.Length >= lenght - startIndex)
                {
                    break;
                }

                var currenSubstring = s.Substring(startIndex, endIndex - startIndex);

                if (IsPalimdrom(currenSubstring))
                {
                    //kiểm tra xem là lenght của chuỗi này so với lenght của chuỗi lớn nhất có tm
                    if (currenSubstring.Length > currentMaxPalim.Length)
                    {
                        currentMaxPalim = currenSubstring;
                    }
                }

                if (endIndex > lenght - 1)
                {
                    startIndex++;
                    endIndex = startIndex + 1;
                }

                endIndex++;

            }

            return currentMaxPalim;
        }

        /// <summary> nnn
        ///hàm này kiểm tra xem chuỗi có phải là xuôi ngược hay không nha
        public bool IsPalimdrom(string s)
        {
            var previousIndex = s.Length - 1;
            for (int i = 0; i < s.Length / 2; i++)
            {
                //ta sẽ lấy phần tử ở index đầu tiên so sánh với phần tử ở index previous index
                //nếu thỏa mãn thì tiếp tục
                //còn không thì return false luôn á
                if (s[i] != s[previousIndex + i])
                {
                    return false;
                }
                previousIndex -= 2;
            }
            return true;
        }

        public string LongestPalindrome(string s)
        {
            if (string.IsNullOrEmpty(s) || s.Length == 1)
                return s;

            int start = 0, maxLength = 1;

            for (int i = 0; i < s.Length; i++)
            {
                // Kiểm tra palindrome với tâm đơn (odd length)
                ExpandFromCenter(s, i, i, ref start, ref maxLength);
                // Kiểm tra palindrome với tâm kép (even length)
                ExpandFromCenter(s, i, i + 1, ref start, ref maxLength);
            }

            return s.Substring(start, maxLength);
        }
        //abcd
        private void ExpandFromCenter(string s, int left, int right, ref int start, ref int maxLength)
        {
            // Mở rộng sang trái và phải chừng nào còn đối xứng
            while (left >= 0 && right < s.Length && s[left] == s[right])
            {
                left--;
                right++;
            }

            // Sau khi thoát vòng lặp, left và right đã đi quá giới hạn 1 bước
            int length = right - left - 1;

            // Nếu đoạn này dài hơn đoạn cũ, thì cập nhật kết quả
            if (length > maxLength)
            {
                maxLength = length;
                start = left + 1; // vì left đã lùi thêm 1 bước nên phải +1 lại
            }
        }

    }
}
