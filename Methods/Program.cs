using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    class Program
    {
        static void Main(string[] args)
        {
            UseParams();
            UsePoints();
            TryParse();
        }

        static void TryParse()
        {
            int number;
            var result = int.TryParse("abc", out number);// out operator provides value to number if conversion is possible, result is bool type. TryParse doesn't throw exception.
            if (result)
                Console.WriteLine(number);
            else
                Console.WriteLine("conversion failed");
        }
        static void UseParams()
        {
            var calculator = new Calculator();
            Console.WriteLine(calculator.Add(1, 2));
            Console.WriteLine(calculator.Add(1, 2, 3, 4));
        }
        static void UsePoints()
        {
            try
            {
                var point = new Point(10, 20);
                point.Move(new Point(40, 60)); //overloading
                Console.WriteLine("point is at {0}, {1}", point.X, point.Y);
                var anotherPoint = new Point(5, 10);
                point.Move(anotherPoint);
                Console.WriteLine("point is at {0}, {1}", point.X, point.Y);

                point.Move(null); //will throw exception.
                Console.WriteLine("point is at ({0}, {1})", point.X, point.Y);
            }
            catch (Exception)
            {
                Console.WriteLine("An unexpected error occured.");
            }
        }
    }

    public class Calculator
    {
        public int Add(params int[] numbers)// will look like calculator.Add(1,2) instead of calculator.Add (new int [] {1,2} ) when used params keyword.
        {
            var sum = 0;
            foreach (var number in numbers)
            {
                sum += number;
            }
            return sum;
        }
    }

    public class Point
    {
        public int X;
        public int Y;

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public void Move(int x, int y) // overloading
        {
            this.X = x;
            this.Y = y;
        }

        public void Move(Point newLocation)
        {
            if (newLocation == null) //exception handling in case of newLocation is null.
                throw new ArgumentNullException("newLocation");

            Move(newLocation.X, newLocation.Y);
        }
    }
}

       
