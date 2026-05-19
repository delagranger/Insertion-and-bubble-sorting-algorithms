namespace SortingArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] original_array = GenerateRandomArray(GetArraySize());
            Console.Write("Исходный массив: ");
            PrintArray(original_array);

            Console.WriteLine("");

            int[] bubbleCopy = original_array.ToArray();
            int[] arrayBubbleSort = BubbleSort(bubbleCopy);
            Console.Write("Сортировка \"Пузырьком\": ");
            PrintArray(arrayBubbleSort);

            Console.WriteLine("");

            int[] insertionCopy = original_array.ToArray();
            int[] arrayInsertionSort = InsertionSort(insertionCopy);
            Console.Write("Сортировка \"Вставкой\": ");
            PrintArray(arrayInsertionSort);
        }
        static int GetArraySize()
        {
            Console.Write("Введите размер массива: ");
            int array_size = int.Parse(Console.ReadLine());

            return array_size;
        }
        static int[] BubbleSort(int[] array)
        {
            int temp;
            int replacementCounter = 0;
            int compareCounter = 0;

            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    compareCounter++;
                    if (array[j] > array[j + 1])
                    {
                        temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                        replacementCounter++;
                    }
                }
            }

            Console.WriteLine($"Количество перестановок при сортировке \"Пузырьком\": {replacementCounter}");
            Console.WriteLine($"Количество сравнений при сортировке \"Пузырьком\": {compareCounter}");

            return array;
        }
        static int[] InsertionSort(int[] array)
        {
            int compareCounter = 0;
            int replacementCounter = 0;

            for (int i = 1; i < array.Length; i++)
            {
                int current = array[i];
                int j = i - 1;

                while (j >= 0 && array[j] > current)
                {
                    compareCounter++;
                    array[j + 1] = array[j];
                    replacementCounter++;
                    j--;
                }
                compareCounter++;

                array[j + 1] = current;
                replacementCounter++;
            }

            Console.WriteLine($"Количество перестановок при сортировке \"Вставкой\": {replacementCounter}");
            Console.WriteLine($"Количество сравнений при сортировке \"Вставкой\": {compareCounter}");

            return array;
        }
        static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]} ");
            }
            Console.WriteLine("");
        }
        static int[] GenerateRandomArray(int size, int minValue = 0, int maxValue = 100000)
        {
            Random random = new Random();
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next(minValue, maxValue + 1);
            }
            return array;
        }
    }
}
