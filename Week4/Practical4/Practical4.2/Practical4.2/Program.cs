using System;
using System.Collections.Generic;


public class MenuItem
{
    private string name;
    private float price;

    public string Name { get { return name; } }
    public float Price { get { return price; } }

    public MenuItem(string name, float price)
    {
        this.name = name;
        this.price = price;
    }
}

public class DinerMenu
{   
    private int numberOfItems = 0;
    private MenuItem[] menuItems = new MenuItem[20];

    public int NumberOfItems { get { return numberOfItems; } }

    public PriceIterator createIterator(float maxPrice)
    {
        return new PriceIterator(this, maxPrice);
    }

    public void addItem(MenuItem item)
    {
        menuItems[numberOfItems++] = item;
    }

    public MenuItem getItem(int position)
    {
        if (position < 0 || position >= numberOfItems)
        {
            throw new IndexOutOfRangeException("Invalid position for menu item.");
        }
        return menuItems[position];
    }

}

public interface Iterator
{
    public bool hasNext();
    public object next();
}

public class PriceIterator : Iterator
{
    private DinerMenu dinerMenu;
    private float maxPrice;
    private int position = 0;

    public PriceIterator(DinerMenu dinerMenu, float maxPrice)
    {
        this.dinerMenu = dinerMenu;
        this.maxPrice = maxPrice;
    }

    public bool hasNext()
    {
        while (position < dinerMenu.NumberOfItems)
        {
            if (dinerMenu.getItem(position).Price <= maxPrice)
            {
                return true;
            }
            position++;
        }
        return false;
    }

    public object next()
    {
        if (!hasNext())
        {
            throw new InvalidOperationException("No items available within max price range.");
        }
        MenuItem menuItem = dinerMenu.getItem(position);
        position++;
        return menuItem;
    }
}

// Program Class to Test the Iterator
public class Program
{
    public static void Main(string[] args)
    {
        DinerMenu mcdodo = new DinerMenu();
        mcdodo.addItem(new MenuItem("Hamburger", 2.00f));
        mcdodo.addItem(new MenuItem("McSpicy", 3.50f));
        mcdodo.addItem(new MenuItem("Fries", 1.50f));

        PriceIterator iter = mcdodo.createIterator(2.50f);
        while (iter.hasNext())
        {
            MenuItem item = (MenuItem)iter.next();
            Console.WriteLine($"{item.Name,12}   ${item.Price:N2}");
        }

    }
}