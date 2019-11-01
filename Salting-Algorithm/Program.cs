using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FibinachiEncrypt
{
    class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                Console.WriteLine("Enter Your Message: ");
                string message = Console.ReadLine();
                string encryptMsg = message.Replace("66", ";").Replace(",", "65").Replace(".", "64").Replace("Z", "63").Replace("Y", "62").Replace("X", "61").Replace("W", "60").Replace("V", "59").Replace("U", "58").Replace("T", "57").Replace("S", "56").Replace("R", "55").Replace("Q", "54").Replace("P", "53").Replace("O", "52").Replace("N", "51").Replace("M", "50").Replace("L", "49").Replace("K", "48").Replace("J", "47").Replace("I", "46").Replace("H", "45").Replace("G", "44").Replace("F", "43").Replace("E", "42").Replace("D", "41").Replace("C", "40").Replace("B", "39").Replace("A", "38").Replace(" ", "37").Replace("a", "11").Replace("b", "12").Replace("c", "13").Replace("d", "14").Replace("e", "15").Replace("f", "16").Replace("g", "17").Replace("h", "18").Replace("i", "19").Replace("j", "20").Replace("k", "21").Replace("l", "22").Replace("m", "23").Replace("n", "24").Replace("o", "25").Replace("p", "26").Replace("q", "27").Replace("r", "28").Replace("s", "29").Replace("t", "30").Replace("u", "31").Replace("v", "32").Replace("w", "33").Replace("x", "34").Replace("y", "35").Replace("z", "36");
                string newVar = Encrypt(encryptMsg);
                Console.WriteLine("Starting Message Number: " + encryptMsg);
                Console.WriteLine("Encrypt: " + newVar);
                Console.WriteLine("Decrypt: " + Decrypt(newVar));
                Console.ReadKey();
            }

        }

        public static string Encrypt(string message)
        {
            try
            {
                Random rand = new Random();

                BigInteger msgNumber = System.Numerics.BigInteger.Parse(message);
                int random = rand.Next(10000, 99999);
                Console.WriteLine("Random Number: " + random);
                BigInteger fibinachi = Fibonacci(random);
                Console.WriteLine("Fibinacci: " + fibinachi);
                //for(int x = 0; x<=random; x++)
                //{
                msgNumber = msgNumber * (fibinachi ^ random);
                //}
                string message2 = random + msgNumber.ToString();
                //int msg2Number = int.Parse(message2);
                return message2;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                return "Failed. " + ex.Message;
            }
        }


        public static BigInteger Fibonacci(int len)
        {
            BigInteger a = 0, b = 1, c = 0;

            for (int i = 2; i < len; i++)
            {
                c = a + b;
                a = b;
                b = c;
            }

            return c;
        }

        public static string Decrypt(string message)
        {
            int rand = int.Parse(message.Substring(0, 5));
            Console.WriteLine("Original Rand: " + rand);
            BigInteger fibbinacci = Fibonacci(rand);
            Console.WriteLine("Original Fibb.: " + fibbinacci);
            message = message.Substring(5);
            BigInteger msgNumber = BigInteger.Parse(message);
            string stringMsg = "";

            //for (int x = 0; x < rand; x++)
            //{
            msgNumber = (msgNumber / (fibbinacci ^ rand));
            //}

            Console.WriteLine("Original MsgNumber: " + msgNumber.ToString());


            int length = msgNumber.ToString().Length;
            length = length / 2;
            Console.WriteLine("Length: " + length);

            for (int i = 0; i < length /*|| i != length-1*/; i++)
            {
                Console.WriteLine("i=" + i);

                if (i == length || i > length)
                {
                    break;
                }

                if (i != length || i < length)
                {
                    string messageSplit = Split(msgNumber.ToString(), 2).ElementAt(i);
                    //Console.WriteLine(msgNumber.ToString().Substring(i, i + 2));
                    //Console.WriteLine(message.Replace("66", ";").Replace(",", "65").Replace(".", "64").Replace("Z", "63").Replace("Y", "62").Replace("X", "61").Replace("W", "60").Replace("V", "59").Replace("U", "58").Replace("T", "57").Replace("S", "56").Replace("R", "55").Replace("Q", "54").Replace("P", "53").Replace("O", "52").Replace("N", "51").Replace("M", "50").Replace("L", "49").Replace("K", "48").Replace("J", "47").Replace("I", "46").Replace("H", "45").Replace("G", "44").Replace("F", "43").Replace("E", "42").Replace("D", "41").Replace("C", "40").Replace("B", "39").Replace("A", "38").Replace(" ", "37").Replace("a", "11").Replace("b", "12").Replace("c", "13").Replace("d", "14").Replace("e", "15").Replace("f", "16").Replace("g", "17").Replace("h", "18").Replace("i", "19").Replace("j", "20").Replace("k", "21").Replace("l", "22").Replace("m", "23").Replace("n", "24").Replace("o", "25").Replace("p", "26").Replace("q", "27").Replace("r", "28").Replace("s", "29").Replace("t", "30").Replace("u", "31").Replace("v", "32").Replace("w", "33").Replace("x", "34").Replace("y", "35").Replace("z", "36"));
                    stringMsg = stringMsg + messageSplit.Replace("66", ";").Replace("65", ",").Replace("64", ".").Replace("63", "Z").Replace("62", "Y").Replace("61", "X").Replace("60", "W").Replace("59", "V").Replace("58", "U").Replace("57", "T").Replace("56", "S").Replace("55", "R").Replace("54", "Q").Replace("53", "P").Replace("52", "O").Replace("51", "N").Replace("50", "M").Replace("49", "L").Replace("48", "K").Replace("47", "J").Replace("46", "I").Replace("45", "H").Replace("44", "G").Replace("43", "F").Replace("42", "E").Replace("41", "D").Replace("40", "C").Replace("39", "B").Replace("38", "A").Replace("37", " ").Replace("11", "a").Replace("12", "b").Replace("13", "c").Replace("14", "d").Replace("15", "e").Replace("16", "f").Replace("17", "g").Replace("18", "h").Replace("19", "i").Replace("20", "j").Replace("21", "k").Replace("22", "l").Replace("23", "m").Replace("24", "n").Replace("25", "o").Replace("26", "p").Replace("27", "q").Replace("28", "r").Replace("29", "s").Replace("30", "t").Replace("31", "u").Replace("32", "v").Replace("33", "w").Replace("34", "x").Replace("35", "y").Replace("36", "z");
                }
            }

            return stringMsg;
        }

        static IEnumerable<string> Split(string str, int chunkSize)
        {
            return Enumerable.Range(0, str.Length / chunkSize).Select(i => str.Substring(i * chunkSize, chunkSize));
        }
    }
}