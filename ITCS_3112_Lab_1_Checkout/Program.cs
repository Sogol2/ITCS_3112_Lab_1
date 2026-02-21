using ITCS_3112_Lab_1_Checkout.Contracts;
using ITCS_3112_Lab_1_Checkout.Domain;
using ITCS_3112_Lab_1_Checkout.Repositories;
using ITCS_3112_Lab_1_Checkout.Services;

/*
* ITCS 3112 - Lab 1: NinerCS Equipment Checkout
* Team Members:
*   Sogol Maghzian - 801367119
*   Qi Ye - 801405616
*/

namespace ITCS_3112_Lab_1_Checkout
{
    internal class Program
    {
        private static ICheckoutService _service = null!;
        private static ICatalog _catalog = null!;

        private const string Line = "=========================================";

        static void Main(string[] args)
        {
            
            IRepository repo = new InMemoryRepository();
            IClock clock = new Clock();
            IPolicy policy = new Policy(clock);
            INotifier notifier = new Notifier();

            _service = new CheckoutService(repo, policy, notifier, clock);
            _catalog = _service.GetCatalog();

            Console.WriteLine("Welcome | Checkout System (ITCS 3112 Lab 1)");

            while (true)
            {
                PrintMenu();
                int choice = ReadInt("Select a number: ");

                Console.WriteLine(Line);

                switch (choice)
                {
                    case 1:
                        AddItems(repo);
                        break;
                    case 2:
                        ListAvailable();
                        break;
                    case 3:
                        ListUnavailable();
                        break;
                    case 4:
                        CheckoutItem();
                        break;
                    case 5:
                        ReturnItem();
                        break;
                    case 6:
                        DueSoon();
                        break;
                    case 7:
                        Overdue();
                        break;
                    case 8:
                        Search();
                        break;
                    case 9:
                        MarkLost();
                        break;
                    case 0:
                        Console.WriteLine("Goodbye.");
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        private static void PrintMenu()
        {
            Console.WriteLine(Line);
            Console.WriteLine("1) Add items to inventory");
            Console.WriteLine("2) List available items");
            Console.WriteLine("3) List unavailable items");
            Console.WriteLine("4) Check out item");
            Console.WriteLine("5) Return item");
            Console.WriteLine("6) Due soon (next 24h)");
            Console.WriteLine("7) Overdue");
            Console.WriteLine("8) Search");
            Console.WriteLine("9) Mark item LOST");
            Console.WriteLine("0) Exit");
        }

        // -------------------- MENU OPTIONS --------------------

        private static void AddItems(IRepository repo)
        {
            Console.WriteLine("Add items to inventory");

            while (true)
            {
                Console.WriteLine("Enter each field on its own line: ID, Name, Category, Condition");

                string id = ReadNonEmpty("ID: ");
                string name = ReadNonEmpty("Name: ");
                string category = ReadNonEmpty("Category: ");
                ItemCondition condition = ReadCondition("Condition: ");

                var item = new EquipmentItem(id, name, category, condition);
                repo.UpsertItem(item);

                string cont = ReadOptional("Continue? [Y/n]: ").Trim().ToLower();
                if (cont == "n")
                    break;
            }
        }

        private static void ListAvailable()
        {
            Console.WriteLine("List Available Items");

            var items = _catalog.ListAvailable();
            if (items.Count == 0)
            {
                Console.WriteLine("None found");
                return;
            }

            foreach (var item in items)
            {
                Console.WriteLine($"{item.Id} | {item.Name} ({item.Category}; Condition: {item.Condition})");
            }
        }

        private static void ListUnavailable()
        {
            Console.WriteLine("List Unavailable Items");

            var lost = _catalog.ListLost();
            var checkedOut = _catalog.ListCheckedOut();

            if (lost.Count == 0 && checkedOut.Count == 0)
            {
                Console.WriteLine("None found");
                return;
            }

            if (lost.Count > 0)
            {
                Console.WriteLine("LOST:");
                foreach (var item in lost)
                {
                    Console.WriteLine($"{item.Id} | {item.Name} ({item.Category}; Condition: {item.Condition})");
                }
            }

            if (checkedOut.Count > 0)
            {
                Console.WriteLine("CHECKED_OUT:");
                foreach (var item in checkedOut)
                {
                    Console.WriteLine($"{item.Id} | {item.Name} ({item.Category}; Condition: {item.Condition})");
                }
            }
        }

        private static void CheckoutItem()
        {
            Console.WriteLine("Check out item");

            string itemId = ReadNonEmpty("Item ID: ");
            string name = ReadNonEmpty("Your name: ");
            string email = ReadNonEmpty("Your email: ");
            DateTime userDueDate = ReadDate("Due date: ");

            // simple borrower id for lab: just use email
            var borrower = new Borrower(email, name, email);
            
            try
            {
                var receipt = _service.Checkout(itemId, borrower, userDueDate);
                PrintReceiptLikeSample(receipt);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Could not check out item: {ex.Message}");
            }
        }

        private static void ReturnItem()
        {
            Console.WriteLine("Return item");

            string itemId = ReadNonEmpty("Item ID: ");

            try
            {
                var receipt = _service.ReturnItem(itemId);
                PrintReceiptLikeSample(receipt);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Could not return item: {ex.Message}");
            }
        }

        private static void MarkLost()
        {
            Console.WriteLine("Mark item LOST");

            string itemId = ReadNonEmpty("Item ID: ");

            try
            {
                _service.MarkLost(itemId);
                Console.WriteLine("Item marked as lost.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Could not mark item lost: {ex.Message}");
            }
        }

        private static void DueSoon()
        {
            Console.WriteLine("Due soon (next 24h)");

            var records = _service.FindDueSoon(TimeSpan.FromHours(24));
            if (records.Count == 0)
            {
                Console.WriteLine("None found");
                return;
            }

            foreach (var r in records)
            {
                Console.WriteLine($"Item ID: {r.ItemId} | Borrowed by {r.Borrower.Name} | {r.Borrower.Email}");
            }
        }

        private static void Overdue()
        {
            Console.WriteLine("Overdue");

            var records = _service.FindOverdue();
            if (records.Count == 0)
            {
                Console.WriteLine("None found");
                return;
            }

            foreach (var r in records)
            {
                Console.WriteLine($"Item ID: {r.ItemId} | Borrowed by {r.Borrower.Name} | {r.Borrower.Email}");
            }
        }

        private static void Search()
        {
            Console.WriteLine("Search");
            Console.WriteLine("Choose search type:");
            Console.WriteLine("1) Item ID");
            Console.WriteLine("2) Name");
            Console.WriteLine("3) Category");

            int choice = ReadInt("Enter your choice (1-3): ");

            SearchType type = choice switch
            {
                1 => SearchType.Id,
                2 => SearchType.Name,
                3 => SearchType.Category,
                _ => SearchType.Name
            };

            string query = ReadNonEmpty("Enter search term: ");
            var results = _catalog.Search(query, type);

            if (results.Count == 0)
            {
                Console.WriteLine("None found");
                return;
            }

            Console.WriteLine("Search Results:");
            foreach (var item in results)
            {
                Console.WriteLine($"- {item.Id} | {item.Name} | {item.Category} | {item.Status}");
            }
        }

        // -------------------- RECEIPT PRINTING --------------------

        private static void PrintReceiptLikeSample(Receipt receipt)
        {
            Console.WriteLine("-> Your receipt:");

            // sample format:
            // 9/10/2025 12:53:26 PM | Checkout (due 9/11/2025 12:53:26 PM) | 2
            if (receipt.DueDate.HasValue)
            {
                Console.WriteLine($"   {receipt.Timestamp:g} | " +
                                  $"{receipt.Title} (due " +
                                  $"{receipt.DueDate.Value:g}) | " +
                                  $"{receipt.ItemId}");
            }
            else
            {
                Console.WriteLine($"   {receipt.Timestamp:g} | " +
                                  $"{receipt.Title} | " +
                                  $"{receipt.ItemId}");
            }
        }

        // -------------------- INPUT HELPERS --------------------

        private static string ReadNonEmpty(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string? input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input))
                    return input.Trim();

                Console.WriteLine("Please enter a value.");
            }
        }

        private static string ReadOptional(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine() ?? "";
        }

        private static int ReadInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string? input = Console.ReadLine();

                if (int.TryParse(input, out int value))
                    return value;

                Console.WriteLine("Please enter a number.");
            }
        }

        private static DateTime ReadDate(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string? input = Console.ReadLine();

                if (DateTime.TryParse(input, out DateTime dt))
                    return dt;

                Console.WriteLine("Please enter a valid date (example: 9/10/2025).");
            }
        }

        private static ItemCondition ReadCondition(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string? input = Console.ReadLine();

                if (Enum.TryParse<ItemCondition>(input, true, out var condition))
                    return condition;

                Console.WriteLine("Condition must be one of: New, Good, Fair, Poor, Broken.");
            }
        }
    }
}
