using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingServer
{
    internal class Order
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public string UserName { get; set; }

        public Order(string productName, int quantity, string userName)

        {
            ProductName = productName;
            Quantity = quantity;
            UserName = userName;
        }

        public override string ToString()

        {
            return $"{ProductName}, {Quantity}, {UserName}";
        }
    }
}
