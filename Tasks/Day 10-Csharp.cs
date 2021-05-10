using System;

namespace secondproject
{
    class Program
    {
        //1) write a method that will check if a given number is even or not
        static void EvenorNot()
        {
            int number;
            Console.Write("Enter a Number : ");
            number = int.Parse(Console.ReadLine());
            if (number % 2 == 0)
            {
                Console.Write("Entered Number is an Even Number");
                Console.Read();
            }
            else
            {
                Console.Write("Entered Number is an Odd Number");
                Console.Read();
            }
        }

      // 2) Take numbers from user until the user enters a negative number
      //Print the sum of the numbers that are divisible by 7
        static void SumOFNumber()
        {
        
                int  number = 0, sum = 0;
        
                 Console.Write("Enter a Number : ");
                 number = int.Parse(Console.ReadLine());
                 while (number >= 0)
                { 
                Console.Write("Enter a Number : ");
                number = int.Parse(Console.ReadLine());
          
                if (number % 7 == 0)
                {
                    
                    sum += number;
                 }
               }
               Console.Write("The sum  of numbers divisible by 7 are : " +sum);


        }

        //3) Take a minimum and a maximum number from user and print all the prime numebrs in the range
        static void PrimeNumbers()
        {

            Console.Write("Enter The Start Number: ");
            int startNumber = int.Parse(Console.ReadLine());
            Console.Write("Enter the End Number : ");
            int endNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("The Prime Numbers between start and end numbers are");

            for (int i = startNumber; i <= endNumber; i++)
            {
                int counter = 0;

                for (int j = 2; j <= i / 2; j++)
                {
                    if (i % j == 0)
                    {
                        counter++;
                        break;
                    }
                }

                if (counter == 0 && i != 1)
                {
                    Console.Write("{0} ", i);
                }
            }


        }


        //  4) Take teh username and password from user and check if it is 
        //"Ramu" and "1234"

        //If yes print welcome else ask the user to try again
        //If teh user enters the wrong values for 3 times inform the user that teh account is locked
        //for and break
        static void ValidationUsername()
        {
            int loginAttempts = 0;
            //Simple iteration upto three times
            for (int i = 0; i < 3; i++)
            {

                Console.WriteLine("Enter username");
                string username = Console.ReadLine();
                Console.WriteLine("Enter password");
                string password = Console.ReadLine();

                if (username != "ramu" || password != "1234")
                {

                    loginAttempts++;
                }
                else

                    break;
            }

            if (loginAttempts > 2)
                Console.WriteLine("account blocked");
            else
                Console.WriteLine("welcome");
        }

         // 5) Create a program that will take 2 numbers and then ask the user for teh operation 
          //+ or - or* or /
           //Based on tehuser input perform teh operation and print the result

        static void ArithmeticOperations()
        {
            Console.WriteLine("Please enter an first integer");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter second integer ");
            int num2 = Convert.ToInt32(Console.ReadLine()); //explicit conversion
            Console.WriteLine("enter a operation +,-,*,/");
            string operation = Console.ReadLine();
            switch (operation)
            {
                case "+":
                    int sum = num1 + num2;
                    Console.WriteLine("sum of nos is " + sum);
                    break;
                case "-":
                    int sub = num1 + num2;
                    Console.WriteLine("subtraction of nos is " + sub);
                    break;
                case "*":
                    int mult = num1 * num2;
                    Console.WriteLine("multiplication of nos is " + mult);
                    break;
                case "/":
                    float div = num1 / num2;
                    Console.WriteLine("division of nos is " + div);
                    break;
                default:
                    Console.WriteLine("choose a valid operations");
                    break;

            }

        }


        static void Main(string[] args)
        {

            //EvenorNot()
            //ArithmeticOperations();
            // ValidationUsername();
            // PrimeNumbers();
             SumOFNumber();
        }

    }
}

