using ConvertCurrencyClient;
using Grpc.Net.Client;

class Program
{
    static async Task Main(string[] args)
    {
        do
        {
            Console.WriteLine("\n******** Welcome to currency converter ********\n");
            Console.WriteLine("This program converts a currency (dollars) from numbers into words.");
            Console.WriteLine("The maximum number is 999 999 999.");
            Console.WriteLine("The maximum number of cents is 99.");
            Console.WriteLine("The separator between dollars and cents is ‘,’ (comma).");
            Console.WriteLine("Please type an amount and press enter");


            string input = Console.ReadLine();
            try
            {
                using var channel = GrpcChannel.ForAddress("https://localhost:7263");
                var client = new Converter.ConverterClient(channel);
                var reply = await client.ConvertCurrencyAsync(new ConverterRequest { CurrencyInNumber = input });

                if (reply.Status.Status == "success")
                {
                    Console.WriteLine($"\nResult is {reply.CurrencyInWords}\n\n");
                }
                else
                {

                    Console.WriteLine("\n" + reply.Status.Status);
                    Console.WriteLine(reply.Status.Message + "\n\n");
                }
            } catch(Exception ex)
            {
                Console.WriteLine($"Failed to convert {ex.Message}\n\n");
            }
            Console.WriteLine("Press 'x' to exist, or Press any other key to Re-do\n\n\n");


        } while (Console.ReadKey(true).Key != ConsoleKey.X);
       
    }
}