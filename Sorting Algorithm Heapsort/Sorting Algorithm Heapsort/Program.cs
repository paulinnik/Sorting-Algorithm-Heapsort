using System;

class HeapsortExample
{
    // Основной метод для выполнения Heapsort
    public static void Heapsort(int[] array)
    {
        int n = array.Length;

        // Построение max-кучи
        for (int i = n / 2 - 1; i >= 0; i--)
        {
            Heapify(array, n, i);
        }

        // Извлечение элементов из кучи по одному
        for (int i = n - 1; i > 0; i--)
        {
            // Перемещаем текущий корень (максимум) в конец массива
            Swap(array, 0, i);

            // Восстанавливаем свойство кучи для уменьшенной части массива
            Heapify(array, i, 0);
        }
    }

    // Метод для преобразования поддерева в кучу
    private static void Heapify(int[] array, int n, int i)
    {
        int largest = i; // Корень поддерева
        int left = 2 * i + 1; // Левый дочерний элемент
        int right = 2 * i + 2; // Правый дочерний элемент

        // Если левый дочерний элемент больше корня
        if (left < n && array[left] > array[largest])
        {
            largest = left;
        }

        // Если правый дочерний элемент больше текущего наибольшего
        if (right < n && array[right] > array[largest])
        {
            largest = right;
        }

        // Если наибольший элемент не корень
        if (largest != i)
        {
            Swap(array, i, largest);

            // Рекурсивно преобразуем затронутое поддерево
            Heapify(array, n, largest);
        }
    }

    // Вспомогательный метод для обмена двух элементов
    private static void Swap(int[] array, int a, int b)
    {
        int temp = array[a];
        array[a] = array[b];
        array[b] = temp;
    }

    // Тестирование алгоритма
    static void Main(string[] args)
    {
        Console.WriteLine("Введите элементы исходного массива:");
        string input = Console.ReadLine();
        int[] array = Array.ConvertAll(input.Split(' '), int.Parse);

        Heapsort(array);

        Console.WriteLine("\nОтсортированный массив:");
        PrintArray(array);
        RunTests();
        System.Console.ReadKey();

    }

    // Метод для вывода массива на экран
    private static void PrintArray(int[] array)
    {
        foreach (var item in array)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
    private static void CompareWithExpected(int[] input, int[] expected)
    {
        HeapsortExample.Heapsort(input);
        bool isEqual = true;
        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] != expected[i])
            {
                isEqual = false;
                break;
            }
        }
        Console.WriteLine(isEqual ? "Тест пройден" : "Тест провален");
    }

    public static void RunTests()
    {
        // Тест 1: Случайный массив
        int[] test1 = { 5, 1, 4, 2, 8 };
        int[] expected1 = { 1, 2, 4, 5, 8 };
        CompareWithExpected(test1, expected1);

        // Тест 2: Уже отсортированный массив
        int[] test2 = { 1, 2, 3, 4, 5 };
        int[] expected2 = { 1, 2, 3, 4, 5 };
        CompareWithExpected(test2, expected2);

        // Тест 3: Обратно отсортированный массив
        int[] test3 = { 5, 4, 3, 2, 1 };
        int[] expected3 = { 1, 2, 3, 4, 5 };
        CompareWithExpected(test3, expected3);

        // Тест 4: Пустой массив
        int[] test4 = { };
        int[] expected4 = { };
        CompareWithExpected(test4, expected4);

        // Тест 5: Массив из одного элемента
        int[] test5 = { 42 };
        int[] expected5 = { 42 };
        CompareWithExpected(test5, expected5);
    }

}
