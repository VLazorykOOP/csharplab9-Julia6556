//Task 1
using System;
using System.Collections.Generic;

class Program
{
    static bool IsReverse(string s1, string s2)
    {
        // Перевіряємо, чи різна довжина рядків
        if (s1.Length != s2.Length)
            return false;

        Stack<char> stack = new Stack<char>();

        // Додаємо символи першого рядка в стек
        foreach (char c in s1)
        {
            stack.Push(c);
        }

        // Порівнюємо символи другого рядка з символами у стеку
        foreach (char c in s2)
        {
            // Якщо стек порожній або символи не збігаються, повертаємо false
            if (stack.Count == 0 || stack.Pop() != c)
                return false;
        }

        // Якщо стек порожній, рядки є зворотніми один одному
        return stack.Count == 0;
    }

    static void Main()
    {
        Console.WriteLine("Введіть перший рядок:");
        string s1 = Console.ReadLine();

        Console.WriteLine("Введіть другий рядок:");
        string s2 = Console.ReadLine();

        if (IsReverse(s1, s2))
        {
            Console.WriteLine("Другий рядок є зворотнім першому.");
        }
        else
        {
            Console.WriteLine("Другий рядок не є зворотнім першому.");
        }
    }
}
//Task 2
using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        // Введення шляху до файлу
        Console.WriteLine("Введіть шлях до файлу:");
        string filePath = Console.ReadLine();

        try
        {
            // Читання чисел з файлу та виведення їх у вказаному порядку
            using (StreamReader reader = new StreamReader(filePath))
            {
                Queue<int> positiveNumbers = new Queue<int>();
                Queue<int> negativeNumbers = new Queue<int>();

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    int number = int.Parse(line);
                    if (number >= 0)
                    {
                        positiveNumbers.Enqueue(number);
                    }
                    else
                    {
                        negativeNumbers.Enqueue(number);
                    }
                }

                // Друкуємо спочатку всі позитивні числа
                Console.WriteLine("Позитивні числа:");
                while (positiveNumbers.Count > 0)
                {
                    Console.WriteLine(positiveNumbers.Dequeue());
                }

                // Друкуємо потім всі негативні числа
                Console.WriteLine("Негативні числа:");
                while (negativeNumbers.Count > 0)
                {
                    Console.WriteLine(negativeNumbers.Dequeue());
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Файл не знайдено.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Сталася помилка: {ex.Message}");
        }
    }
}
// Task 3 ( працюю з завд 1)
using System;
using System.Collections;

class Program
{
    static bool IsReverse(ArrayList s1, ArrayList s2)
    {
        // Перевірка, чи різна довжина рядків
        if (s1.Count != s2.Count)
            return false;

        Stack stack = new Stack();

        // Додаємо символи першого рядка в стек
        foreach (char c in s1)
        {
            stack.Push(c);
        }

        // Порівнюємо символи другого рядка з символами у стеку
        foreach (char c in s2)
        {
            // Якщо стек порожній або символи не збігаються, повертаємо false
            if (stack.Count == 0 || (char)stack.Pop() != c)
                return false;
        }

        // Якщо стек порожній, рядки є зворотніми один одному
        return stack.Count == 0;
    }

    static void Main()
    {
        // Введення першого рядка від користувача
        Console.WriteLine("Введіть перший рядок:");
        string input1 = Console.ReadLine();
        ArrayList s1 = new ArrayList();
        foreach (char c in input1)
        {
            s1.Add(c);
        }

        // Введення другого рядка від користувача
        Console.WriteLine("Введіть другий рядок:");
        string input2 = Console.ReadLine();
        ArrayList s2 = new ArrayList();
        foreach (char c in input2)
        {
            s2.Add(c);
        }

        if (IsReverse(s1, s2))
        {
            Console.WriteLine("Другий рядок є зворотнім першому.");
        }
        else
        {
            Console.WriteLine("Другий рядок не є зворотнім першому.");
        }
    }
}


// Task 3 ( працюю з завд 2)
using System;
using System.Collections;
using System.IO;

class Program
{
    static void Main()
    {
        // Вхідні дані у вигляді списку чисел
        ArrayList numbers = new ArrayList() { 5, -3, 7, -8, 2, -4 };

        try
        {
            // Розділення чисел на позитивні та негативні
            ArrayList positiveNumbers = new ArrayList();
            ArrayList negativeNumbers = new ArrayList();

            foreach (int number in numbers)
            {
                if (number >= 0)
                {
                    positiveNumbers.Add(number);
                }
                else
                {
                    negativeNumbers.Add(number);
                }
            }

            // Виведення позитивних чисел
            Console.WriteLine("Позитивні числа:");
            foreach (int number in positiveNumbers)
            {
                Console.WriteLine(number);
            }

            // Виведення негативних чисел
            Console.WriteLine("Негативні числа:");
            foreach (int number in negativeNumbers)
            {
                Console.WriteLine(number);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Сталася помилка: {ex.Message}");
        }
    }
}

