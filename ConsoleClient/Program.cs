﻿using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsoleClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var client = new swaggerClient("https://localhost:44380", new HttpClient());
            var data = await client.CourseAllAsync();
            foreach (var item in data)
            {
                Console.WriteLine(item.Title);
            }            

        }
    }
}
