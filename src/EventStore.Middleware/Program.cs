﻿using System;
using System.Net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace EventStore.Middleware
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Event store setting up for Event Sourcing");

            try
            {
                var config = new ConfigurationBuilder()
                    .AddCommandLine(args)
                    .AddEnvironmentVariables()
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .Build();

                var builder = new WebHostBuilder()
                    .UseConfiguration(config)
                    .UseStartup<Startup>()
                    .UseKestrel(options =>
                    {
                        options.Listen(IPAddress.Any, 80); // docker outer port
                    });

                var host = builder.Build();
                host.Run();

            }
            catch (Exception ex)
            {

            }
            finally
            {
                Console.WriteLine("Event store is UP now!!");
            }
        }
    }
}