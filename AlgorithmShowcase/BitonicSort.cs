using AlgorithmShowcase.Interfaces;

namespace AlgorithmShowcase {
    /// <summary>
    /// Implementation of the Bitonic Sort algorithm.
    /// </summary>
    public class BitonicSort : ISortingAlgorithm {
        /// <summary>
        /// Sorts an array of integers using the Bitonic Sort algorithm.
        /// </summary>
        /// <param name="data">The array of integers to be sorted.</param>
        /// <returns>The sorted array of integers.</returns>
        public int[] Sort(int[] data) {
            Console.WriteLine("Sorting started...");

            // Call the recursive BitonicSortRecursive method to sort the entire array
            BitonicSortRecursive(data, 0, data.Length, true);

            Console.WriteLine("Sorting completed!");
            return data;
        }

        private void BitonicSortRecursive(int[] data, int start, int length, bool direction) {
            // Base case: If the length of the subarray is 1, it is already sorted
            if (length > 1) {
                int mid = length / 2;

                // Recursively sort the first half of the subarray in the same direction
                BitonicSortRecursive(data, start, mid, direction);

                // Recursively sort the second half of the subarray in the opposite direction
                BitonicSortRecursive(data, start + mid, mid, !direction);

                // Perform a bitonic merge on the entire subarray
                Console.WriteLine($"Merging subarray from index {start} to {start + length - 1} in {(direction ? "ascending" : "descending")} order");
                BitonicMerge(data, start, length, direction);
            }
        }

        private void BitonicMerge(int[] data, int start, int length, bool direction) {
            // Base case: If the length of the subarray is 1, it is already sorted
            if (length > 1) {
                int mid = length / 2;
                for (int i = start; i < start + mid; i++) {
                    // Compare and swap pairs of elements based on the desired direction
                    CompareAndSwap(data, i, i + mid, direction);
                }

                // Recursively perform bitonic merge on the first half of the subarray
                BitonicMerge(data, start, mid, direction);

                // Recursively perform bitonic merge on the second half of the subarray
                BitonicMerge(data, start + mid, mid, direction);
            }
        }

        private void CompareAndSwap(int[] data, int i, int j, bool direction) {
            // If the direction is ascending and the element at index i is greater than element at index j,
            // or if the direction is descending and the element at index i is smaller than element at index j,
            // then swap the elements to maintain the desired order
            if ((data[i] > data[j] && direction) || (data[i] < data[j] && !direction)) {
                Swap(data, i, j);
            }
        }

        private void Swap(int[] data, int i, int j) {
            // Swaps the elements at indices i and j in the array
            int temp = data[i];
            data[i] = data[j];
            data[j] = temp;
        }
    }
}