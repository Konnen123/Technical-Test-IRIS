namespace Problem2;

class Program
{
    static void Main(string[] args)
    {
        Program program = new Program();
        int[] nums1 = { 2, 2, 1 }; 
        int[] nums2 = { 4, 1, 2, 1, 2 }; 
        int[] nums3 = { 1 }; 
        Console.WriteLine(program.findUniqueNumber(nums1));
        Console.WriteLine(program.findUniqueNumber(nums2));
        Console.WriteLine(program.findUniqueNumber(nums3));
    }
    // Approach 1: Brute Force
    // For each element, traverse the array and check if it has a duplicate
    // Time complexity: O(n^2), where n is the length of the nums array
    // Space complexity: O(1)
    
    // Approach 2: Using a dictionary
    // Store each element as a key, and it's frequency as values
    // At the end, check which element from the dictionary has the frequency of 1
    // Time complexity: O(n), where n is the length of the nums array
    // Space complexity: O(n), we need to store each value from array in the dictionary
    
    // Approach 3: Using XOR operator (Optimal Approach)
    // Knowing that in the array there will be numbers that appear twice, and one number that appears once
    // We can use XOR operator to check the number that is unique
    // The XOR operator will remove any duplicates (x^x=0), and we will get the unique number
    // Time complexity: O(n), where n is the length of the nums array
    // Space complexity: O(1)
    
    private int findUniqueNumber(int[] nums)
    {
        // Get the first number from the array
        int uniqueNumber = nums[0];
        for (int i = 1; i < nums.Length; i++)
        {
            // Use the XOR operator on each number
            uniqueNumber ^= nums[i];
        }
        // The remaining number is the unique one
        return uniqueNumber;
    }
}