using CSharpTrainingConsoleApp;

internal class Program
{
    private static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Главное меню ===");
            Console.WriteLine("1 — Задание 1 (исключения)");
            Console.WriteLine("2 — Задание 2 (сортировка фамилий)");
            Console.WriteLine("0 — Выход");
            Console.Write("Выберите пункт: ");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    RunExceptionsDemo();
                    break;

                case "2":
                    RunSortDemo();
                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine("Неизвестный пункт меню.");
                    Console.ReadKey();
                    break;
            }
        }
    }

    // === ЗАДАНИЕ 2 ===
    static void RunSortDemo()
    {
        Console.Clear();
        Console.WriteLine("=== Задание 2: сортировка фамилий через событие ===");
        Console.WriteLine("Введите 1 — сортировка А–Я");
        Console.WriteLine("Введите 2 — сортировка Я–А");
        Console.Write("Ваш выбор: ");

        var sorter = new NameSorter();

        // Подписываем методы на событие
        sorter.OnSort += sorter.SortAscending;
        sorter.OnSort += sorter.SortDescending;

        try
        {
            string userInput = Console.ReadLine();

            int option = int.Parse(userInput);

            if (option != 1 && option != 2)
                throw new InvalidSortOptionException("Допустимо вводить только 1 или 2!");

            sorter.StartSort(option);
        }
        catch (FormatException)
        {
            Console.WriteLine("Ошибка: нужно вводить только число!");
        }
        catch (InvalidSortOptionException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("Работа модуля завершена.");
            Console.WriteLine("Нажмите любую клавишу...");
            Console.ReadKey();
        }
    }

    // ===  ЗАДАНИЕ 1 (как у тебя было) ===
    static void RunExceptionsDemo()
    {
        Console.Clear();
        Console.WriteLine("=== Задание 1: массив исключений ===");

        Action[] actions = new Action[]
        {
            () => throw new ArgumentNullException("param", "Аргумент оказался null."),
            () => { int[] a = new int[2]; var x = a[5]; },
            () => { int zero = 0; var r = 10 / zero; },
            () => throw new InvalidOperationException("Неверная операция выполнена."),
            () => throw new MyCustomException("Это моё собственное исключение.")
        };

        for (int i = 0; i < actions.Length; i++)
        {
            Console.WriteLine($"--- Итерация {i + 1} ---");
            try
            {
                actions[i].Invoke();
                Console.WriteLine("Действие прошло без исключения.");
            }
            catch (ArgumentNullException ane)
            {
                Console.WriteLine($"Пойман ArgumentNullException: {ane.Message}");
            }
            catch (IndexOutOfRangeException iore)
            {
                Console.WriteLine($"Пойман IndexOutOfRangeException: {iore.Message}");
            }
            catch (DivideByZeroException dbz)
            {
                Console.WriteLine($"Пойман DivideByZeroException: {dbz.Message}");
            }
            catch (MyCustomException mce)
            {
                Console.WriteLine($"Пойман MyCustomException: {mce.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Поймано общее исключение: {ex.GetType().Name} — {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Блок finally выполнен.");
                Console.WriteLine();
            }
        }

        Console.WriteLine("Нажмите любую клавишу...");
        Console.ReadKey();
    }
}
