namespace Advent_of_Code_2024;

public class Program
{
    public static void Main(string[] args)
    {
        string filePath =
            "C:\\Users\\benrv\\source\\repos\\Advent of Code 2024\\Advent_of_Code_2024(2)\\Data\\input.txt";

        string[] lines = File.ReadAllLines(filePath);



        int[][] input = lines
            .Select(row => row
                .Split(' ')              
                .Select(int.Parse)      
                .ToArray())             
            .ToArray();

        int output = 0;

        for (int i = 0; i < input.Length; i++)
        {
            if (input[i][0] > input[i][1])
            {
                output += decrease(input[i]);
            }
            else if (input[i][0] < input[i][1])
            {
                output += increase(input[i]);
            }
        }
        Console.WriteLine(output);
    }

    public static int decrease(int[] num)
    {
        for (int i = 0; i < num.Length - 1; i++)
        {
            int dif = num[i] - num[i + 1];
            if (dif < 1 || dif > 3)
            {
                if (safetyCheckD(num) == 0);
                {
                    return 0;
                }
                
            }
        }
        return 1;
    }
    public static int increase(int[] num)
    {
        for (int i = 0; i < num.Length - 1; i++)
        {
            int dif = num[i + 1] - num[i];
            if (dif < 1 || dif > 3)
            {
                if (safetyCheckI(num) == 0) ;
                {
                    return 0;
                }
            }
        }
        return 1;
    }

    public static int safetyCheckD(int[] num)
    {

    }
    public static int safetyCheckI(int[] num)
    {

    }
}