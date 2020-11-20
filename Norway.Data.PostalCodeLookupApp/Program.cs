using System;
using Microsoft.Extensions.Configuration;

namespace Norway.Data.PostalCodeLookupApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            IPostalInfoLookup lookupService = new PafPostalInfoLookup(config["PafFile"]);

            while (true)
            {
                Console.Write("postal code (or \"exit\")> ");
                var input = Console.ReadLine();

                if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                var pafEntry = lookupService.Lookup(input);
                if (pafEntry != null)
                {
                    Console.WriteLine($"{pafEntry.PostalNumber} {pafEntry.PostalTown}");
                    Console.WriteLine(pafEntry.KommuneName);
                    Console.WriteLine();
                    Console.WriteLine(pafEntry);
                }
            }
        }
    }
}
