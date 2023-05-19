using assingment5;
using NUnit.Framework;

namespace assignment5;

[TestFixture]
public class SorterTests
{
    private readonly Sorter _sorter = new Sorter();

    [Test]
    public void MergeSorting()
    {
        int[] arr = { 9, 8, 7, 6, 5, 4 };
        _sorter.MergeSort(arr);
        Assert.AreEqual(new int[] {4, 5, 6, 7, 8, 9} , arr);
    }

    [Test]
    public void MergeSorting2() 
    {
        int[] arr = { 23, 46, 13, 24, 7, 1 };
        _sorter.MergeSort(arr);
        Assert.AreEqual(new int[] { 1, 7, 13, 23, 24, 46 }, arr);
    }

    [Test]
    public void MergeSorting3() 
    {
        int[] arr = { -1, -3, 0, 54, 23 };
        _sorter.MergeSort(arr);
        Assert.AreEqual(new int[] { -3, -1, 0, 23, 54 }, arr);
    }

}
