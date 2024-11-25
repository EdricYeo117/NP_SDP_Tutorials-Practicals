// See https://aka.ms/new-console-template for more information
using ConsoleApp1;

void main ()
{
    Shop shop1 = new Shop("Board Game Bits");
    Shop shop2 = new Shop("Fnacy Furniture");

    Customer customer1 = new Customer("John");
    shop1.RegisterObserver(customer1);
    shop2.RegisterObserver(customer1);

    Customer customer2 = new Customer("Siti");
    shop1.RegisterObserver(customer2);

    Customer customer3 = new Customer("Ah Huat");
    shop2.RegisterObserver(customer3);

    Product product1 = new Product("Metal Houses for Monopoly");
    shop1.addProduct(product1);

    Product product2 = new Product("Razzer Awesome gaming chair");
    shop2.addProduct(product2);

    shop1.RemoveObserver(customer1);
    shop1.removeProduct(product1);

}


main();