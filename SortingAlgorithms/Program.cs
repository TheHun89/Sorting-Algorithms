/***********************************************************************************/
/* Algorithm Notes                                                                 */
/*=================================================================================*/
/* https://stackoverflow.com/questions/1933759/when-is-each-sorting-algorithm-used */
/***********************************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SortingAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList numbersInput = new ArrayList();

            Console.WriteLine("Enter numbers to add to your array:\nPress Enter again when complete.");
            string input = Console.ReadLine();

            while (!String.IsNullOrEmpty(input))
            {
                try
                {
                    numbersInput.Add(Convert.ToInt32(input));
                }
                catch (Exception e)
                {
                    Console.WriteLine("That value was not recognized as a number");
                }
                input = Console.ReadLine();

            }

            

            Console.WriteLine("Choose a sorting algorithm number:\n1 - Bubble\n2 - Insertion\n3 - Selection\n4 - Quick\n5 - Merge\n6 - Heap\n7 - Counting");
            string inputSort = Console.ReadLine();

            ArrayList originalInput = new ArrayList(numbersInput);

            while (!String.IsNullOrEmpty(inputSort))
            {
                ArrayList originalInput2 = new ArrayList(originalInput);
                switch (inputSort)
                {
                    case "1":
                        Console.WriteLine("You chose Bubble Sort.");
                        PrintArray("Before:  ", originalInput2);
                        BubbleSort(numbersInput);
                        PrintArray("After:  ", numbersInput);
                        break;
                    case "2":
                        Console.WriteLine("You chose Insertion Sort.");
                        PrintArray("Before:  ", originalInput2);
                        InsertionSort(numbersInput);
                        PrintArray("After:  ", numbersInput);
                        break;
                    case "3":
                        Console.WriteLine("You chose Selection Sort.");
                        PrintArray("Before:  ", originalInput2);
                        SelectionSort(numbersInput);
                        PrintArray("After:  ", numbersInput);
                        break;
                    case "4":
                        Console.WriteLine("You chose Quick Sort.");
                        PrintArray("Before:  ", originalInput2);
                        QuickSort(numbersInput, 0, numbersInput.Count - 1);
                        PrintArray("After:  ", numbersInput);
                        break;
                    case "5":
                        Console.WriteLine("You chose Merge Sort.");
                        PrintArray("Before:  ", originalInput2);
                        numbersInput = MergeSort(numbersInput);
                        PrintArray("After:  ", numbersInput);
                        break;
                    case "6":
                        Console.WriteLine("You chose Heap Sort.");
                        PrintArray("Before:  ", originalInput2);
                        QuickSort(numbersInput, 0, numbersInput.Count - 1);
                        PrintArray("After:  ", numbersInput);
                        break;
                    case "7":
                        Console.WriteLine("You chose Counting Sort.");
                        PrintArray("Before:  ", originalInput2);
                        QuickSort(numbersInput, 0, numbersInput.Count - 1);
                        PrintArray("After:  ", numbersInput);
                        break;
                    default:
                        Console.WriteLine("You entered an invalid value.");
                        break;
                }

                numbersInput = originalInput2;
                inputSort = Console.ReadLine();
            }
        }

        private static ArrayList BubbleSort (ArrayList a)
        {
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            for (int j = 0; j < a.Count; j++)
            {
                for (int i = 0; i < a.Count - 1; i++)
                {
                    if (Convert.ToInt32(a[i]) > Convert.ToInt32(a[i + 1]))
                    {
                        int temp = Convert.ToInt32(a[i]);
                        a[i] = a[i + 1];
                        a[i + 1] = temp;
                    }
                }
            }

            watch.Stop();
            Console.WriteLine($"Execution Time: {watch.Elapsed.TotalMilliseconds} ms");

            return a;
        }

        private static ArrayList InsertionSort(ArrayList a)
        {
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            for (int j = 0; j < a.Count - 1; j++)
            {
                for (int i = j + 1; i > 0; i--)
                {
                    if (Convert.ToInt32(a[i]) < Convert.ToInt32(a[i - 1]))
                    {
                        int temp = Convert.ToInt32(a[i]);
                        a[i] = a[i - 1];
                        a[i - 1] = temp;
                    }
                }
            }

            watch.Stop();
            Console.WriteLine($"Execution Time: {watch.Elapsed.TotalMilliseconds} ms");

            return a;
        }

        private static ArrayList SelectionSort(ArrayList a)
        {
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            for (int j = 0; j < a.Count - 1; j++)
            {
                int minVal = j;

                for (int i = j + 1; i < a.Count; i++)
                {
                    if (Convert.ToInt32(a[i]) < Convert.ToInt32(a[minVal]))
                    {
                        minVal = i;
                    }
                }

                if (minVal != j)
                {
                    int temp = Convert.ToInt32(a[minVal]);
                    a[minVal] = a[j];
                    a[j] = temp;
                }
            }

            watch.Stop();
            Console.WriteLine($"Execution Time: {watch.Elapsed.TotalMilliseconds} ms");

            return a;
        }

        /*Quick Sort - Start */
        private static void QuickSort(ArrayList a, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(a, left, right);
                //int pivot = RandomizedPivot(a, left, right);

                if (pivot > 1)
                {
                    QuickSort(a, left, pivot - 1);
                }
                if (pivot + 1 < right)
                {
                    QuickSort(a, pivot + 1, right);
                }
            }
        }

        private static int Partition(ArrayList a, int left, int right)
        {
            int pivot = Convert.ToInt32(a[left]);
            while (true)
            {
                while (Convert.ToInt32(a[left]) < pivot)
                {
                    left++;
                }

                while (Convert.ToInt32(a[right]) > pivot)
                {
                    right--;
                }
                
                if (left < right)
                {
                    if (Convert.ToInt32(a[left]) == Convert.ToInt32(a[right]))
                    {
                        return right;
                    }

                    int temp = Convert.ToInt32(a[left]);
                    a[left] = a[right];
                    a[right] = temp;
                }
                else
                {
                    return right;
                }
            }
        }
        /* Quick Sort - End */

        /* Merge Sort - Start */
        private static ArrayList MergeSort(ArrayList unsorted)
        {
            if (unsorted.Count <= 1)
                return unsorted;

            ArrayList left = new ArrayList();
            ArrayList right = new ArrayList();

            int middle = unsorted.Count / 2;
            for (int i = 0; i < middle; i++)  //Dividing the unsorted list
            {
                left.Add(unsorted[i]);
            }
            for (int i = middle; i < unsorted.Count; i++)
            {
                right.Add(unsorted[i]);
            }

            left = MergeSort(left);
            right = MergeSort(right);
            return Merge(left, right);
        }

        private static ArrayList Merge(ArrayList left, ArrayList right)
        {
            ArrayList result = new ArrayList();

            while (left.Count > 0 || right.Count > 0)
            {
                if (left.Count > 0 && right.Count > 0)
                {
                    if (Convert.ToInt32(left[0]) <= Convert.ToInt32(right[0]))  //Comparing First two elements to see which is smaller
                    {
                        result.Add(Convert.ToInt32(left[0]));
                        left.Remove(Convert.ToInt32(left[0]));      //Rest of the list minus the first element
                    }
                    else
                    {
                        result.Add(Convert.ToInt32(right[0]));
                        right.Remove(Convert.ToInt32(right[0]));
                    }
                }
                else if (left.Count > 0)
                {
                    result.Add(Convert.ToInt32(left[0]));
                    left.Remove(Convert.ToInt32(left[0]));
                }
                else if (right.Count > 0)
                {
                    result.Add(Convert.ToInt32(right[0]));
                    right.Remove(Convert.ToInt32(right[0]));
                }
            }
            return result;
        }
        /* Merge Sort - End */

        /* Heap Sort - Start */
        //private static void heapSort(ArrayList array)
        //{
        //    int heapSize = array.Count;

        //    buildMaxHeap(array);

        //    for (int i = heapSize - 1; i >= 1; i--)
        //    {
        //        swap(array, i, 0);
        //        heapSize--;
        //        sink(array, heapSize, 0);
        //    }
        //}

        //private static void buildMaxHeap(ArrayList array)
        //{
        //    int heapSize = array.Count;

        //    for (int i = (heapSize / 2) - 1; i >= 0; i--)
        //    {
        //        sink(array, heapSize, i);
        //    }
        //}

        //private static void sink(ArrayList array, int heapSize, int toSinkPos)
        //{
        //    if (getLeftKidPos(toSinkPos) >= heapSize)
        //    {
        //        // No left kid => no kid at all
        //        return;
        //    }


        //    int largestKidPos;
        //    bool leftIsLargest;

        //    if (getRightKidPos(toSinkPos) >= heapSize || array[getRightKidPos(toSinkPos)].CompareTo(array[getLeftKidPos(toSinkPos)]) < 0)

        //    {
        //            largestKidPos = getLeftKidPos(toSinkPos);
        //        leftIsLargest = true;
        //    }
        //    else
        //    {
        //        largestKidPos = getRightKidPos(toSinkPos);
        //        leftIsLargest = false;
        //    }



        //    if (array[largestKidPos].CompareTo(array[toSinkPos]) > 0)
        //    {
        //        swap(array, toSinkPos, largestKidPos);

        //        if (leftIsLargest)
        //        {
        //            sink(array, heapSize, getLeftKidPos(toSinkPos));
        //        }
        //        else
        //        {
        //            sink(array, heapSize, getRightKidPos(toSinkPos));
        //        }
        //    }

        //}

        //private static void swap(ArrayList array, int pos0, int pos1)
        //{
        //    var tmpVal = array[pos0];
        //    array[pos0] = array[pos1];
        //    array[pos1] = tmpVal;
        //}

        //private static int getLeftKidPos(int parentPos)
        //{
        //    return (2 * (parentPos + 1)) - 1;
        //}

        //private static int getRightKidPos(int parentPos)
        //{
        //    return 2 * (parentPos + 1);
        //}

        private static void printArray(ArrayList array)
        {

            foreach (var t in array)
            {
                Console.Write(' ' + t.ToString() + ' ');
            }

        }
        /* Heap Sort - End */

        private static void PrintArray(string message, ArrayList a)
        {
            string output = message;

            foreach (int i in a)
            {
                message = message + i + ", ";
            }
            message = message.Substring(0, (message.Length - 2));
            Console.WriteLine(message);
        }

        private static int RandomizedPivot(ArrayList a, int left, int right)
        {
            int random = new Random().Next(left, right);
            int pivot = Convert.ToInt32(a[random]);

            // swap
            a[random] = a[right];
            a[right] = pivot;
            return Partition(a, left, right);
        }
    }
}
