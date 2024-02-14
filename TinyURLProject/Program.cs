using System;
using System.Threading;

namespace TinyURLProject
{
    class Program
    {
        private static readonly TinyURLService service = new TinyURLService();

        static void Main(string[] args)
        {
            try
            {
                while (true)
                {
                    Console.WriteLine(@"
                    Please enter your choice:

                    1 - Generate Short URL
                    2 - Remove Short URL
                    3 - Get original Long URL
                    4 - Get Click Count
                    5 - Print all available Short URLs
                    6 - Exit
                    ");
                    var selectedChoice = Console.ReadLine();

                    switch (selectedChoice)
                    {
                        case "1":
                            service.GetNewShortUrl();
                            break;
                        case "2":
                            service.RemoveShortUrl();
                            break;
                        case "3":
                            service.GetLongUrlByShortId();
                            break;
                        case "4":
                            service.GetClickCountByShortId();
                            break;
                        case "5":
                            service.PrintAllAvailableShortIds();
                            break;
                        case "6":
                            string goodByMessage = "See you soon!)";
                            for (int i = 0; i < goodByMessage.Length; i++)
                            {
                                Console.Write(goodByMessage[i]);
                                Thread.Sleep(40);
                            }
                            Thread.Sleep(1000);
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Incorect choice. Please select from 1 to 5.");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong, " + ex.Message);
            }
        }
    }
}
