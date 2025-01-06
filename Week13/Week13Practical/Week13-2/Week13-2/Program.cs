using Week13_2;

public class Program
{
    public static void Main(string[] args)
    {
        // Setup subsystems
        InventorySystem inventorySystem = new InventorySystem();
        PaymentSystem paymentSystem = new PaymentSystem();
        OrderSystem orderSystem = new OrderSystem();

        // Create the facade
        ShoppingCartFacade cartFacade =
            new ShoppingCartFacade(inventorySystem, paymentSystem, orderSystem);

        // --- 1) Add an item "Pokemon Pack" to inventory
        inventorySystem.addItem(new Item("Pokemon Pack", 7.00, 4));

        // --- 2) Add $20 to PaymentSystem
        paymentSystem.addFunds(20.00);

        // --- 3) Checkout 2 "Pokemon Pack" (cost: 2 * $7 = $14)
        cartFacade.checkout("Pokemon Pack", 2);

        // --- 4) Attempt to checkout 2 "Pokemon Pack" again 
        //         (cost: $14) but only $6 remains
        cartFacade.checkout("Pokemon Pack", 2);

        // --- 5) Add $30 more to PaymentSystem (now total $36)
        paymentSystem.addFunds(30.00);

        // --- 6) Checkout 2 "Pokemon Pack" again (cost: $14) 
        //         should succeed, leaving $22 
        cartFacade.checkout("Pokemon Pack", 2);

        // --- 7) Try to checkout 2 more "Pokemon Pack" 
        //         now that quantity is 0 
        cartFacade.checkout("Pokemon Pack", 2);
    }
}

