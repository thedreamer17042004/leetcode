
using medianOfTwoSortedArray;

int[] numba = { 1, 3 };
int[] numb = { 2};

Solution solution = new Solution();
double median = solution.FindMedianOfTwoSortedArray(numba, numb);
double median1 = solution.FindMedianOfTwoSortedArrayQuickSort(numba, numb);

Console.WriteLine($"Median of two sorted arrays is: {median} - {median1}");