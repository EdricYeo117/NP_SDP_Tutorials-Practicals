using Practical5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Program
{
    public static void Main(string[] args)
    {
        Weapon w1 = new Dagger();
        Console.WriteLine($"{w1.getDescription()} deals {w1.getDamage()} damage.");
        w1 = new Burning(w1);
        Console.WriteLine($"{w1.getDescription()} deals {w1.getDamage()} damage.");
        w1 = new Pain(w1);
        Console.WriteLine($"{w1.getDescription()} deals {w1.getDamage()} damage.");
        w1 = new Icy(w1);
        Console.WriteLine($"{w1.getDescription()} deals {w1.getDamage()} damage.");
    }
}
