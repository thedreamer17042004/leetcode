

using longestSubstringwithoutRepeatingCharacters;

string s = "abcabcbb";
int maxLength = 0;
Solution st = new Solution();
maxLength = st.LengthOfLongestSubstringMyCodeV1(s);
Console.WriteLine("The length of the longest substring without repeating characters is: " + maxLength);