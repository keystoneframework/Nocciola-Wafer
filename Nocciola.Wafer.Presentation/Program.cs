using System;
using System.Linq;
using Keystone.Polaris;
using Keystone.Carbonite.Diamant;
using Nocciola.Wafer.Processes;

namespace Nocciola.Wafer.Presentation
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var stopApplication = false;
            do
            {
                switch (ShowMenuAndGetSelection())
                {
                    case MenuAction.CreateOrders: CreateOrders(); break;
                    case MenuAction.ChangeFirstOrderStatus: ChangeFirstOrderStatus("Preparing"); break;
                    case MenuAction.ShowPagedOrders: ShowPagedOrders(); break;
                    case MenuAction.EraseAllOrders: EraseAllPurchaseOrders(); break;
                    case MenuAction.Exit: stopApplication = true; break;
                }
            } while (!stopApplication);
        }

        private static MenuAction ShowMenuAndGetSelection()
        {
            Console.WriteLine("=== Wafer Main Menu ===\n");
            Console.WriteLine("1. Create some sample orders");
            Console.WriteLine("2. Change the first order status");
            Console.WriteLine("3. Show current orders (paged view)");
            Console.WriteLine("4. Erase all orders");
            Console.WriteLine("5. Exit application\n");
            Console.Write("Write the number corresponding to your choice: ");

            int selection;
            if (!int.TryParse(Console.ReadLine(), out selection) || selection < 0 || selection > 5) { Console.Clear(); return ShowMenuAndGetSelection(); }
            else { Console.Clear(); return (MenuAction)selection; }
        }

        private static void CreateOrders()
        {
            Console.Write("Creating orders... ");
            new CreatePurchaseOrder { Restaurant = "The italian touch", Gelato = "Cioccolato", Gallons = 10 }.Run();
            new CreatePurchaseOrder { Restaurant = "Caffè e gelati", Gelato = "Caffè", Gallons = 50 }.Run();
            new CreatePurchaseOrder { Restaurant = "Caffè e gelati", Gelato = "Nocciola", Gallons = 24 }.Run();
            ShowDoneMessage();
        }

        private static void ChangeFirstOrderStatus(string newStatus)
        {
            Console.Write("Change order status...");
            var firstPurchaseOrdersPage = new GetPurchaseOrdersSummary() { PagingCriteria = new Paging(1) }.Run();
            if (firstPurchaseOrdersPage.IsNotEmpty())
                new ChangePurchaseOrderStatus
                {
                    PurchaseOrderId = firstPurchaseOrdersPage.First().Id,
                    PurchaseOrderStatus = newStatus
                }.Run();
            ShowDoneMessage();
        }

        private static void EraseAllPurchaseOrders()
        {
            Console.Write("Erasing all orders... ");
            new EraseAllPurchaseOrders().Run();
            ShowDoneMessage();
        }

        private static void ShowPagedOrders()
        {
            Console.WriteLine(new string('-', 58));
            Console.WriteLine($"{"RESTAURANT",-20}{"GELATO",-15}{"STATUS",-10}{"AMOUNT",13}");
            Console.WriteLine(new string('-', 58));
            var currentViewingPage = 0;
            var stopOrderViewing = false;
            do
            {
                var purchaseOrdersInCurrentPage = new GetPurchaseOrdersSummary { PagingCriteria = new Paging(5, ++currentViewingPage) }.Run();
                purchaseOrdersInCurrentPage.ForEach(order => Console.WriteLine($"{order.RestaurantName,-20}{order.GelatoName,-15}{order.CurrentStatus,-10}{order.Amount,13:c}"));
                Console.Write(purchaseOrdersInCurrentPage.IsNotEmpty() ? $"-- More --" : "\t\t\n");
                stopOrderViewing = purchaseOrdersInCurrentPage.IsEmpty() || Console.ReadKey().Key == ConsoleKey.Escape;
            } while (!stopOrderViewing);
            ShowDoneMessage();
        }

        private static void ShowDoneMessage()
        {
            Console.WriteLine("Done.\n\nPress any key to return to menu...\n");
            Console.ReadKey();
            Console.Clear();
        }
    }
}