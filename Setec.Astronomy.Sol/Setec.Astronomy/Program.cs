using System;
using System.Collections.Generic;

namespace Setec.Astronomy
{
    class Program
    {
        /// <summary>
        /// Entry point of command-line application.
        /// </summary>
        /// <param name="args">Command-line argument values.</param>
        static void Main(string[] args)
        {
            string strValueToProcess = string.Empty;
            int intValueToProcess = 0;

            Console.WriteLine("Processing Start.");

            try
            {
                strValueToProcess = ReadArguments(args);
                intValueToProcess = ConvertToInteger(strValueToProcess);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to collect integer for processing from execution arguments.");
                Console.WriteLine("Information: " + ex.Message);
                Console.WriteLine("Processing Completed.");
                Console.WriteLine("Press the 'Enter' key to shut down.");
                Console.ReadLine();
                return;
            }

            try
            {
                List<int> validPrimeNumbers = CollectPrimeValues(intValueToProcess);
                ProcessSecret(validPrimeNumbers);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in collecting or processing prime values.");
                Console.WriteLine("Information: " + ex.Message);
                Console.WriteLine("Processing Completed.");
                Console.WriteLine("Press the 'Enter' key to shut down.");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Processing Completed.");
            Console.WriteLine("Press the 'Enter' key to shut down.");
            Console.ReadLine();
        }

        /// <summary>
        /// Read the command-line arguments passed into the application.
        /// The only value collected is the [0] index all values after will be
        /// ignored.
        /// </summary>
        /// <param name="args">Command-line argument values.</param>
        /// <returns></returns>
        private static string ReadArguments(string[] args)
        {
            if (args == null)
            {
                Console.WriteLine("No command-line arguments provided.");
                throw new Exception("No command-line arguments provided.");
            }
            else
            {
                string argument = args[0];
                Console.WriteLine("Command-line argument for processing provided: " + argument);
                return argument;
            }
        }

        /// <summary>
        /// Detemine if command-line value is a valid integer.
        /// </summary>
        /// <param name="strValueToProcess">value to be checked if valid integer.</param>
        /// <returns></returns>
        private static int ConvertToInteger(string strValueToProcess)
        {
            int number = 0;
            try
            {
                number = Int32.Parse(strValueToProcess);

                return number;
            }
            catch (Exception ex)
            {
                throw new Exception("Invalid integer provided for processing: " + strValueToProcess + " Exception: " + ex.Message);
            }

        }

        /// <summary>
        /// Collect all the prime values less pass integer
        /// </summary>
        /// <param name="intValueToProcess">Detemrine all prime value that are less than passed value.</param>
        /// <returns></returns>
        private static List<int> CollectPrimeValues(int intValueToProcess)
        {
            List<int> validPrimeNumbers = new List<int>();

            Console.WriteLine("Prime values less than " + intValueToProcess + " to be identified.")
                ;
            for (int i = 0; i < intValueToProcess; i++)
            {
                if (isNumberPrime(i))
                {
                    validPrimeNumbers.Add(i);
                    Console.WriteLine("Prime value " + i + " identified.");
                }
            }

            return validPrimeNumbers;
        }

        /// <summary>
        /// Check value to detemine if number is prime or not.
        /// </summary>
        /// <param name="number">value be checked.</param>
        /// <returns></returns>
        private static bool isNumberPrime(int number)
        {
            int i;
            for (i = 2; i <= number - 1; i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }
            if (i == number)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Method that embodies the call to the Secert function.
        /// </summary>
        /// <param name="validPrimeNumbers">All prime numbers less than the number passed via the command-line argument.</param>
        private static void ProcessSecret(List<int> validPrimeNumbers)
        {
            int intX = 0;
            int intY = 0;
            int intXY = 0;

            Console.WriteLine("Begin processing prime numbers to function Secret()");

            foreach (int primeNumber in validPrimeNumbers)
            {
                // Preform test of all combination of current primeNumber value and all avaliable valid prime numbers found in the list.
                for (int i = 0; i < validPrimeNumbers.Count; i++)
                {
                    intX = primeNumber;
                    intY = validPrimeNumbers[i];
                    intXY = intX + intY;

                    if(Secret(intXY) == Secret(intX) + Secret(intY))
                    {
                        TrueSecret();
                    }
                    else
                    {
                        FalseSecret();
                    }
                }
            }

            Console.WriteLine("End processing prime numbers to function Secret()");
        }

        /// <summary>
        /// Stub function for Secret.
        /// Insert Secret function once provided.
        /// </summary>
        /// <param name="value">Designated prime number or sum value used for the Secret calculation.</param>
        /// <returns>Calculated response from Secret.</returns>
        private static int Secret(int value) { return value; }

        /// <summary>
        /// Stub for function when the ProcessSecret function calling the Secret
        /// check returns true.
        /// </summary>
        private static void TrueSecret()  {}

        /// <summary>
        /// Stub for function when the ProcessSecret function calling the Secret
        /// check returns false.
        /// </summary>
        private static void FalseSecret() {}
    }
}
