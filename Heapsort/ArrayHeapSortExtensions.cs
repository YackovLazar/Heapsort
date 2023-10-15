namespace Heapsort;

public static class ArrayHeapSortExtensions
{
    public static T[] BuildMaxHeap<T>(this T[] array) where T : IComparable<T>
    {
        for (int i = array.Length / 2 - 1; i >= 0; i--)
        {
            MaxHeapify(array, i, array.Length);
        }

        return array;
    }

    public static T[] MaxHeapify<T>(this T[] array, int index, int heapSize) where T : IComparable<T>
    {
        int left = 2 * index + 1;
        int right = 2 * index + 2;
        int largest = index;

        if (left < heapSize && array[left].CompareTo(array[index]) > 0)
        {
            largest = left;
        }

        if (right < heapSize && array[right].CompareTo(array[largest]) > 0)
        {
            largest = right;
        }

        if (largest != index)
        {
            (array[index], array[largest]) = (array[largest], array[index]);

            MaxHeapify(array, largest, heapSize);
        }

        return array;
    }

    public static T[] ArrayHeapSort<T>(this T[] array) where T : IComparable<T>
    {
        array.BuildMaxHeap();

        for (int i = array.Length - 1; i >= 1; i--)
        {
            (array[0], array[i]) = (array[i], array[0]);

            array.MaxHeapify(0, i);
        }

        return array;
    }
}