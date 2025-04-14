using System;
using System.Diagnostics;

class SearchAlgorithms
{
    public static int LinearSearch(int[] array, int target)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == target)
                return i;
        }
        return -1;
    }

    public static int BinarySearch(int[] array, int target)
    {
        int left = 0, right = array.Length - 1;
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (array[mid] == target) 
                return mid;
            if (array[mid] < target) 
                left = mid + 1;
            else
                right = mid - 1;
        }
        return -1;
    }

    public static int InterpolationSearch(int[] array, int target)
    {
        int low = 0, high = array.Length - 1;
        while (low <= high && target >= array[low] && target <= array[high])
        {
            if (low == high)
            {
                if (array[low] == target) 
                    return low;
                return -1;
            }

            int pos = low + ((target - array[low]) * (high - low) / (array[high] - array[low]));

            if (array[pos] == target)
                return pos;
            if (array[pos] < target)
                low = pos + 1;
            else 
                high = pos - 1;
        }
        return -1;
    }

    static void Main()
    {
        int[] sizes = { 100, 1000, 10000 };
        int testRuns = 5;
        Random rand = new Random();

        foreach (int size in sizes)
        {
            int[] sortedArray = new int[size];
            for (int i = 0; i < size; i++)
                sortedArray[i] = i;

            int[] reverseArray = new int[size];
            for (int i = 0; i < size; i++)
                reverseArray[i] = size - i - 1;

            int[] randomArray = new int[size];
            for (int i = 0; i < size; i++)
                randomArray[i] = rand.Next(size * 2);

            MeasureSearchPerformance("Linear Search", sortedArray, randomArray, size, testRuns, LinearSearch);
            MeasureSearchPerformance("Binary Search", sortedArray, sortedArray, size, testRuns, BinarySearch);
            MeasureSearchPerformance("Interpolation Search", sortedArray, sortedArray, size, testRuns, InterpolationSearch);
        }
    }

    static void MeasureSearchPerformance(string searchName, int[] sortedArray, int[] testArray, int size, int testRuns, Func<int[], int, int> searchMethod)
    {
        Stopwatch stopwatch = new Stopwatch();
        long totalTime = 0;

        for (int i = 0; i < testRuns; i++)
        {
            int target = testArray[new Random().Next(testArray.Length)];
            stopwatch.Restart();
            searchMethod(sortedArray, target);
            stopwatch.Stop();
            totalTime += stopwatch.ElapsedTicks;
        }

        Console.WriteLine($"{searchName} в размере {size}: {totalTime / testRuns} тиков (среднее относительно {testRuns} тестов)");
    }
}