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
using System.Collections; // Включаємо простір імен для використання класу IEnumerable

class Program
{
    // Функція для перевірки, чи другий рядок є зворотнім першому
    static bool IsReverse(IEnumerable s1, IEnumerable s2)
    {
        // Перевірка, чи різна довжина рядків
        var enumerator1 = s1.GetEnumerator(); // Отримуємо перелічувач для першого рядка
        var enumerator2 = s2.GetEnumerator(); // Отримуємо перелічувач для другого рядка
        while (enumerator1.MoveNext()) // Перебираємо елементи першого рядка
        {
            if (!enumerator2.MoveNext() || enumerator1.Current.ToString() != enumerator2.Current.ToString())
                return false; // Якщо елементи різні або закінчилися, повертаємо false
        }
        if (enumerator2.MoveNext()) // Якщо у другому рядку ще залишилися елементи, повертаємо false
            return false;
        return true; // Якщо всі умови виконані, повертаємо true
    }

    static void Main()
    {
        // Введення першого рядка від користувача
        Console.WriteLine("Введіть перший рядок:");
        string input1 = Console.ReadLine(); // Зчитуємо перший рядок з консолі
        IEnumerable s1 = input1; // Конвертуємо рядок у тип IEnumerable

        // Введення другого рядка від користувача
        Console.WriteLine("Введіть другий рядок:");
        string input2 = Console.ReadLine(); // Зчитуємо другий рядок з консолі
        IEnumerable s2 = input2; // Конвертуємо рядок у тип IEnumerable

        if (IsReverse(s1, s2)) // Викликаємо функцію IsReverse, передаючи два рядки
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

// Клас, який реалізує інтерфейси IEnumerable, IComparable та ICloneable
class MyArrayList : IEnumerable, IComparable, ICloneable
{
    private ArrayList list;

    public MyArrayList()
    {
        list = new ArrayList();
    }

    // Методи для реалізації інтерфейсу IEnumerable
    public IEnumerator GetEnumerator()
    {
        return list.GetEnumerator();
    }

    // Методи для реалізації інтерфейсу IComparable
    public int CompareTo(object obj)
    {
        MyArrayList other = obj as MyArrayList;
        if (other == null)
            throw new ArgumentException("Object is not a MyArrayList");
        return list.Count.CompareTo(other.list.Count);
    }

    // Методи для реалізації інтерфейсу ICloneable
    public object Clone()
    {
        MyArrayList clone = new MyArrayList();
        foreach (var item in list)
        {
            clone.list.Add(item);
        }
        return clone;
    }

    // Додаткові методи для роботи зі списком
    public void Add(object item)
    {
        list.Add(item);
    }

    public void Remove(object item)
    {
        list.Remove(item);
    }

    public void Clear()
    {
        list.Clear();
    }

    public int Count()
    {
        return list.Count;
    }
}

class Program
{
    static void Main()
    {
        // Вхідні дані у вигляді списку чисел
        MyArrayList numbers = new MyArrayList();
        numbers.Add(5);
        numbers.Add(-3);
        numbers.Add(7);
        numbers.Add(-8);
        numbers.Add(2);
        numbers.Add(-4);

        try
        {
            // Розділення чисел на позитивні та негативні
            MyArrayList positiveNumbers = new MyArrayList();
            MyArrayList negativeNumbers = new MyArrayList();

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



