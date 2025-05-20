using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmLib
{
    /// <summary>
    /// <summary>
    /// Implementation av olika sorteringsalgoritmer för generiska listor.
    /// </summary>
    /// <typeparam name="T">Typen på elementen som ska sorteras. Måste implementera IComparable<T>.</typeparam>

    public class SortingManager<T> : ISortingManager<T> where T : IComparable<T>
    {
        /// <summary>
        /// Sorterar listan med Bubble Sort-algoritmen.
        /// </summary>
        /// <param name="collection">Listan som ska sorteras.</param>
        public void BubbleSort(IList<T> collection)
        {
            for (int i = 0; i < collection.Count; i++)
            {
                for (int j = 0; j < collection.Count - 1; j++)
                {
                    if (collection[j].CompareTo(collection[j + 1]) == 1)
                    {
                        (collection[j], collection[j + 1]) = (collection[j + 1], collection[j]);
                    }
                }
            }
        }

        /// <summary>
        /// Sorterar listan med Merge Sort-algoritmen.
        /// </summary>
        /// <param name="collection">Listan som ska sorteras.</param>
        public void MergeSort(IList<T> collection)
        {
            int length = collection.Count;
            if (length <= 1)
            {
                return;
            }

            int middle = length / 2;
            List<T> leftC = new List<T>(middle);
            List<T> rightC = new List<T>(length - middle);

            int i = 0;
            int j = 0;

            for (; i < length; i++)
            {
                if (i < middle)
                {
                    leftC.Add(collection[i]);
                }
                else
                {
                   rightC.Add(collection[i]);
                    j++;
                }
            }
            MergeSort(leftC);
            MergeSort(rightC);
            Merge(leftC, rightC, collection);
        }

        private void Merge(IList<T> leftC, IList<T> rigtC ,IList<T> collection)
        {
            int leftSize = collection.Count / 2;
            int rightSize = collection.Count - leftSize;
            int i = 0, l = 0, r = 0;

            while (l < leftSize && r < rightSize)
            {
                if (leftC[l].CompareTo(rigtC[r]) <= 0)
                {
                    collection[i] = leftC[l];
                    i++;
                    l++;
                }
                else
                {
                    collection[i] = rigtC[r];
                    i++;
                    r++;
                }
            }

            while (l < leftSize)
            {
                collection[i] = leftC[l];
                i++;
                l++;
            }

            while (r < rightSize)
            {
                collection[i] = rigtC[r];
                i++;
                r++;
            }

        }
        /// <summary>
        /// Sorterar listan med Heap Sort-algoritmen.
        /// </summary>
        /// <param name="collection">Listan som ska sorteras.</param>
        public void HeapSort(IList<T> collection)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sorterar listan med Insertion Sort-algoritmen.
        /// </summary>
        /// <param name="collection">Listan som ska sorteras.</param>
        public void InsertionSort(IList<T> collection)
        {
            for (int i = 0; i < collection.Count; i++)
            {
                T key = collection[i];
                int j = i - 1;
                while (j >= 0 && collection[j].CompareTo(key) == 1)
                {
                    collection[j + 1] = collection[j];
                    j -= 1;
                }
                collection[j + 1] = key;
            }
        }

        /// <summary>
        /// Sorterar listan med Quick Sort-algoritmen.
        /// </summary>
        /// <param name="collection">Listan som ska sorteras.</param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        public void QuickSort(IList<T> collection, int start, int end)
        {
            if (start >= end)
            {
                return;
            }
            
            int pivotIndex = Partition(collection, start, end);
            QuickSort(collection, start, pivotIndex-1);
            QuickSort(collection, pivotIndex+1, end);
            
        }

        private int Partition(IList<T> collection, int start, int end)
        {
            T pivot = collection[end];
            int i = start - 1;

            for (int j = start; j <= end - 1; j++)
            {
                if (collection[j].CompareTo(pivot) <= 0)
                {
                    i++;
                    (collection[i], collection[j]) = (collection[j], collection[i]);
                } 
            }

            i++;
            (collection[i], collection[end]) = (collection[end], collection[i]);

            return i;
        }

        /// <summary>
        /// Sorterar listan med Selection Sort-algoritmen.
        /// </summary>
        /// <param name="collection">Listan som ska sorteras.</param>
        public void SelectionSort(IList<T> collection)
        {
            throw new NotImplementedException();
        }
    }
}
