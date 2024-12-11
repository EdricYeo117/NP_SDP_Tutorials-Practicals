using System;
using System.Collections.Generic;

// MenuComponent (Abstract Class)
public abstract class MenuComponent
{
    public virtual void Add(MenuComponent menuComponent)
    {
        throw new NotSupportedException();
    }

    public virtual void Remove(MenuComponent menuComponent)
    {
        throw new NotSupportedException();
    }

    public virtual MenuComponent GetChild(int index)
    {
        throw new NotSupportedException();
    }

    public virtual string Name
    {
        get { throw new NotSupportedException(); }
    }

    public virtual string Description
    {
        get { throw new NotSupportedException(); }
    }

    public virtual double Price
    {
        get { throw new NotSupportedException(); }
    }

    public virtual bool Vegetarian
    {
        get { throw new NotSupportedException(); }
    }

    public virtual void Print()
    {
        throw new NotSupportedException();
    }

    public virtual IEnumerator<MenuComponent> CreateIterator()
    {
        throw new NotSupportedException();
    }
}

// MenuItem Class (Leaf)
public class MenuItem : MenuComponent
{
    private string name;
    private string description;
    private bool vegetarian;
    private double price;

    public MenuItem(string name, string description, bool vegetarian, double price)
    {
        this.name = name;
        this.description = description;
        this.vegetarian = vegetarian;
        this.price = price;
    }

    public override string Name => name;
    public override string Description => description;
    public override double Price => price;
    public override bool Vegetarian => vegetarian;

    public override void Print()
    {
        Console.Write($"  {Name}");
        if (Vegetarian)
        {
            Console.Write(" (veg.)");
        }
        Console.WriteLine($": ${Price:N2}");
        Console.WriteLine($"  -- {Description}");
    }

    public override IEnumerator<MenuComponent> CreateIterator()
    {
        return new NullIterator();
    }
}

// DinerMenu Class (Composite)
public class DinerMenu : MenuComponent
{
    private List<MenuComponent> components = new List<MenuComponent>();
    private string name;

    public DinerMenu(string name)
    {
        this.name = name;
    }

    public override string Name => name;

    public override void Add(MenuComponent menuComponent)
    {
        components.Add(menuComponent);
    }

    public override void Remove(MenuComponent menuComponent)
    {
        components.Remove(menuComponent);
    }

    public override MenuComponent GetChild(int index)
    {
        return components[index];
    }

    public override void Print()
    {
        Console.WriteLine($"\n{Name.ToUpper()}");
        Console.WriteLine(new string('-', Name.Length));
        foreach (var component in components)
        {
            component.Print();
        }
    }

    public override IEnumerator<MenuComponent> CreateIterator()
    {
        return components.GetEnumerator();
    }
}

// NullIterator Class
public class NullIterator : IEnumerator<MenuComponent>
{
    public MenuComponent Current => null;

    object System.Collections.IEnumerator.Current => Current;

    public bool MoveNext() => false;

    public void Reset() {}

    public void Dispose() {}
}

// Waitress Class
public class Waitress
{
    private MenuComponent allMenus;

    public Waitress(MenuComponent allMenus)
    {
        this.allMenus = allMenus;
    }

    public void PrintMenu()
    {
        allMenus.Print();
    }

    public void PrintVegetarianMenu()
    {
        Console.WriteLine("\nVEGETARIAN MENU");
        Console.WriteLine(new string('-', 15));
        var iterator = allMenus.CreateIterator();
        while (iterator.MoveNext())
        {
            try
            {
                MenuComponent menuComponent = iterator.Current;
                if (menuComponent != null && menuComponent.Vegetarian)
                {
                    menuComponent.Print();
                }
            }
            catch (NotSupportedException) { }
        }
    }
}

// Test the Implementation
public class Program
{
    public static void Main()
    {
        MenuComponent breakfastMenu = new DinerMenu("Breakfast");
        breakfastMenu.Add(new MenuItem("Blueberry Pancakes", "Pancakes made with fresh blueberries and maple syrup", true, 3.99));
        breakfastMenu.Add(new MenuItem("BLT", "Classic bacon, lettuce and tomato sandwich on whole wheat toast", false, 3.49));

        MenuComponent mainsMenu = new DinerMenu("Mains");
        mainsMenu.Add(new MenuItem("Veggie Spaghetti", "Spaghetti with mushrooms, spinach, and tomatoes", true, 5.99));
        
        MenuComponent chickenMenu = new DinerMenu("Chicken");
        chickenMenu.Add(new MenuItem("Crispy Fried Chicken", "Kampung chicken deep-fried to perfection in beer batter", false, 8.99));
        chickenMenu.Add(new MenuItem("Roast Chicken", "Slow-roasted rotisserie chicken with honey glaze", false, 10.49));

        mainsMenu.Add(chickenMenu);

        MenuComponent allMenus = new DinerMenu("DP Diner");
        allMenus.Add(breakfastMenu);
        allMenus.Add(mainsMenu);

        Waitress waitress = new Waitress(allMenus);

        // Print all menus
        waitress.PrintMenu();

        // Print vegetarian menu
        waitress.PrintVegetarianMenu();
    }
}

