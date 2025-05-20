using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmLib
{
    /// <summary>
    /// Implementation av olika sökalgoritmer för generiska listor.
    /// </summary>
    /// <typeparam name="T">Typen på elementen som ska sökas i. Måste implementera IComparable<T>.</typeparam>

    public class SearchingManager<T> : ISearchingManager<T> where T : IComparable<T>
    {
        /// <summary>
        /// Utför binär sökning i en sorterad lista.
        /// </summary>
        /// <param name="collection">Sorterad lista att söka i.</param>
        /// <param name="target">Värdet som söks.</param>
        /// <returns>Index för träff eller -1 om inget hittas.</returns>
        public int BinarySearch(IList<T> collection, T target)
        {
            int low = 0;
            int high = collection.Count - 1;
            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                if (collection[mid].Equals(target))
                {
                    return mid;
                }

                if (collection[mid].CompareTo(target) == -1)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }
            return -1;
        }

        /// <summary>
        /// Utför exponential search i en sorterad lista.
        /// </summary>
        /// <param name="collection">Sorterad lista att söka i.</param>
        /// <param name="target">Värdet som söks.</param>
        /// <returns>Index för träff eller -1 om inget hittas.</returns>
        public int ExponentialSearch(IList<T> collection, T target)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Utför interpolationssökning. Endast för typer som är int-kompatibla.
        /// </summary>
        /// <param name="collection">Sorterad lista av heltal.</param>
        /// <param name="target">Värdet som söks.</param>
        /// <returns>Index för träff eller -1 om inget hittas.</returns>
        public int InterpolationSearch(IList<T> collection, T target)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Utför jump search i en sorterad lista.
        /// </summary>
        /// <param name="collection">Sorterad lista att söka i.</param>
        /// <param name="target">Värdet som söks.</param>
        /// <returns>Index för träff eller -1 om inget hittas.</returns>
        public int JumpSearch(IList<T> collection, T target)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Utför linjär sökning i en lista.
        /// </summary>
        /// <param name="collection">Listan att söka i.</param>
        /// <param name="target">Värdet som söks.</param>
        /// <returns>Index för träff eller -1 om inget hittas.</returns>
        public int LinearSearch(IList<T> collection, T target)
        {
            for (int i = 0; i < collection.Count; i++)
            {
                if (collection[i].Equals(target))
                {
                    return i;
                }
                
            }
            return -1;
        }

        public int FibonacchiSearch(IList<T> collection, T target)
        {
            int length = collection.Count;
            int a = 0, b = 1, c = 1;

            while (c < length)
            {
                a = b;
                b = c;
                c = a + b;
            }

            int offset = -1;

            while (c > 1)
            {
                int x = a + offset;
                int y = length - 1;
                int i = Math.Min(x,y);

                if (collection[i].CompareTo(target) == -1)
                {
                    c = b;
                    b = a;
                    a = c - b;
                    offset = i;
                }
                else if (collection[i].CompareTo(target) == 1)
                {
                    c = a;
                    b = b - a;
                    a = c - b;
                }
                else
                {
                    return i;
                }
            }

            if (b != 0 && collection[offset + 1].Equals(target))
            {
                return offset + 1;
            }
            
            return -1;
        }

        public int LasVegasSearch(IList<T> collection, T target)
        {
            Random random = new Random();
            int low = 0;
            int high = collection.Count - 1;
            while (low <= high)
            {
                int mid = random.Next(low, high + 1);
                if (collection[mid].Equals(target))
                {
                    return mid;
                }

                if (collection[mid].CompareTo(target) == -1)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }
            
            return -1;
        }
        // JUST FOR FUN
        public int MonteCarloSearch(IList<T> collection, T target)
        {
            Random random1 = new Random();
            
            int randomIndex1 = random1.Next(0, collection.Count);
            int randomIndex2 = random1.Next(0, collection.Count);
            int randomIndex3 = random1.Next(0, collection.Count);
            
            if (collection[randomIndex1].Equals(target))
            {
                return randomIndex1;
            }
            if(collection[randomIndex2].Equals(target))
            {
                return randomIndex2;
            }
            return randomIndex3;
        }
    }
}
