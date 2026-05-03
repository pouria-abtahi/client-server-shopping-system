using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();

            // Initialize products, accounts, and orders
            var products = new List<Product>
            {
                new Product("Apple", random.Next(1, 4)),
                new Product("Banana", random.Next(1, 4)),
                new Product("Orange", random.Next(1, 4)),
                new Product("Grapes", random.Next(1, 4)),
                new Product("Peach", random.Next(1, 4))
            };

            var accounts = new List<Account>
            {
                new Account(1001, "Pouria"),
                new Account(1002, "Sushen"),
                new Account(1003, "Peter"),
                new Account(1004, "Seneca"),
            };

            var orders = new List<Order>();

            // Start the server
            Console.WriteLine("Starting server...");
            var server = new TcpListener(IPAddress.Any, 5000);
            server.Start();
            Console.WriteLine("Server started on port 5000.");

            while (true)
            {
                var clientSocket = server.AcceptSocket();
                Console.WriteLine("Client connected.");
                Task.Run(() => HandleClient(clientSocket, products, accounts, orders));
            }
        }

        static void HandleClient(Socket clientSocket, List<Product> products, List<Account> accounts, List<Order> orders)
        {
            var handler = new CommandHandler(products, accounts, orders);
            var stream = new NetworkStream(clientSocket);
            var reader = new StreamReader(stream);
            var writer = new StreamWriter(stream) { AutoFlush = true };

            try
            {
                while (true)
                {
                    var command = reader.ReadLine();
                    if (command == null) break;

                    Console.WriteLine($"Received: {command}");
                    var response = handler.HandleCommand(command, clientSocket);

                    if (response != null)
                    {
                        Console.WriteLine($"Response: {response}");
                        writer.WriteLine(response);
                    }
                }
            }

            catch (Exception ex)

            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            finally
            {
                Console.WriteLine("Client disconnected.");
                clientSocket.Close();
            }
        }
    }
}
