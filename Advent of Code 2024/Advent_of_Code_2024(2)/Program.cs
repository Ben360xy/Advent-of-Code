namespace Advent_of_Code_2024
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Define the file path for input data
            string filePath = "C:\\Users\\benrv\\OneDrive\\Documents\\Github\\Advent of Code\\Advent of Code 2024\\Advent_of_Code_2024(2)\\Data\\input.txt";

            try
            {
                // Read all lines from the input file
                string[] lines = File.ReadAllLines(filePath);

                // Parse the input into a 2D array of integers
                int[][] input = lines
                    .Select(row => row
                        .Split(' ') // Split each line by spaces
                        .Select(int.Parse) // Convert each element to int
                        .ToArray())
                    .ToArray();

                int output = 0;

                // Loop through each row in the input
                for (int i = 0; i < input.Length; i++)
                {
                    // Print the current row for debugging
                    Console.WriteLine($"Row {i}: {string.Join(" ", input[i])}");

                    // Skip rows with fewer than 2 elements
                    if (input[i].Length < 2) continue;

                    // Check if the row should be decreased or increased
                    if (input[i][0] > input[i][input[i].Length - 1])
                    {
                        output += decrease(input[i]);
                    }
                    else if (input[i][0] < input[i][input[i].Length - 1])
                    {
                        output += increase(input[i]);
                    }
                }
                Console.WriteLine(output); // Print the final result
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
            }
        }

        // Check if the row can be safely decreased
        public static int decrease(int[] num)
        {
            for (int i = 0; i < num.Length - 1; i++)
            {
                int dif = num[i] - num[i + 1];

                // If the difference is outside the valid range, perform a safety check
                if (dif < 1 || dif > 3)
                {
                    if (safetyCheckD(num) == 0)
                    {
                        return 0;
                    }
                }
            }
            return 1;
        }

        // Check if the row can be safely increased
        public static int increase(int[] num)
        {
            for (int i = 0; i < num.Length - 1; i++)
            {
                int dif = num[i + 1] - num[i];

                // If the difference is outside the valid range, perform a safety check
                if (dif < 1 || dif > 3)
                {
                    if (safetyCheckI(num) == 0)
                    {
                        return 0;
                    }
                }
            }
            return 1;
        }

        // Perform a safety check for decreasing rows
        public static int safetyCheckD(int[] num)
        {
            if (endCheck(num) == 1) return 1;
            for (int i = 0; i < num.Length; i++)
            {
                int[] newNum = num.Where((_, idx) => idx != i).ToArray();
                if (endCheck(newNum) == 1) return 1;
            }
            return 0;
        }

        // Perform a safety check for increasing rows
        public static int safetyCheckI(int[] num)
        {
            if (endCheck(num) == 1) return 1;
            for (int i = 0; i < num.Length; i++)
            {
                int[] newNum = num.Where((_, idx) => idx != i).ToArray();
                if (endCheck(newNum) == 1) return 1;
            }
            return 0;
        }

        // Check the endpoints of the row for correctness
        public static int endCheck(int[] num)
        {
            for (int i = 0; i < num.Length - 1; i++)
            {
                int dif = Math.Abs(num[i] - num[i + 1]);
                if (dif < 1 || dif > 3)
                {
                    return 0;
                }
            }
            return 1;
        }
    }
}
