using System.Reflection.Metadata;
namespace Sorting;

public class Program
{
    public static void Main(string[] args)
    {
        var array = new int[] { 5, 2, 4, 6, 1, 3 };
        Console.WriteLine(string.Join(", ", array));
        SelectionSort(array);
        Console.WriteLine(string.Join(", ", array));

    }

    //-----------------------------------------------------------------
    //  Sorts the specified array of integers using the selection
    //  sort algorithm.
    //-----------------------------------------------------------------
    private static void SelectionSort(int[] array)
    {
        int min;
        for (int index = 0; index < array.Length - 1; index++)
        {
            min = index;
            for (int scan = index + 1; scan < array.Length; scan++)
                if (array[scan].CompareTo(array[min]) < 0)
                    min = scan;

            Swap(array, min, index);
        }
    }

    //-----------------------------------------------------------------
    //  Swaps two elements in the specified array.
    //-----------------------------------------------------------------
    private static int Swap(int[] array, int a, int b)
    {
        int temp = array[a];
        array[a] = array[b];
        array[b] = temp;
        return temp;
    }

    private static IComparable Swap(IComparable[] array, int a, int b)
    {
        IComparable temp = array[a];
        array[a] = array[b];
        array[b] = temp;
        return temp;
    }

    //-----------------------------------------------------------------
    //  Sorts the specified array of objects using an insertion
    //  sort algorithm.
    //-----------------------------------------------------------------
    public static void InsertionSort(IComparable[] data)
    {
        for (int index = 1; index < data.Length; index++)
        {
            IComparable key = data[index];
            int position = index;
            //  Shift larger values to the right
            while (position > 0 && data[position - 1].CompareTo(key) > 0)
            {
                data[position] = data[position - 1];
                position--;
            }
            data[position] = key;
        }
    }

    //-----------------------------------------------------------------
    //  Sorts the specified array of objects using a bubble sort
    //  algorithm.
    //-----------------------------------------------------------------
    public static void BubbleSort(IComparable[] data)
    {
        int position, scan;
        for (position = data.Length - 1; position >= 0; position--)
        {
            for (scan = 0; scan <= position - 1; scan++)
                if (data[scan].CompareTo(data[scan + 1]) > 0)
                    Swap(data, scan, scan + 1);
        }
    }

    //-----------------------------------------------------------------
    //  Sorts the specified array of objects using the quick sort
    //  algorithm.
    //-----------------------------------------------------------------
    public static void QuickSort(IComparable[] data, int min, int max)
    {
        int pivot;
        if (min < max)
        {
            pivot = Partition(data, min, max); // make partitions
            QuickSort(data, min, pivot - 1); // sort left partition
            QuickSort(data, pivot + 1, max); // sort right partition
        }
    }

    //-----------------------------------------------------------------
    //  Creates the partitions needed for quick sort.
    //-----------------------------------------------------------------
    private static int Partition(IComparable[] data, int min, int max)
    {
        //  Use first element as the partition value
        IComparable partitionValue = data[min];
        int left = min;
        int right = max;
        while (left < right)
        {
            // Search for an element that is > the partition element
            while (data[left].CompareTo(partitionValue) <= 0 && left < right)
                left++;
            //  Search for an element that is < the partitionelement
            while (data[right].CompareTo(partitionValue) > 0)
                right--;
            if (left < right)
                Swap(data, left, right);
        }
        //  Move the partition element to its final position
        Swap(data, min, right);
        return right;
    }

    //-----------------------------------------------------------------
    //  Sorts the specified array of objects using the merge sort
    //  algorithm.
    //-----------------------------------------------------------------
    public static void MergeSort(IComparable[] data, int min, int max)
    {
        if (min < max)
        {
            int mid = (min + max) / 2;
            MergeSort(data, min, mid);
            MergeSort(data, mid + 1, max);
            Merge(data, min, mid, max);
        }
    }

    //-----------------------------------------------------------------
    //  Sorts the specified array of objects using the merge sort
    //  algorithm.
    //-----------------------------------------------------------------
    public static void Merge(IComparable[] data, int first, int mid, int last)
    {
        IComparable[] temp = new IComparable[data.Length];
        int first1 = first, last1 = mid; // endpoints of first subarray
        int first2 = mid + 1, last2 = last; // endpoints of second subarray
        int index = first1; // next index open in temp array
                            //  Copy smaller item from each subarray into temp until one
                            //  of the subarrays is exhausted
        while (first1 <= last1 && first2 <= last2)
        {
            if (data[first1].CompareTo(data[first2]) < 0)
            {
                temp[index] = data[first1];
                first1++;
            }
            else
            {
                temp[index] = data[first2];
                first2++;
            }
            index++;
        }

        //  Copy remaining elements from first subarray, if any
        while (first1 <= last1)
        {
            temp[index] = data[first1];
            first1++;
            index++;
        }
        //  Copy remaining elements from second subarray, if any
        while (first2 <= last2)
        {
            temp[index] = data[first2];
            first2++;
            index++;
        }
        //  Copy merged data into original array
        for (index = first; index <= last; index++)
            data[index] = temp[index];
    }
}