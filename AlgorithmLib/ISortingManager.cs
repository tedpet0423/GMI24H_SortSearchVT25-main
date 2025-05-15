﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmLib
{
    /// <summary>
    /// Interface för sorteringsalgoritmer.
    /// T måste vara IComparable (jämförbar) för att kunna sorteras)
    /// </summary>
    internal interface ISortingManager<T> where T : IComparable<T>
    {
        /// <summary>
        /// Sorterar listan med hjälp av Bubble Sort.
        /// </summary>
        /// <param name="collection">Listan som ska sorteras.</param>
        /// //Notera i parameterlistan att vi jobbar med generiska typer. Jämför med pseudokoden som istället tar emot argument enligt typerna, t.ex. int array[]
        void BubbleSort(IList<T> collection);

        /// <summary>
        /// Sorterar listan med hjälp av Insertion Sort.
        /// </summary>
        /// <param name="collection">Listan som ska sorteras.</param>
        void InsertionSort(IList<T> collection);

        /// <summary>
        /// Sorterar listan med hjälp av Selection Sort.
        /// </summary>
        /// <param name="collection">Listan som ska sorteras.</param>
        void SelectionSort(IList<T> collection);

        /// <summary>
        /// Sorterar listan med hjälp av Merge Sort-algoritmen.
        /// </summary>
        /// <param name="collection">Listan som ska sorteras.</param>
        void MergeSort(IList<T> collection);

        /// <summary>
        /// Sorterar listan med hjälp av Heap Sort.
        /// </summary>
        /// <param name="collection">Listan som ska sorteras.</param>
        void HeapSort(IList<T> collection);

        /// <summary>
        /// Sorterar listan med hjälp av Quick Sort.
        /// </summary>
        /// <param name="collection">Listan som ska sorteras.</param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        void QuickSort(IList<T> collection, int start, int end);
        
  
    }
}
