using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegularExpressionMatching
{
    public class DeQui
    {
        //🔢 Bài toán: Đếm số cách leo cầu thang
        //Đề bài:
        //Bạn đang ở chân cầu thang có n bậc. Mỗi bước, bạn có thể leo 1 bậc hoặc 2 bậc.
        //Hỏi bạn có bao nhiêu cách để leo đến đỉnh cầu thang?

        //✅ Ví dụ:
        //Với n = 2, có 2 cách:

        //1 + 1 

        //2 
        //=> Kết quả là 2

        //Với n = 3, có 3 cách:

        //1 + 1 + 1

        //1 + 2

        //2 + 1
        //=> Kết quả là 3
        //Với n = 4, có 5 cách:

        //1 + 1 + 1 + 1
        //1 + 1 + 2
        //1 + 2 + 1

        //2 + 1 + 1
        //2+2

        //=> Kết quả là 3
        /*
         -qui luật: tổng của tổng j và j bằng n có nghĩa là 1 cách
        //f(n) = f(n-1) + f(n-2)
        //f(2) = f(1) + f(0) = 2; //f(0) = 1, f(1) = 1
        //f(3) = f(2) + f(1) = 3; 
        //f(4) = f(3) + f(2) = 5;
         -điều kiện dừng:
         */
        public int ClaimStair(int n)
        {
            if (n <= 1) { return 1; }
            return ClaimStair(n - 1) + ClaimStair(n - 2);
        }

        public int TinhGiaiThua(int n)
        {
            if (n == 0)
            {
                return 1;
            }
            return n * TinhGiaiThua(n - 1);
        }



        // Bài toán: Tính tổng các chữ số của một số nguyên dương
        //Đề bài:
        //Cho một số nguyên dương n, hãy dùng đệ quy để tính tổng các chữ số của nó.
        //n = 123 -> 1+2+3 = 6; x= n%10;y=n/10;x(3) + dequi(y=12) = 
        //dequi(y=12) ->x = 2, y = 1; => x(2) + dequi(y=1) 
        //dequi(y=1) -> x = 1, y = 0; => x(1) + dequi(y=0);
        //dequi(y=0) -> x= 0; y = 0; => x(0) + dequi(y=0) = 0;
        //điều kiện dừng y = 0; n = 0;
        public int SumDigits(int n)
        {
            if (n < 10)
                return n;
            return n % 10 + SumDigits(n / 10);

        }
    }
}
