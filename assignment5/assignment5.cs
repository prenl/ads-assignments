namespace assingment5;

public class Sorter
{

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

}