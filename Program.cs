/*
 * Project: Lambdas
 * Filename: Program.cs
 * Author: R. Snell
 * Date: Dec. 23, 2020
 * Purpose: To demonstrate the syntax and use of lambdas expressions
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambdas
{
    class Program
    {
        // Public delegate type that takes 2 int types and returns an int.
        public delegate int Calculate(int x, int y);
        // Defining a method to which the delegate can point
        public static int Rect(int x, int y)
        {
            return x * y;
        }   // End Rect()
        static void Main(string[] args)
        {
            // Example 1
            // Lambda expression used to invoke a method that requires a delegate
            // as an argument.
            List<int> list = new List<int> { 8, 5, 1, 0, 2, 10, 6, 23, 18, 4 };
            List<int> evenNums = list.FindAll(i => i % 2 == 0);    // Lambda expression
            Console.WriteLine("List of even numbers: ");
            foreach (int evenNum in evenNums)
                Console.Write("{0}", evenNum);
            Console.WriteLine();

            // Creating and initializing an instance of the delegate, and then
            // calling it
            Calculate r1 = new Calculate(Rect);
            Console.WriteLine("\nArea of a rectangle is " + r1(3, 4));

            // Example 3
            // Use of an anonymous method taking 2 arguments and 
            // returning their product
            Calculate r2 = new Calculate(
                delegate (int x, int y)
                {
                    return 2 * (x * y);
                });
            Console.WriteLine("\nPerimeter of the rectangle is " + r2(6, 9));

            // Example 4
            // Data types of x and y and the return type inferred from the type of 
            // the delegate to which the lambda is assigned.
            // The lambda makes it compact.
            Calculate r3 = (x, y) => 2 * (x * y);
            Console.WriteLine("\nTwice the area of a rectangle = " + r3(5, 8));

            // Example 5
            // Can specify the argument in a lambda
            Calculate r4 = (int x, int y) => 3 * (x * y);
            Console.WriteLine("\nThree times area of a rectangle = " + r4(5, 9));
        }   // end Main()
    }   // end class
}   // end namespace
