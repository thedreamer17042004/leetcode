
using addtwosum;

Solution solution = new Solution();
int[] nums = {3,3};
int target = 6;
int[] result = solution.TwoSum(nums, target);
int[] result1 = solution.TwoSum2(nums, target);
int[] result2 = solution.TwoSum3(nums, target);

Console.WriteLine($"way 1 - nested 2 for: {result[0]}, {result[1]}"); 
Console.WriteLine($"way 2 - dictionary where for: {result1[0]}, {result1[1]}"); 
Console.WriteLine($"way 3 - dictionary contain keys for: {result2[0]}, {result2[1]}"); 