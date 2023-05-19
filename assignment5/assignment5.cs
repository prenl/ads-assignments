namespace assingment5;

public class Sorter
{

    // Merge Sort

    public void MergeSort(int[] arr)
    {
        MergeSort(arr, 0, arr.Length - 1);
    }

    private void MergeSort(int[] arr, int start, int end)
    {
        if (arr.Length <= 1) return;

        int mid = arr.Length / 2;

        int[] left = new int[mid];
        int[] right = new int[arr.Length - mid];

        for (int i = 0; i < mid; i++)
            left[i] = arr[i];

        for (int i = mid; i < arr.Length; i++)
            right[i - mid] = arr[i];

        MergeSort(left, 0, left.Length - 1);
        MergeSort(right, 0, right.Length - 1);

        Merge(arr, left, right);
    }

    private void Merge(int[] arr, int[] left, int[] right)
    {
        int i = 0, j = 0, k = 0;

        while (i < left.Length && j < right.Length)
        {
            if (left[i] <= right[j])
                arr[k++] = left[i++];
            else
                arr[k++] = right[j++];
        }

        while (i < left.Length)
            arr[k++] = left[i++];

        while (j < right.Length)
            arr[k++] = right[j++];

    }


    // QuickSort

    public void QuickSort(int[] arr)
    {
        QuickSort(arr, 0, arr.Length - 1);
    }

    private void QuickSort(int[] arr, int start, int end)
    {
        if (start < end)
        {
            int pi = Partition(arr, start, end);
            QuickSort(arr, start, pi - 1);
            QuickSort(arr, pi, end);
        }
    }

    private int Partition(int[] arr, int start, int end)
    {
        int pivot = arr[end];
        int i = start - 1;

        for (int j = start; j < end; j++)
        {
            if (arr[j] < pivot)
            {
                i++;
                (arr[i], arr[j]) = (arr[j], arr[i]);
            }
        }

        (arr[i+1], arr[end]) = (arr[end], arr[i+1]);
        return (i + 1);
    }

}