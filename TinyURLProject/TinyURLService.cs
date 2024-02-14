using System;
using System.Collections.Generic;
using System.Linq;

namespace TinyURLProject
{
    public class ShortUrl
    {
        public string ShortId { get; set; }
        public string LongUrl { get; set; }
        public int ClickCounter { get; set; }
    }

    public class TinyURLService
    {
        private readonly List<ShortUrl> list = new List<ShortUrl>();
        public TinyURLService()
        {
        }

        // set longUrl as null only for testing purposes
        public ShortUrl GetNewShortUrl(string longUrl = null)
        {
            try
            {
                if (longUrl == null)
                {
                    Console.Write("Please enter the long URL: ");
                    longUrl = Console.ReadLine();
                }

                Console.WriteLine(@"
                    Enter a custom short URL?:

                    1 - YES
                    2 - NO
                    ");

                var selectedChoice = Console.ReadLine();

                string newShortId = string.Empty;

                switch (selectedChoice)
                {
                    case "1":
                        Console.Write("Please enter your custom short id: ");
                        newShortId = Console.ReadLine();
                        break;
                    case "2":
                        newShortId = GenerateNewShortId();
                        break;
                    default:
                        Console.WriteLine("Incorect choice. Please select from 1 to 5.");
                        break;
                }

                ShortUrl newShortUrl = new ShortUrl()
                {
                    ShortId = newShortId,
                    LongUrl = longUrl,
                    ClickCounter = 0
                };

                Console.WriteLine($"Your new short url: tinyurl.com/{newShortUrl.ShortId}");

                list.Add(newShortUrl);

                return newShortUrl;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error has occurred while creating new short url: {ex.Message}");
            }
        }

        public ShortUrl RemoveShortUrl(string shortId = null)
        {
            try
            {
                if (shortId == null)
                {
                    Console.Write("Please enter the short URL Id to remove: ");
                    shortId = Console.ReadLine();
                }
                
                var shortUrl = list.FirstOrDefault(s => s.ShortId == shortId);
                if (shortUrl == null)
                {
                    Console.WriteLine("Short Id was not found.");
                }
                else
                {
                    list.Remove(shortUrl);
                }

                return shortUrl;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error has occurred while removing short url: {ex.Message}");
            }
        }

        public string GetLongUrlByShortId(string shortId = null)
        {
            try
            {
                if (shortId == null)
                {
                    Console.Write("Please enter the short URL Id: ");
                    shortId = Console.ReadLine();
                }

                ShortUrl shortUrl = list.FirstOrDefault(s => s.ShortId == shortId);

                if (shortUrl == null)
                {
                    Console.WriteLine("Short URL was not found.");
                }
                else
                {
                    Console.WriteLine($"Original long URL: {shortUrl.LongUrl}");
                    shortUrl.ClickCounter++;
                }
                return shortUrl != null ? shortUrl.LongUrl : string.Empty;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error has occurred while getting long url: {ex.Message}");
            }
        }

        public int GetClickCountByShortId(string shortId = null)
        {
            try
            {
                if (shortId == null)
                {
                    Console.Write("Enter the short URL Id: ");
                    shortId = Console.ReadLine();
                }
                ShortUrl shortUrl = list.FirstOrDefault(s => s.ShortId == shortId);

                if (shortUrl == null)
                {
                    Console.WriteLine("Short URL not found.");
                }
                else
                {
                    Console.WriteLine($"{shortId} was clicked {shortUrl.ClickCounter} times");
                }

                return shortUrl != null ? shortUrl.ClickCounter : -1;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error has occurred while getting click count: {ex.Message}");
            }
        }

        public void PrintAllAvailableShortIds()
        {
            if (list.Count > 0)
            {
                foreach (var item in list)
                {
                    Console.WriteLine($"ShortId: {item.ShortId}, long URL: {item.LongUrl}");
                }
            }
            else
            {
                Console.WriteLine("There are no available items!");
            }
        }

        private string GenerateNewShortId()
        {
            return Guid.NewGuid().ToString("N").Substring(0, 6);
        }
    }
}
