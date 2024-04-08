/* 
 
YOU ARE NOT ALLOWED TO MODIFY ANY FUNCTION DEFINIDTION's PROVIDED.
WRITE YOUR CODE IN THE RESPECTIVE QUESTION FUNCTION BLOCK


*/

using System.Text;

namespace ISM6225_Spring_2024_Assignment_2
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
            int[] nums5 = { 3,6,9,1 };
            int maxGap = MaximumGap(nums5);
            Console.WriteLine(maxGap);

            //Question 7:
            Console.WriteLine("Question 7:");
            int[] nums6 = { 2,1,2 };
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
                // If the array is empty, return 0 as there are no unique elements
                if (nums.Length == 0)
                {
                    Console.WriteLine("The array is empty.");
                    return 0;
                }

                // Initialize uniqueIndex at 1 since the first element is always unique
                int k = 1;

                // Iterate through the array starting from the second element
                for (int i = 1; i < nums.Length; i++)
                {
                    // If the current element is not equal to the previous one, it's unique
                    if (nums[i] != nums[i - 1])
                    {
                        // Move k to the next position in the k portion of the array
                        nums[k] = nums[i];
                        k++;
                    }
                }

                // Print the modified array with unique elements
                Console.Write("The modified array is: ");
                for (int i = 0; i < k; i++)
                {
                    Console.Write(nums[i] + " ");
                }
                Console.WriteLine();
                return k;
            }
            catch (Exception ex)
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
                // Initialize nonZero to keep track of the position to place the next non-zero element
                int nonZero = 0;

                // Iterate through the array
                for (int i = 0; i < nums.Length; i++)
                {
                    // If the current element is not zero, move it to the position indicated by nonZero
                    if (nums[i] != 0)
                    {
                        nums[nonZero] = nums[i];
                        nonZero++;
                    }
                }

                // After all non-zero elements have been moved to the beginning,
                // fill the remainder of the array with zeroes
                for (int i = nonZero; i < nums.Length; i++)
                {
                    nums[i] = 0;
                }

                // Return the modified array with zeroes moved to the end
                return nums;
            }
            catch (Exception ex)
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
        Explanation: The only possible triplet sums up to 0.
 

        Constraints:

        3 <= nums.length <= 3000
        -105 <= nums[i] <= 105

        */

        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            try
            {
                // Sort the array to facilitate finding triplets and skipping duplicates.
                Array.Sort(nums);
                List<IList<int>> result = new List<IList<int>>();

                // Iterate over each number in the array.
                for (int i = 0; i < nums.Length; i++)
                {
                    // Skip duplicate elements to avoid duplicate triplets.
                    if (i > 0 && nums[i] == nums[i - 1])
                        continue;

                    // Initialize two pointers for the current element.
                    int start = i + 1, end = nums.Length - 1;
                    while (start < end)
                    {
                        // Calculate the sum of the current triplet.
                        int sum = nums[i] + nums[start] + nums[end];

                        // If the sum is less than zero, increase the sum by moving the left pointer to the right.
                        if (sum < 0)
                        {
                            start++;
                        }
                        // If the sum is more than zero, decrease the sum by moving the right pointer to the left.
                        else if (sum > 0)
                        {
                            end--;
                        }
                        else
                        {
                            // A valid triplet that sums up to zero has been found.
                            result.Add(new List<int> { nums[i], nums[start], nums[end] });

                            // Skip all duplicate values for the left pointer.
                            while (start < end && nums[start] == nums[start + 1]) start++;
                            // Skip all duplicate values for the right pointer.
                            while (start < end && nums[end] == nums[end - 1]) end--;

                            // Prepare for the next iteration to find new triplets.
                            start++;
                            end--;
                        }
                    }
                }

                // Return the list of found triplets.
                return result;

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
                // Initialize variables to track the maximum consecutive ones found and the current streak of ones.
                // Tracks the current streak of consecutive ones.
                int maxConsecutiveOnes = 0;
                // Stores the maximum streak found so far.
                int currentStreak = 0;

                // Iterate over each element in the array.
                for (int i = 0; i < nums.Length; i++)
                {
                    // If the current element is 1, increment the streak counter.
                    if (nums[i] == 1)
                    {
                        // Increment the current streak.
                        maxConsecutiveOnes++;
                        // Update currentMax if the current streak is the new maximum.
                        if (maxConsecutiveOnes > currentStreak)
                        {
                            currentStreak = maxConsecutiveOnes;
                        }
                    }
                    else
                    {
                        // If the current element is not 1, reset the streak counter.
                        maxConsecutiveOnes = 0;
                    }
                }
                // Return the maximum streak of consecutive ones found in the array.
                return currentStreak;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /*

        Question 5:
        You are tasked with writing a program that converts a binary number to its equivalent decimal representation without using bitwise operators or the `Math.Pow` function. You will implement a function called `BinaryToDecimal` which takes an integer representing a binary number as input and returns its decimal equivalent. 

        Requirements:
        1. Your program should prompt the user to input a binary number as an integer. 
        2. Implement the `BinaryToDecimal` function, which takes the binary number as input and returns its decimal equivalent. 
        3. Avoid using bitwise operators (`<<`, `>>`, `&`, `|`, `^`) and the `Math.Pow` function for any calculations. 
        4. Use only basic arithmetic operations such as addition, subtraction, multiplication, and division. 
        5. Ensure the program displays the input binary number and its corresponding decimal value.

        Example 1:
        Input: num = 101010
        Output: 42


        Constraints:

        1 <= num <= 10^9

        */
        public static int BinaryToDecimal(int binary)
        {
            try
            {
                // Initialize variable to store the decimal value
                int decimalValue = 0;

                // Initialize variable to track the current power of two
                int powerOfTwo = 1; 
                while (binary > 0)
                {
                    // Extract the rightmost digit of the binary number
                    int lastDigit = binary % 10;

                    // Multiply the digit by the current power of two and add to the decimal value
                    decimalValue += lastDigit * powerOfTwo;

                    // Move to the next digit of the binary number
                    binary /= 10;

                    // Increment the power of two for the next iteration
                    powerOfTwo *= 2; 
                }

                // Return the decimal representation of the binary number
                return decimalValue; 
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question:6
        Given an integer array nums, return the maximum difference between two successive elements in its sorted form. If the array contains less than two elements, return 0.
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

        1 <= nums.length <= 105
        0 <= nums[i] <= 109

        */

        public static int MaximumGap(int[] nums)
        {
            try
            {

                if (nums.Length < 2)
                    return 0;


                Array.Sort(nums);


                int maxGap = 0;


                for (int i = 1; i < nums.Length; i++)
                {

                    int gap = nums[i] - nums[i - 1];


                    maxGap = Math.Max(maxGap, gap);
                }

                return maxGap;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question:7
        Given an integer array nums, return the largest perimeter of a triangle with a non-zero area, formed from three of these lengths. If it is impossible to form any triangle of a non-zero area, return 0.

        Example 1:

        Input: nums = [2,1,2]
        Output: 5
        Explanation: You can form a triangle with three side lengths: 1, 2, and 2.
        Example 2:

        Input: nums = [1,2,1,10]
        Output: 0
        Explanation: 
        You cannot use the side lengths 1, 1, and 2 to form a triangle.
        You cannot use the side lengths 1, 1, and 10 to form a triangle.
        You cannot use the side lengths 1, 2, and 10 to form a triangle.
        As we cannot use any three side lengths to form a triangle of non-zero area, we return 0.

        Constraints:

        3 <= nums.length <= 104
        1 <= nums[i] <= 106

        */
        public static int LargestPerimeter(int[] nums)
        {
            try
            {
                // Sort the array in non-decreasing order.
                Array.Sort(nums);

                // Iterate from the end of the array towards the beginning.
                for (int i = nums.Length - 1; i >= 2; i--)
                {
                    // Check if the current three consecutive elements can form a valid triangle.
                    if (nums[i - 2] + nums[i - 1] > nums[i])
                    {
                        // If yes, return the perimeter of the triangle.
                        return nums[i - 2] + nums[i - 1] + nums[i];
                    }
                }

                // If no valid triangle can be formed, return 0.
                return 0;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    /*

    Question:8

    Given two strings s and part, perform the following operation on s until all occurrences of the substring part are removed:

    Find the leftmost occurrence of the substring part and remove it from s.
    Return s after removing all occurrences of part.

    A substring is a contiguous sequence of characters in a string.



    Example 1:

    Input: s = "daabcbaabcbc", part = "abc"
    Output: "dab"
    Explanation: The following operations are done:
    - s = "daabcbaabcbc", remove "abc" starting at index 2, so s = "dabaabcbc".
    - s = "dabaabcbc", remove "abc" starting at index 4, so s = "dababc".
    - s = "dababc", remove "abc" starting at index 3, so s = "dab".
    Now s has no occurrences of "abc".
    Example 2:

    Input: s = "axxxxyyyyb", part = "xy"
    Output: "ab"
    Explanation: The following operations are done:
    - s = "axxxxyyyyb", remove "xy" starting at index 4 so s = "axxxyyyb".
    - s = "axxxyyyb", remove "xy" starting at index 3 so s = "axxyyb".
    - s = "axxyyb", remove "xy" starting at index 2 so s = "axyb".
    - s = "axyb", remove "xy" starting at index 1 so s = "ab".
    Now s has no occurrences of "xy".

    Constraints:

    1 <= s.length <= 1000
    1 <= part.length <= 1000
    s​​​​​​ and part consists of lowercase English letters.

    */
    public static string RemoveOccurrences(string s, string part)
        {
            try
            {
                // Convert the input string to a StringBuilder for efficient manipulation.
                StringBuilder sb = new StringBuilder(s);

                int partLength = part.Length;
                bool found;

                do
                {
                    found = false; // Reset flag for each pass.

                    // Iterate over the string while it's long enough for 'part' to exist.
                    for (int i = 0; i <= sb.Length - partLength; i++)
                    {
                        bool match = true; // Assume a match until proven otherwise.

                        // Check if the current segment matches 'part'.
                        for (int j = 0; j < partLength; j++)
                        {
                            if (sb[i + j] != part[j])
                            {
                                match = false; // Mismatch found, not a complete match.
                                break; // Exit the inner loop early.
                            }
                        }

                        if (match)
                        {
                            // Remove the found occurrence from the StringBuilder.
                            sb.Remove(i, partLength);

                            found = true; // Mark that we've made a removal in this pass.
                            break; // Break to restart the search, as the string length has changed.
                        }
                    }
                } while (found); // Repeat if an occurrence was removed.

                // Return the modified string without 'part'.
                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /* Inbuilt Functions - Don't Change the below functions */
        static string ConvertIListToNestedList(IList<IList<int>> input)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("["); // Add the opening square bracket for the outer list

            for (int i = 0; i < input.Count; i++)
            {
                IList<int> innerList = input[i];
                sb.Append("[" + string.Join(",", innerList) + "]");

                // Add a comma unless it's the last inner list
                if (i < input.Count - 1)
                {
                    sb.Append(",");
                }
            }

            sb.Append("]"); // Add the closing square bracket for the outer list

            return sb.ToString();
        }
        static string ConvertIListToArray(IList<int> input)
        {
            // Create an array to hold the strings in input
            string[] strArray = new string[input.Count];

            for (int i = 0; i < input.Count; i++)
            {
                strArray[i] = "" + input[i] + ""; // Enclose each string in double quotes
            }

            // Join the strings in strArray with commas and enclose them in square brackets
            string result = "[" + string.Join(",", strArray) + "]";

            return result;
        }
    }
}