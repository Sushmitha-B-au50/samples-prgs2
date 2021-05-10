using System;
using System.Collections.Generic;

namespace Test3
{
    class Program
    {
        //1) Create a program that will take 10 numbers from user.And print the numbers that are divisible by 7

        static void DivisibleBySeven()
        {
            int[] array = new int[10];
            Console.WriteLine(" Enter the numbers");
            for (int i = 0; i < 10; i++)
            {

                array[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Numbers divisible by 7 are");
            for (int j = 0; j < array.Length; j++)
            {
                if (array[j] % 7 == 0)
                {
                    Console.WriteLine(array[j]);
                }
            }
        }

        //2) Create a program that will take a min and a max value from user and print all the prime numbers between it.
        static void PrimeNumbers()
        {

            Console.Write("Enter The Start Number: ");
            int startNumber = int.Parse(Console.ReadLine());
            Console.Write("Enter the End Number : ");
            int endNumber = Convert.ToInt32(Console.ReadLine());
            if (endNumber > startNumber)
            {
                Console.Write("The prime numbers between {0} and {1} are : \n", startNumber, endNumber);
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

                        Console.Write("{0} \n", i);
                    }
                }

            }
            else
            {
                Console.WriteLine("Invalid entry");
            }


        }
        //3) Create a program that will take numbers from user until the users enters a negative number and print the numbers that are repeating

        static void RepeatingNumbers()
        {
            int i, j, number = 0;
            List<int> result = new List<int>();
            Console.WriteLine("please enter positive numbers");
            while (number >= 0)
            {
                number = Convert.ToInt32(Console.ReadLine());
                result.Add(number);
            }
            Console.WriteLine("Duplicate elements in given array: ");
            for (i = 0; i < result.Count; i++)
            {
                for (j = i + 1; j < result.Count; j++)
                {
                    if (result[i] == result[j])
                        Console.WriteLine(result[i]);
                }
            }
        }

        //4) Create a program that will take positive numbers from user until the user enters 0 and print back the numbers in ascending order


        static void Sorting()
        {
            List<int> Number = new List<int>();
            int input = Convert.ToInt32(Console.ReadLine());
            while (input > 0)
            {

                Number.Add(input);
            }
            Number.Sort();
            foreach (int value in Number)
            {
                Console.Write(value + " ");
            }
        }


        //    5) Create a program that will take login details from user and print welcome if username is “Admin”
        //And password is “admin”(case sensitive). The user can try only 3 times max.If the user login fails the third time the application should state that and end

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

                if (username != "Admin" || password != "admin")
                {
                    loginAttempts++;
                    Console.WriteLine("invalid username or password \nTry again!!");
                }
                else

                    break;
            }

            if (loginAttempts > 2)
                Console.WriteLine("Sorry you have already tried 3 times");
            else
                Console.WriteLine("welcome");
        }

     //6) Play the Cow Bull game using an application
     
        static void CowsAndBulls()
        {
            string[] array = { "kite", "four", "neat", "play", "goal" };

            Console.WriteLine("Play.......");
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine("Enter the guess");
                string GuessWord = Console.ReadLine();
                string guess = array[i];
                int cow = 0, bulls = 0;
                if (guess.Length == GuessWord.Length)
                {

                    for (i = 0; i < guess.Length; i++)
                    {
                        if (guess[i] == GuessWord[i])
                        {
                            cow += 1;
                        }
                        else
                        {
                            for (int j = 0; j < guess.Length; j++)
                            {
                                if (guess[i] == GuessWord[j] && i != j)
                                {
                                    bulls += 1;
                                }
                            }
                        }
                        Console.WriteLine("Cows--" + cow + " Bulls--" + bulls);
                    }

                    if (cow == guess.Length)
                    {
                        Console.WriteLine("Congratulations You Won the Game");
                    }
                    Console.WriteLine("");
                }
                else
                {
                    Console.WriteLine("Must enter " + guess.Length + " letter a Word");
                    Console.WriteLine("");
                }
            }

        }
        //7) Write a program to validate a card
        static void CreditCard()
        {
            long number = 4477468343113002;

            Console.Write(number + " is " +

                         (isValid(number) ?

                         "valid" : "invalid"));
        }
        public static bool isValid(long number)

        {

            return (getSize(number) >= 13 &&

                    getSize(number) <= 16) &&

                    (prefixMatched(number, 4) ||

                    prefixMatched(number, 5) ||

                    prefixMatched(number, 37) ||

                    prefixMatched(number, 6)) &&

                    ((sumOfDoubleEvenPlace(number) +

                    sumOfOddPlace(number)) % 10 == 0);

        }
        public static int sumOfDoubleEvenPlace(long number)

        {

            int sum = 0;

            String num = number + "";

            for (int i = getSize(number) - 2; i >= 0; i -= 2)

                sum += getDigit(int.Parse(num[i] + "") * 2);

            return sum;

        }
        public static int getDigit(int number)

        {

            if (number < 9)

                return number;

            return number / 10 + number % 10;

        }

        public static int sumOfOddPlace(long number)

        {

            int sum = 0;

            String num = number + "";

            for (int i = getSize(number) - 1; i >= 0; i -= 2)

                sum += int.Parse(num[i] + "");

            return sum;

        }

        public static bool prefixMatched(long number, int d)

        {

            return getPrefix(number, getSize(d)) == d;

        }

        public static int getSize(long d)

        {

            String num = d + "";

            return num.Length;

        }
        public static long getPrefix(long number, int k)

        {

            if (getSize(number) > k)

            {

                String num = number + "";

                return long.Parse(num.Substring(0, k));

            }

            return number;

        }
    
   static void PrintMenu()
        {
            int choice = 0;
            do
            {
                Console.WriteLine("1.Divisible by 7");
                Console.WriteLine("2.Print all prime numbers within the range");
                Console.WriteLine("3.Print the repeating numbers");
                Console.WriteLine("4.Sorting numbers");
                Console.WriteLine("5.validation");
                Console.WriteLine("6.Cow and bull Game");
                Console.WriteLine("7.Creditcard validation");
                Console.WriteLine("8.Exit");
                Console.WriteLine("Pick your choice");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        DivisibleBySeven();
                        break;
                    case 2:
                        PrimeNumbers();
                        break;
                    case 3:
                        RepeatingNumbers();
                        break;
                    case 4:
                        Sorting();
                        break;
                    case 5:
                        ValidationUsername();
                        break;
                    case 6:
                        CowsAndBulls();
                        break;
                    case 7:
                        CreditCard();
                        break;
                    case 8:
                        Console.WriteLine("Exiting");
                        break;
                    default:
                        Console.WriteLine("Invalid entry");
                        break;
                }
            } while (choice != 8);
        }
        static void Main(string[] args)
        {
            PrintMenu();
        }
    }
}
