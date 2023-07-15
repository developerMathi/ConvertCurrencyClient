using ConvertCurrencyClient;
using Grpc.Net.Client;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Welcome to currency converter");
        Console.ReadLine();
        using var channel = GrpcChannel.ForAddress("https://localhost:7263");
        var client= new Greeter.GreeterClient(channel);
        var reply = await client.SayHelloAsync(new HelloRequest { Name = "CConverter" });
        Console.WriteLine($"Greetings{reply.Message}");
        Console.ReadLine(); 
    }
}