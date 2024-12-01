using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Shop : ISubject
    {
        public string shopName { get; private set; }
        public List<Product> productList { get; private set; }
        private List<IObserver> customers;

        public Shop(string shopname)
        {
            shopName = shopname;
            productList = new List<Product>();
            customers = new List<IObserver>();
        }

        // Property to set and get the current price of the stock
        public void addProduct(Product product)
        {
            productList.Add(product);
            NotifyObservers(product,true);
        }

        public void removeProduct(Product product)
        {
            if (productList.Contains(product))
            {
                productList.Remove(product);
                NotifyObservers(product,false);
            }
            else
            {
                Console.WriteLine($"{product.Name} is not a product");
            }
        }

        public void RegisterObserver(IObserver observer)
        {
            customers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            customers.Remove(observer);
        }

        public void NotifyObservers(Product product, bool addOrRemove)
        {
            foreach (var customer in customers)
            {
                customer.Update(shopName, product, addOrRemove);
            }
        }
    }
}
