namespace Advent_of_Code_2024;

public class Program
{
    public static void Main(string[] args)
    {
        string filePath = "C:\\Users\\benrv\\source\\repos\\Advent of Code 2024\\Advent of Code 2024\\Data\\input.txt";

        string[] lines = File.ReadAllLines(filePath);

        int[] column1 = new int[lines.Length];
        int[] column2 = new int[lines.Length];

        for (int i = 0; i < lines.Length; i++)
        {
            string[] numbers = lines[i].Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            if (numbers.Length == 2)
            {
                column1[i] = int.Parse(numbers[0]);
                column2[i] = int.Parse(numbers[1]);
            }
        }

        Array.Sort(column1);
        Array.Sort(column2);

        int total = 0;

        for (int i = 0; i < lines.Length; i++)
        {
            total += Math.Abs(column1[i] - column2[i]);
        }
        Console.WriteLine("part 1: " + total);

        int total2 = 0;
        for (int i = 0; i < lines.Length; i++)
        {
            int apperences = 0;
            for (int j = 0; j < column1.Length; j++)
            {
                if (column1[i] == column2[j])
                {
                    apperences++;
                }
            }
            total2 += column1[i] * apperences;
        }

        Console.WriteLine("part 2; " + total2);
    }
}