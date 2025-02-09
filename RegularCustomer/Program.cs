using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace RegularCustomer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Shop shop = new Shop();
            Customer customer = new Customer();
            shop.Items.CollectionChanged += customer.OnItemsChanged;

            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.A:
                        string itemName = $"Товар от {DateTime.Now}";
                        shop.Add(new Item(itemName));
                        break;
                    case ConsoleKey.D:
                        Console.Write("Введите ID товара для удаления: ");
                        if (int.TryParse(Console.ReadLine(), out int itemId))
                        {
                            shop.Remove(itemId);
                        }
                        else
                        {
                            Console.WriteLine("Ошибка: Некорректный ID");
                        }
                        break;
                    case ConsoleKey.X:
                        return;
                    default:
                        Console.WriteLine("Недопустимая команда.");
                        break;
                }
            }
        }

        public class Item
        {
            private static int currentId = 0;
            public int Id { get; }
            public string Name { get; }

            public Item(string name)
            {
                Id = currentId++;
                Name = name;
            }
        }

        public class Shop
        {
            public ObservableCollection<Item> Items = new ObservableCollection<Item>();

            public void Add(Item item)
            {
                Items.Add(item);
            }

            public void Remove(int itemId)
            {
                Item? itemToRemove = Items.FirstOrDefault(i => i.Id == itemId);
                if (itemToRemove != null)
                {
                    Items.Remove(itemToRemove);
                }
                else
                {
                    Console.WriteLine("Товар с указанным ID не найден.");
                }
            }
        }

        public class Customer
        {
            public void OnItemsChanged(object? sender, NotifyCollectionChangedEventArgs e)
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    if (e.NewItems != null)
                        foreach (Item newItem in e.NewItems)
                        {
                            Console.WriteLine($"Добавлен товар: {newItem.Name} (ID: {newItem.Id})");
                        }
                }
                else if (e.Action == NotifyCollectionChangedAction.Remove)
                {
                    if (e.OldItems != null)
                        foreach (Item oldItem in e.OldItems)
                        {
                            Console.WriteLine($"Удалён товар: {oldItem.Name} (ID: {oldItem.Id})");
                        }
                }
            }
        }
    } 
}
