using System;
using System.Collections.Generic;
using System.Text;

namespace Computational_Problem_Solving
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            int numberOfUniqueNumbers = RemoveDuplicates(nums1);
            Console.WriteLine(numberOfUniqueNumbers);

            //Question 2:
            Console.WriteLine("Question 2:");
            int[] nums2 = { 0, 1, 0, 3, 12 };
            IList<int> resultAfterMovingZero = MoveZeroes(nums2);
            string combinationsString = ConvertIListToArray(resultAfterMovingZero);
            Console.WriteLine(combinationsString);

            //Question 3:
            Console.WriteLine("Question 3:");
            int[] nums3 = { -1, 0, 1, 2, -1, -4 };
            IList<IList<int>> triplets = ThreeSum(nums3);
            string tripletResult = ConvertIListToNestedList(triplets);
            Console.WriteLine(tripletResult);

            //Question 4:
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 1, 0, 1, 1, 1 };
            int maxOnes = FindMaxConsecutiveOnes(nums4);
            Console.WriteLine(maxOnes);

            //Question 5:
            Console.WriteLine("Question 5:");
            int binaryInput = 101010;
            int decimalResult = BinaryToDecimal(binaryInput);
            Console.WriteLine(decimalResult);

            //Question 6:
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 6, 9, 1 };
            int maxGap = MaximumGap(nums5);
            Console.WriteLine(maxGap);

            //Question 7:
            Console.WriteLine("Question 7:");
            int[] nums6 = { 2, 1, 2 };
            int largestPerimeterResult = LargestPerimeter(nums6);
            Console.WriteLine(largestPerimeterResult);

            //Question 8:
            Console.WriteLine("Question 8:");
            string result = RemoveOccurrences("daabcbaabcbc", "abc");
            Console.WriteLine(result);
        }

        /*
        
        Question 1:
        Given an integer array nums sorted in non-decreasing order, remove the duplicates in-place such that each unique element appears only once. The relative order of the elements should be kept the same. Then return the number of unique elements in nums.

        Consider the number of unique elements of nums to be k, to get accepted, you need to do the following things:

        Change the array nums such that the first k elements of nums contain the unique elements in the order they were present in nums initially. The remaining elements of nums are not important as well as the size of nums.
        Return k.

        Example 1:

        Input: nums = [1,1,2]
        Output: 2, nums = [1,2,_]
        Explanation: Your function should return k = 2, with the first two elements of nums being 1 and 2 respectively.
        It does not matter what you leave beyond the returned k (hence they are underscores).
        Example 2:

        Input: nums = [0,0,1,1,1,2,2,3,3,4]
        Output: 5, nums = [0,1,2,3,4,_,_,_,_,_]
        Explanation: Your function should return k = 5, with the first five elements of nums being 0, 1, 2, 3, and 4 respectively.
        It does not matter what you leave beyond the returned k (hence they are underscores).
 

        Constraints:

        1 <= nums.length <= 3 * 104
        -100 <= nums[i] <= 100
        nums is sorted in non-decreasing order.
        */


        public static int RemoveDuplicates(int[] nums)
        {
            try
            {
                // Check if the array is empty
                if (nums.Length == 0)
                    return 0;

                // Initialize a variable to count the unique elements
                int uniqueCount = 1;
                // Iterate through the array starting from the second element
                for (int i = 1; i < nums.Length; i++)
                {
                    // Check if the current element is different from the previous one
                    if (nums[i] != nums[i - 1])
                    {
                        // If different, update the next unique position in the array with the current element & Increment the count of unique elements
                        nums[uniqueCount] = nums[i];
                        uniqueCount++;
                    }
                }
                // Return the count of unique elements
                return uniqueCount;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
        
        Question 2:
        Given an integer array nums, move all 0's to the end of it while maintaining the relative order of the non-zero elements.

        Note that you must do this in-place without making a copy of the array.

        Example 1:

        Input: nums = [0,1,0,3,12]
        Output: [1,3,12,0,0]
        Example 2:

        Input: nums = [0]
        Output: [0]
 
        Constraints:

        1 <= nums.length <= 104
        -231 <= nums[i] <= 231 - 1
        */


        public static IList<int> MoveZeroes(int[] nums)
        {
            try
            {
                int nonZeroIndex = 0; // Index to track non-zero elements
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] != 0)
                    {
                        // Swap non-zero element with element at nonZeroIndex
                        int temp = nums[i];
                        nums[i] = nums[nonZeroIndex];
                        nums[nonZeroIndex] = temp;
                        nonZeroIndex++; // Move nonZeroIndex forward
                    }
                }
                return nums; // Return modified array
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question 3:
        Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.

        Notice that the solution set must not contain duplicate triplets.

 

        Example 1:

        Input: nums = [-1,0,1,2,-1,-4]
        Output: [[-1,-1,2],[-1,0,1]]
        Explanation: 
        nums[0] + nums[1] + nums[2] = (-1) + 0 + 1 = 0.
        nums[1] + nums[2] + nums[4] = 0 + 1 + (-1) = 0.
        nums[0] + nums[3] + nums[4] = (-1) + 2 + (-1) = 0.
        The distinct triplets are [-1,0,1] and [-1,-1,2].
        Notice that the order of the output and the order of the triplets does not matter.
        Example 2:

        Input: nums = [0,1,1]
        Output: []
        Explanation: The only possible triplet does not sum up to 0.
        Example 3:

        Input: nums = [0,0,0]
        Output: [[0,0,0]]
 

        Constraints:

        0 <= nums.length <= 3000
        -105 <= nums[i] <= 105
        */


        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            try
            {
                Array.Sort(nums); // Sorting the array
                IList<IList<int>> result = new List<IList<int>>(); // Initialize result list
                int n = nums.Length; // Get the length of the array
                for (int i = 0; i < n - 2; i++) // Iterate through the array
                {
                    if (i > 0 && nums[i] == nums[i - 1]) // Skip duplicates
                        continue;

                    int left = i + 1, right = n - 1; // Initialize left and right pointers
                    while (left < right) // Loop until left pointer crosses right pointer
                    {
                        int sum = nums[i] + nums[left] + nums[right]; // Calculate the sum of current triplet
                        if (sum == 0) // If sum is zero, add the triplet to result list
                        {
                            result.Add(new List<int> { nums[i], nums[left], nums[right] });
                            // Skip duplicates while moving pointers
                            while (left < right && nums[left] == nums[left + 1]) left++;
                            while (left < right && nums[right] == nums[right - 1]) right--;
                            left++; // Move left pointer forward
                            right--; // Move right pointer backward
                        }
                        else if (sum < 0) // If sum is less than zero, move left pointer forward
                            left++;
                        else // If sum is greater than zero, move right pointer backward
                            right--;
                    }
                }
                return result; // Return the list of unique triplets
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
        
        Question 4:
        Given a binary array nums, return the maximum number of consecutive 1's in the array.

        Example 1:

        Input: nums = [1,1,0,1,1,1]
        Output: 3
        Explanation: The first two digits or the last three digits are consecutive 1s. The maximum number of consecutive 1s is 3.
        Example 2:

        Input: nums = [1,0,1,1,0,1]
        Output: 2
 

        Constraints:

        1 <= nums.length <= 105
        nums[i] is either 0 or 1.
        */

        public static int FindMaxConsecutiveOnes(int[] nums)
        {
            try
            {
                int maxCount = 0; // Initialize max count of consecutive ones
                int currentCount = 0; // Initialize current count of consecutive ones
                foreach (int num in nums) // Iterate through the array
                {
                    if (num == 1) // If current element is 1
                    {
                        currentCount++; // Increment current count
                        maxCount = Math.Max(maxCount, currentCount); // Update max count
                    }
                    else // If current element is not 1
                    {
                        currentCount = 0; // Reset current count
                    }
                }
                return maxCount; // Return the max count of consecutive ones
            }
            catch (Exception)
            {
                throw;
            }
        }


        /*

        Question 5:
        Given a binary number as an integer N, convert it into decimal and return.

        Example 1:

        Input: N = 101010
        Output: 42
        Explanation: 101010 in binary corresponds to 42 in decimal.
        Example 2:

        Input: N = 10010010101111001010101010111101
        Output: 252731425
 

        Constraints:

        1 <= N <= 10^9
        */

        public static int BinaryToDecimal(int N)
        {
            try
            {
                int decimalNumber = 0; // Initialize decimal equivalent
                int baseValue = 1; // Initialize base value for binary conversion

                while (N > 0) // Loop until binary number is converted
                {
                    int lastDigit = N % 10; // Extract the last digit of the binary number
                    N = N / 10; // Remove the last digit from the binary number

                    decimalNumber += lastDigit * baseValue; // Multiply last digit by base value and add to decimal number

                    baseValue = baseValue * 2; // Update base value for next digit
                }

                return decimalNumber; // Return the decimal number
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question 6:
        Given an unsorted integer array nums, return the maximum difference between the successive elements in its sorted form. If the array contains less than two elements, return 0.

        You must write an algorithm that runs in linear time and uses linear extra space.

 

        Example 1:

        Input: nums = [3,6,9,1]
        Output: 3
        Explanation: The sorted form of the array is [1,3,6,9], either (3,6) or (6,9) has the maximum difference 3.
        Example 2:

        Input: nums = [10]
        Output: 0
        Explanation: The array contains less than 2 elements, therefore return 0.
 

        Constraints:

        1 <= nums.length <= 104
        0 <= nums[i] <= 109
        */

        public static int MaximumGap(int[] nums)
        {
            try
            {
                if (nums.Length < 2) // If array has less than 2 elements
                    return 0; // Maximum gap is 0

                Array.Sort(nums); // Sort the array
                int maxDiff = 0; // Initialize maximum difference

                for (int i = 0; i < nums.Length - 1; i++) // Iterate through the sorted array
                {
                    maxDiff = Math.Max(maxDiff, nums[i + 1] - nums[i]); // Update maximum difference
                }

                return maxDiff; // Return the maximum difference
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question 7:
        Given an integer array nums, return the largest perimeter of a triangle with a non-zero area, formed from three of these lengths. If it is impossible to form any triangle of a non-zero area, return 0.

 

        Example 1:

        Input: nums = [2,1,2]
        Output: 5
        Example 2:

        Input: nums = [1,2,1]
        Output: 0
        Example 3:

        Input: nums = [3,2,3,4]
        Output: 10
        Example 4:

        Input: nums = [3,6,2,3]
        Output: 8
 

        Constraints:

        3 <= nums.length <= 104
        1 <= nums[i] <= 106
        */

        public static int LargestPerimeter(int[] nums)
        {
            try
            {
                Array.Sort(nums); // Sort the array of side lengths
                for (int i = nums.Length - 1; i >= 2; i--) // Start from the largest side
                {
                    if (nums[i - 2] + nums[i - 1] > nums[i]) // Check if it forms a valid triangle
                    {
                        return nums[i - 2] + nums[i - 1] + nums[i]; // Return the perimeter
                    }
                }
                return 0; // Return 0 if no valid triangle found
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question 8:
        Given two strings s and part, perform the following operation on s until all occurrences of the substring part are removed:

        Find the leftmost occurrence of the substring part and remove it from s.
        Return s after removing all occurrences of part.

        A substring is a contiguous sequence of characters in a string.

 

        Example 1:

        Input: s = "daabcbaabcbc", part = "abc"
        Output: "dab"
        Explanation: 
        The following operations are done:
        - s = "daabcbaabcbc", remove "abc" starting at index 2, so s = "dabaabcbc".
        - s = "dabaabcbc", remove "abc" starting at index 4, so s = "dababc".
        - s = "dababc", remove "abc" starting at index 3, so s = "dab".
        There are no more occurrences of "abc" in s.
        Example 2:

        Input: s = "axxxxyyyyb", part = "xy"
        Output: "ab"
        Explanation: 
        The following operations are done:
        - s = "axxxxyyyyb", remove "xy" starting at index 4 so s = "axxxyyyb".
        - s = "axxxyyyb", remove "xy" starting at index 3 so s = "axxyyb".
        - s = "axxyyb", remove "xy" starting at index 2 so s = "axyb".
        - s = "axyb", remove "xy" starting at index 1 so s = "ab".
        There are no more occurrences of "xy" in s.
 

        Constraints:

        1 <= s.length <= 105
        1 <= part.length <= 105
        s and part consists of lowercase English letters.
        */

        public static string RemoveOccurrences(string s, string part)
        {
            try
            {
                
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Convert IList<int> to string
        public static string ConvertIListToArray(IList<int> list)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            foreach (var item in list)
            {
                sb.Append(item).Append(",");
            }
            sb.Remove(sb.Length - 1, 1); // Remove the trailing comma
            sb.Append("]");
            return sb.ToString();
        }

        // Convert IList<IList<int>> to string
        public static string ConvertIListToNestedList(IList<IList<int>> list)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            foreach (var innerList in list)
            {
                sb.Append("[");
                foreach (var item in innerList)
                {
                    sb.Append(item).Append(",");
                }
                sb.Remove(sb.Length - 1, 1); // Remove the trailing comma
                sb.Append("],");
            }
            sb.Remove(sb.Length - 1, 1); // Remove the trailing comma
            sb.Append("]");
            return sb.ToString();
        }
    }
}