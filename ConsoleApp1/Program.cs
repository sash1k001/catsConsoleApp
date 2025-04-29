using ConsoleApp1;
using System.Text.RegularExpressions;

internal class Program
{
    private static void Main(string[] args)
    {
        List<ICat> cats = new();
        while (true)
        {
            Console.Write("1. Добавить котика\n2. Покормить котика\n3. Посмотреть список котиков\n4. Выход из приложения\n\nВаш выбор: ");
            string? choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.Clear();
                    while (true)
                    {
                        Console.Write("Введите имя котика: ");
                        string? catName = Console.ReadLine();
                        string regex = @"[a-z]|\s";
                        if (!Regex.IsMatch(catName, regex, RegexOptions.IgnoreCase) && catName != "")
                        {
                            Cat cat = new();
                            cat.setName(catName);
                            cats.Add(cat);
                            Console.Clear();
                            Console.WriteLine($"Котёнок {cat.getName()} успешно добавлен.\n\nНажмите любую клавишу для продолжения...");
                            Console.ReadKey();
                            Console.Clear();
                            break;

                        } else
                        {
                            Console.Clear();
                            Console.Write("Добавить котик не получилось(\n\nНажмите любую клавишу для продолжения...");
                            Console.ReadKey();
                            Console.Clear();
                        }
                    }
                    break;
                case "2":
                    Console.Clear();
                    if (cats.Count > 0)
                    {
                        while (true)
                        {
                            Console.Write("Напишите имя котика, которого хотите покормить: ");
                            string? catName = Console.ReadLine();
                            ICat? cat = cats.Find(t => t.getName().ToLower() == catName.ToLower());
                            if (cat != null)
                            {
                                if (cat.getEnergy() + 25 > 100)
                                {
                                    Console.Clear();
                                    Console.WriteLine($"Котик {cat.getName()} полностью сыт и полон энергии :)");
                                    Console.Write("\nНажмите на любую клавишу для продолжения...");
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                }
                                cat.Eat();
                                Console.Clear();
                                Console.Write($"Котик {cat.getName()}: {cat.Meow()}");
                                Console.Write("\n\nНажмите на любую клавишу для продолжения...");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            } else
                            {
                                Console.Clear();
                                Console.WriteLine("Такого котика нет :(");
                                Console.Write("\nНажмите на любую клавишу для продолжения...");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                        }
                    } else
                    {
                        Console.WriteLine("У вас нет котиков(");
                        Console.Write("\nНажмите на любую клавишу для продолжения...");
                        Console.ReadKey();
                        Console.Clear();
                    }
                        break;
                case "3":
                    if (cats.Count > 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Список котиков: \n");
                        int i = 1;
                        foreach (var cat in cats)
                        {
                            Console.WriteLine($"{i++}. {cat.getName()} | Уровень энергии: {cat.getEnergy()}");
                        }
                        Console.Write("\nНажмите любую клавишу для продолжения...");
                        Console.ReadKey();
                        Console.Clear();
                    } else
                    {
                        Console.Clear();
                        Console.WriteLine("Список котиков пуст... (((");
                        Console.Write("\nНажмите любую клавишу для продолжения...");
                        Console.ReadKey();
                        Console.Clear();
                    }
                        break;
                case "4":
                    Console.Clear();
                    return;
                default:
                    Console.Clear();
                    break;
            }
        }
    }
}