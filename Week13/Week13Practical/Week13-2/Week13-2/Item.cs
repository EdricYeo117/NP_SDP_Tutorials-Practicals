using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week13_2
{

    // Item class
    public class Item
    {
        private string name;
        private double price;
        private int quantity;
        // constructor, getters and setters
        // Constructor
        public Item(string name, double price, int quantity)
        {
            this.name = name;
            this.price = price;
            this.quantity = quantity;
        }

        // Properties
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
    }
    // Order System
    public class OrderSystem
    {
        public void confirmOrder()
        {
            Console.WriteLine("Order is confirmed.");
        }
        public void setDelivery()
        {
            Console.WriteLine("Delivery details are set.");
        }
    }

   // Inventory System 
   public class InventorySystem
    {
              private Dictionary<string, Item> inventory = new Dictionary<string, Item>();
        public void addItem(Item item)
        {
            inventory[item.Name] = item;
        }
        public Item getItem(string name)
        {
            return inventory[name];
        }
        public bool checkAvailability(string itemName, int quantity)
        {
            Console.WriteLine($"Checking stock for {itemName}...");
            return inventory[itemName].Quantity >= quantity;
        }
        public void reduceStock(string itemName, int quantity)
        {
            Console.WriteLine(
            $"Reducing stock of {itemName} by {quantity}");
            inventory[itemName].Quantity -= quantity;
        }
    }

    // Payment System
    public class PaymentSystem
    {
        private double balance = 0.0;
        public void addFunds(double amount)
        {
            Console.WriteLine($"\nAdding ${amount:N2} to balance");
            balance += amount;
            Console.WriteLine($"Current funds: ${balance:N2}");
        }

        public bool processPayment(double amount)
        {
            Console.WriteLine(
                $"Processing payment of ${amount:N2}...");
            if (amount <= balance)
            {
                balance -= amount;
                Console.WriteLine("Payment successful.");
                Console.WriteLine($"Funds left: ${balance:N2}");
                return true;
            }
            else
            {
                Console.WriteLine(
                    "Payment unsuccessful: insufficient funds.");
                return false;
            }
        }
    }

    // Facade
    public class ShoppingCartFacade
    {
        private InventorySystem inventorySystem;
        private PaymentSystem paymentSystem;
        private OrderSystem orderSystem;

        public ShoppingCartFacade(
            InventorySystem inventorySystem,
            PaymentSystem paymentSystem,
            OrderSystem orderSystem)
        {
            this.inventorySystem = inventorySystem;
            this.paymentSystem = paymentSystem;
            this.orderSystem = orderSystem;
        }

        public void checkout(string itemName, int quantity)
        {
            Console.WriteLine("\nStarting checkout process...");

            // 1) Check if there is sufficient stock of the item
            bool inStock = inventorySystem.checkAvailability(itemName, quantity);
            if (!inStock)
            {
                Console.WriteLine("Insufficient stock.");
                return;
            }

            // 2) Check if user has sufficient funds
            //    (We need the price from InventorySystem)
            Item item = inventorySystem.getItem(itemName);
            double totalAmount = item.Price * quantity;

            bool paymentSuccess = paymentSystem.processPayment(totalAmount);
            if (!paymentSuccess)
            {
                Console.WriteLine("Insufficient stock.");
                return;
            }

            // 3) Reduce the stock
            inventorySystem.reduceStock(itemName, quantity);

            // 4) Confirm the order and set delivery details
            orderSystem.confirmOrder();
            orderSystem.setDelivery();

            Console.WriteLine();
        }
    }
}
