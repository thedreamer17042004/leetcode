// See https://aka.ms/new-console-template for more information
using RegularExpressionMatching;


Solution solution = new Solution();

//string s = "aa";string p = "a";
//string s = "aa"; string p = ".a";
//string s = "abc"; string p = "a*b*d";
string s = "a"; string p = ".*..a*";
//những index nào + lên ta lưu lại 
bool result = solution.IsMatch(s, p);

Console.WriteLine($"IsMatch('{s}', '{p}') = {result}");

DeQui dq = new DeQui();
int n = 1001;

int dem = dq.SumDigits(n);
Console.WriteLine($"Tổng các chữ số của {n} là: {dem}");
