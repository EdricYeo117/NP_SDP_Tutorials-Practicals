using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Customer : IObserver
    {
        public string customerName { get; private set; }


        // Constructor
        public Customer(string name)
        {
            customerName = name;
        }

        // Update method to receive notification from the subject
        public void Update(string shopName, Product product, bool addOrRemove)
        {
            if (addOrRemove)
            {
                Console.WriteLine($"Hey {customerName}, {shopName} has added a new product: \n- {product.Name}!");
            }
            else
            {
                Console.WriteLine($"Hey {customerName}, {shopName} is no longer selling the product: \n- {product.Name}!");
            }
        }
    }
}
