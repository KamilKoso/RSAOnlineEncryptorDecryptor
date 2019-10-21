using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using Domain.Abstract;
using System.Threading;

namespace Domain.Entities
{
   public class RSAAlgorithm:IRsaAlgorithm
    {
        public int p { get; set; }
        public int q { get; set; }
        public int z { get; set; }
        public int e { get; set; }
        public int d { get; set; }
        public int n { get; set; }
        public int randomPrimeMaxValue { get; set; } = 100;

        public RSAAlgorithm()
        {
            setValues();
        }



        public void setValues()
        {
            p = GeneratePrime();
            Thread.Sleep(1000); //W przeciwnym wypadku wygeneruje 2 te same liczby pierwsze dla p i Q
            q = GeneratePrime();
            z = calculateZ();
            e = calculateE();
            d = calculateD();
            n = calculateN();

        }


        int GeneratePrime()
        {
            Random random = new Random();
            while (true)
            {
                int randomNum = 0;
                randomNum = random.Next(randomPrimeMaxValue);
                if (randomNum % 2 == 0)
                    randomNum = randomNum / 2;
                if (isPrime(randomNum))
                {
                    return randomNum;
                    break;
                }
            }
        }

       public int calculateN() { return p * q; }

       public int calculateE()
        {
            int[] primes = GeneratePrimes(z).ToArray();


            for (int i = primes.Length; i >= 2; i--)
                if (BiggestCommonDivider(i, z) == 1)    //Jezeli wspolnym dzielnikiem I z Z jest 1 to znaczy ze I jest wzglednie pierwsze z Z
                    return i;
            return -1; //Nie ma takich liczb
        }

       public int calculateZ()
        {
            return ((p - 1) * (q - 1));
        }

       public int calculateD()
        {
            for (int i = 1; i < Int32.MaxValue; i++)
            {

                if (i * e % z == 1 && i != e)
                    return i;
            }
            return -1; //Nie ma takiej liczby
        }



        List<int> GeneratePrimes(int limit)
        {
            List<int> primes = new List<int>();
            primes.Add(2);
            primes.Add(3);

            if (limit % 2 == 0)
                limit++;

            for (int i = 5; i <= limit; i += 2)
                if (isPrime(i))
                    primes.Add(i);

            return primes;
        }

        static int BiggestCommonDivider(int a, int b)   //Algorytm Euklidesa do znajdowania największego wspólnego dzielnika
        {
            int c;
            while (b != 0)
            {
                c = a % b;
                a = b;
                b = c;
            }
            return a;
        }

        public static bool isPrime(int check)
        {
            if (check <= 1) return false;
            if (check == 2) return true;
            if (check % 2 == 0) return false;

            /* Sprawdzamy tylko liczby z przedziału <check, pierwiastekZCheck> dlatego
             że pierwiastek z check jest medianą liczb które dzielą liczbę check
             więc jeżeli istnieją trzy liczby dzielące check wystarczy sprawdzić tylko lewą stronę przediału
            Przykład
            check = 24
            sqrt(check) = ~4.9
            Dzielniki 24 to {1,2,3,4, |4.9| , 6,8,12,24}
            Można zauważyć że dzielników po lewej stronie przedziału i prawej stronie przedziału względem pierwiastka z check jest tyle samo.
             */

            int boundary = (int)Math.Floor(Math.Sqrt(check));

            for (int i = 3; i <= boundary; i += 2) //i+=2 ponieważ nie ma sensu sprawdzania liczb parzystych, ponieważ te zawsze będą dzielić się przez 2
                if (check % i == 0) return false;

            return true;
        }

        public List<BigInteger> EncodeMessage(string message, int n, int e)
        {
            List<BigInteger> codedLetters = new List<BigInteger>();
            for (int i = 0; i < message.Length; i++)
            {
                int letterinASCII = message[i];
                codedLetters.Add(BigInteger.Pow(letterinASCII, e) % n);
            }
            return codedLetters;
        }

        public string DecodeMessage(List<BigInteger> codedList, int n, int d)
        {
            string message = "";
            foreach (var i in codedList)
            {

                char decodedChar = (char)(BigInteger.Pow(i, d) % n);
                message += decodedChar.ToString();
            }
            return message;
        }
    }
}
