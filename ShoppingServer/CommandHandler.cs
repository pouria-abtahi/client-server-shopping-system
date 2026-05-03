using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingServer
{
    internal class CommandHandler
    {
        private List<Product> products;
        private List<Account> accounts;
        private List<Order> orders;
        private Dictionary<Socket, Account> activeClients;

        public CommandHandler(List<Product> products, List<Account> accounts, List<Order> orders)
        {
            this.products = products;
            this.accounts = accounts;
            this.orders = orders;
            activeClients = new Dictionary<Socket, Account>();
        }

        public string HandleCommand(string command, Socket clientSocket)
        {
            if (command == "DISCONNECT")
            {
                activeClients.Remove(clientSocket);
                return null; 
            }

            if (command.StartsWith("CONNECT:"))
            {
                var accountNo = int.Parse(command.Substring(8));
                var account = accounts.FirstOrDefault(a => a.AccountNumber == accountNo);
                if (account != null)
                {
                    activeClients[clientSocket] = account;
                    return $"CONNECTED:{account.UserName}";
                }
                return "CONNECT_ERROR";
            }

            if (command == "GET_PRODUCTS")
            {
                return "PRODUCTS:" + string.Join("|", products.Select(p => $"{p.Name},{p.Quantity}"));
            }

            if (command == "GET_ORDERS")
            {
                return "ORDERS:" + string.Join("|", orders.Select(o => $"{o.ProductName},{o.Quantity},{o.UserName}"));
            }

            if (command.StartsWith("PURCHASE:"))
            {
                var productName = command.Substring(9);
                var product = products.FirstOrDefault(p => p.Name == productName);
                if (product == null) return "NOT_VALID";
                if (product.Quantity == 0) return "NOT_AVAILABLE";

                product.Quantity--;  // Decrease the product quantity
                var userName = activeClients[clientSocket].UserName;
                orders.Add(new Order(productName, 1, userName));
                return "DONE";
            }

            if (command == "GET_USER_ORDERS")
            {
                // Get the current user's name from the activeClients dictionary
                if (!activeClients.ContainsKey(clientSocket))
                {
                    return "USER_NOT_CONNECTED";
                }

                var currentUser = activeClients[clientSocket].UserName;

                // Filter orders for the current user
                var userOrders = orders
                    .Where(order => order.UserName == currentUser)
                    .Select(order => $"{order.ProductName},{order.Quantity},{order.UserName}");

                // Return the filtered orders in the same format as GET_ORDERS
                return "ORDERS:" + string.Join("|", userOrders);
            }

            return "INVALID_COMMAND";
        }
    }
}
