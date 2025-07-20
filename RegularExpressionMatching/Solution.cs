using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RegularExpressionMatching
{
    public class Solution
    {
        /*

         *  th1: trường hợp không có ký tự . hay * nào cả 
         *  --> check xem p có gồm ký tự * or . hay không
         *  --> check chuỗi s và p nếu trùng độ dài và giống nhau thì set là true nha
         *  
         *  th2: trường hợp chỉ có ký tự . trong p
         *  --> check xem có ký tự . trong p hay khong
         *  --> check xem lenght của s và p có bằng nhau không
         *  --> lấy ký tự theo index của s so sánh với index khác . của p để xem có giống khong 
         *  --> nếu oke thì set là true nha
         *  
         *  th3: trường hợp chỉ có ký tự * trong p
         *  --> check xem p có duynhất ký tự * hay không
         *  --> và check xem * có đứng đầu p hay không
         *  --> (I)
         *    *  --(I)---
         *  s = aabbc , p = a*b*c ->true
         *  --> mô tả qui trình lập trình
         *  ta có index cho s và p
         *  --> đầu tiên index s là 0, index p là 0
         *  --> rồi so sánh giá trị index a của s so với giá trị index của p xem có giống nhau khong(*)
         *  --> rồi ta xem sau p ký tự đầu tiên có * hay không (1)
         *  -->nếu có thì ta sẽ gán result = đệ qui tăng index s lên 1 và giữ nguyên index p && (*) giống nhau || (*) khác thì  ta sẽ giữ nguyên idx s và tăng idxp lên 2
         *  --> nếu không thì (*) phải match và đệ qui tăng index s lên 1 và index p lên 1 luôn nhé
         *  
         *  điều khện dừng là j = p.length thì return s = s.lenght nhé in đệ qui
      
         *  
         *  th4: trường hợp có cả ký tự . và * trong p
         *  --> check xem p có phải là có 2 ký tự . và * hay không
         *  --> thì check xem * có đứng đầu p hay không 
         *  ( cso cần check ** liền kề nhau hay không )
            giống th3 -> vì th3 là trường hợp tổng quát

         */
        private Dictionary<(int, int), bool> memo = new();
        public bool IsMatch(string s, string p)
        {
            //trường hợp 1 không có ký tự . và * nhé
            if (!p.Contains(".") && !p.Contains("*"))
            {
                return s.Length == p.Length && s == p;
            }

            //trường hợp 2 chỉ có ký tự . trong p
            if (p.Contains(".") && !p.Contains("*"))
            {
                if (s.Length != p.Length)
                {
                    return false;
                }

                int indexS = 0;

                while (indexS < s.Length)
                {
                    if (s[indexS] == p[indexS] || p[indexS] == '.')
                    {
                        indexS++;
                    }
                    else
                    {
                        return false;
                    }
                }

                return true;
            }

            //trường hợp 3 chỉ có ký tự * trong p
            if (p.Contains('*') && !p.Contains("."))
            {
                return MatchStarOnly(s, p);
            }

            //trường hợp 4 có cả ký tự . và * trong p
            if (p.Contains(".") && p.Contains("*"))
            {
                return MatchDotStar(s, p);
            }

            return false;
        }
        private bool MatchStarOnly(string s, string p)
        {
            int sIdx = 0, pIdx = 0;

            while (pIdx < p.Length)
            {
                // Nếu ký tự tiếp theo là '*'
                if (pIdx + 1 < p.Length && p[pIdx + 1] == '*')
                {
                    char curChar = p[pIdx];
                    //s = aab, p = a*b
                    // Lặp lại curChar trong s bao nhiêu lần tùy thích
                    while (sIdx < s.Length && s[sIdx] == curChar)
                    {
                        //bỏ qua x* để match những thứ đằng sau p so với chuỗi s
                        if (MatchStarOnly(s.Substring(sIdx), p.Substring(pIdx + 2)))
                            return true;
                        sIdx++;
                    }

                    // Thử bỏ qua luôn curChar* trong p
                    pIdx += 2;
                }
                else
                {
                    // Không có *, thì match đúng 1 ký tự
                    if (sIdx >= s.Length || s[sIdx] != p[pIdx])
                        return false;
                    sIdx++;
                    pIdx++;
                }
            }

            return sIdx == s.Length;
        }

        private bool MatchDotStar(string s, string p)
        {
            return Dfs(0, 0, s, p);
        }

        private bool Dfs(int i, int j, string s, string p)
        {
            if (memo.ContainsKey((i, j)))
                return memo[(i, j)];

            if (j == p.Length)
                return i == s.Length;

            bool firstMatch = i < s.Length && (p[j] == s[i] || p[j] == '.');

            bool result;

            if (j + 1 < p.Length && p[j + 1] == '*')
            {
                // Bỏ qua x* hoặc dùng x nếu match
                result = Dfs(i, j + 2, s, p) || (firstMatch && Dfs(i + 1, j, s, p));
            }
            else
            {
                result = firstMatch && Dfs(i + 1, j + 1, s, p);
            }

            memo[(i, j)] = result;
            return result;
        }


        //CACH TỐI ƯU NHẤT CÓ THỂ
        public bool IsMatchLeetcode(string s, string p)
        {
            return Dfs1(0, 0, s, p);
        }

        private bool Dfs1(int i, int j, string s, string p)
        {
            if (memo.ContainsKey((i, j)))
                return memo[(i, j)];

            if (j == p.Length)
                return i == s.Length;

            bool firstMatch = i < s.Length && (s[i] == p[j] || p[j] == '.');

            bool result;
            //s = aaa , p = a*a
            /*
             -firstmatch = true;result = true&& Dfs1(i + 1, j, s, p); bắt dấu dòng 270;i = 0;j = 0
            - fistmatch = true;result = true &&  Dfs1(i + 1, j, s, p); bắt dấu dòng 270;i = 1;j= 0
            - firstmatch = true; result = true && Dfs1(i+1, j, s, p); bắt dấu dòng 270;i = 2;j=0

            -chạy i = 2; dfs(i, j+2, s, p) - bắt dấu dòng 270; i = 2; j = 2; ->true
            -chạy i = 2;j = 2;firstmatch ** dfs(i+1, j+1,s,p) bắt đầu dòng 280;i = 3 j = 3 -->true
            

             */
            if (j + 1 < p.Length && p[j + 1] == '*')
            {
                // 2 khả năng:
                // 1. Bỏ qua x* (match 0 lần)
                // 2. Match ít nhất 1 ký tự nếu phù hợp
                result = Dfs(i, j + 2, s, p) || (firstMatch && Dfs(i + 1, j, s, p));
            }
            else
            {
                result = firstMatch && Dfs(i + 1, j + 1, s, p);
            }

            memo[(i, j)] = result;
            return result;
        }
    }
}






