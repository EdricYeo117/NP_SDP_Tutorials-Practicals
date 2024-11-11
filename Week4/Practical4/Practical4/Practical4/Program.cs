using System;
using System.Collections.Generic;
using System.Xml.Linq;

// OBserver Interface
public interface IObserver
{
    void Update(string stockname, double newPrice);
}

// Subject Interface
public interface IsSubject
{
    void RegisterObserver(IObserver observer);
    void RemoveObserver(IObserver observer);
    void NotifyObservers();
}

// Concrete Subject : CompanyStock
public class CompanyStock : IsSubject
{
    public string stockName { get; private set; }
    public double currentPrice;
    private List<IObserver> observers;

    public CompanyStock(string name, double price)
    {
        stockName = name;
        currentPrice = price;
        observers = new List<IObserver>();
    }

    // Property to set and get the current price of the stock
    public double CurrentPrice
    {
        get { return currentPrice; }
        set
        {
            currentPrice = value;
            Console.WriteLine($"Stock {stockName} new price: ${currentPrice:F2}");
            NotifyObservers();
        }
    }

    public void RegisterObserver(IObserver observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (var observer in observers)
        {
            observer.Update(stockName, currentPrice);
        }
    }

    public void SetPrice(double newPrice)
    {
        currentPrice = newPrice;
        Console.WriteLine($"Price of {stockName} has been changed to ${currentPrice:F2}");
        NotifyObservers();
    }
}

// Concrete Observer : Customer
public class  Customer : IObserver
{
    public string customerName { get; private set; }
    private List<CompanyStock> stocksOwned;

    // Constructor
    public Customer(string name)
    {
        customerName = name;
        stocksOwned = new List<CompanyStock>();
    }

    // Update method to receive notification from the subject
    public void Update(string stockname, double newPrice)
    {
        Console.WriteLine($"{customerName} is notified that {stockname} price is set to ${newPrice:F2}");
    }

    // Add stock to customer's portfolio
    public void AddStock(CompanyStock stock)
    {
        if (!stocksOwned.Contains(stock))
        {
            stocksOwned.Add(stock);
            stock.RegisterObserver(this);
            Console.WriteLine($"{customerName} has added {stock.stockName} to their portfolio");
        }
    }

    // Remove stock from customer's portfolio
    public void RemoveStock(CompanyStock stock)
    {
        if (stocksOwned.Contains(stock))
        {
            stocksOwned.Remove(stock);
            stock.RemoveObserver(this);
            Console.WriteLine($"{customerName} has removed {stock.stockName} from their portfolio");
        }
    }
}

// Program to demonstrate Observer pattern
public class Program
{
    public static void Main(string[] args)
    {
        // Create stocks
        CompanyStock apple = new CompanyStock("Apple", 233.0);
        CompanyStock tesla = new CompanyStock("Tesla", 261.63);
        CompanyStock singtel = new CompanyStock("SingTel", 3.23);

        // Create customers
        Customer john = new Customer("John");
        john.AddStock(apple);
        john.AddStock(tesla);

        Customer mary = new Customer("Mary");
        mary.AddStock(apple);
        mary.AddStock(singtel);

        // Update stock prices
        apple.CurrentPrice = 225.5;
        tesla.CurrentPrice = 264.2;

        // John removes Apple stock from his portfolio
        john.RemoveStock(apple);

        // Update stock price of Apple again
        apple.CurrentPrice = 255.1;
    }
}