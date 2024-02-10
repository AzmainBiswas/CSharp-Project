using System.Xml;

namespace CoolHelloWorld
{
    class Program
    {
        static void Main()
        {
            var helloWorld = new char[] { 'H', 'e', 'l', 'l', 'o', ' ', 'W', 'o', 'r', 'l', 'd', '!' };
            var printHello = new char[12];
            int i = (int)'A';
            int j = (int)'a';
            int k = (int)'a';
            int l = (int)'a';
            int m = (int)'a';
            int n = (int)'W';
            int o = (int)'a';
            int p = (int)'a';
            int q = (int)'a';
            int r = (int)'a';
            int sleep = 50;

            while ((char)r <= helloWorld[10])
            {
                while ((char)q <= helloWorld[9])
                {
                    while ((char)p <= helloWorld[8])
                    {
                        while ((char)o <= helloWorld[7])
                        {
                            while ((char)n <= helloWorld[6])
                            {
                                while ((char)m <= helloWorld[4])
                                {
                                    while ((char)l<=helloWorld[3])
                                    {
                                        while ((char)k<= helloWorld[2])
                                        {
                                            while ((char)j <= helloWorld[1])
                                            {
                                                while ((char)i <= helloWorld[0])
                                                {
                                                    printHello[0] = (char)i;
                                                    Console.WriteLine(printHello);
                                                    i++;
                                                    Thread.Sleep(sleep);
                                                }
                                                printHello[1] = (char)j;
                                                Console.WriteLine(printHello);
                                                j++;
                                                Thread.Sleep(sleep);
                                            }
                                            printHello[2] = (char)k;
                                            Console.WriteLine(printHello);
                                            k++;
                                            Thread.Sleep(sleep);
                                        }
                                        printHello[3] = (char)l;
                                        Console.WriteLine(printHello);
                                        l++;
                                        Thread.Sleep(sleep);
                                    }
                                    printHello[4] = (char)m;
                                    Console.WriteLine(printHello);
                                    m++;
                                    Thread.Sleep(sleep);
                                }
                                printHello[5] = ' ';
                                printHello[6] = (char)n;
                                Console.WriteLine(printHello);
                                n++;
                                Thread.Sleep(sleep);
                            }
                            printHello[7] = (char)o;
                            Console.WriteLine(printHello);
                            o++;
                            Thread.Sleep(sleep);
                        }
                        printHello[8] = (char)p;
                        Console.WriteLine(printHello);
                        p++;
                        Thread.Sleep(sleep);
                    }
                    printHello[9] = (char)q;
                    Console.WriteLine(printHello);
                    q++;
                    Thread.Sleep(sleep);
                }
                printHello[10] = (char)r;
                Console.WriteLine(printHello);
                r++;
                Thread.Sleep(sleep);
            }
            Thread.Sleep(sleep);
            printHello[11] = '!';
            Console.WriteLine(printHello);
        }
    }
}
