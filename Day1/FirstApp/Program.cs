
using System.ComponentModel.Design;
using System.Diagnostics.CodeAnalysis;

namespace FirstApp
{
    internal class Program
    {
        static void Main()//Method header
        {
            int j = 10;
           for(int i=1;i<=j;i++)
            {
                Console.WriteLine("Enter num{i}:");
                int num = Convert.ToInt32(Console.ReadLine());
                int sum = +num;
            }
            int average = sum / j;
            Console.WriteLine($"the average of the 10 numbers is {average}");
        }
    }
}