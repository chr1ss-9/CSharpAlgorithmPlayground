using AlgorithmShowcase.Interfaces;

namespace AlgorithmShowcase {
    /// <summary>
    /// Implementation of the Quicksort algorithm.
    /// </summary>
    public class Quicksort : ISortingAlgorithm {
        /// <summary>
        /// Sorts an array of integers using the Quicksort algorithm.
        /// </summary>
        /// <param name="data">The array of integers to be sorted.</param>
        /// <returns>The sorted array of integers.</returns>
        public int[] Sort(int[] data) {
            Console.WriteLine("Sorting started...");
            Sort(data, 0, data.Length - 1);
            Console.WriteLine("Sorting completed!");
            return data;
        }

        private void Sort(int[] data, int low, int high) {
            if (low < high) {
                Console.WriteLine($"Sorting subarray from index {low} to {high}");
                int partitionIndex = Partition(data, low, high); // Partition the array
                Console.WriteLine($"Partitioning at index {partitionIndex}");
                Sort(data, low, partitionIndex - 1); // Sort the left subarray
                Sort(data, partitionIndex + 1, high); // Sort the right subarray
            }
        }

        private int Partition(int[] data, int low, int high) {
            int pivot = data[high]; // Choose the rightmost element as the pivot
            int i = low - 1; // Index of the smaller element

            for (int j = low; j < high; j++) {
                if (data[j] < pivot) {
                    i++;
                    Swap(data, i, j); // Swap elements at indices i and j
                }
            }

            Swap(data, i + 1, high); // Swap the pivot with the element at index i+1
            return i + 1; // Return the partition index
        }

        private void Swap(int[] data, int i, int j) {
            Console.WriteLine($"Swapping elements at indices {i} and {j}");
            int temp = data[i];
            data[i] = data[j];
            data[j] = temp;
        }
    }
}