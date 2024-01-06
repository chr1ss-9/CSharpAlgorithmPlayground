using AlgorithmShowcase.Interfaces;

namespace AlgorithmShowcase {
    /// <summary>
    /// Implementation of the Heap Sort algorithm.
    /// </summary>
    public class HeapSort : ISortingAlgorithm {
        /// <summary>
        /// Sorts an array of integers using the Heap Sort algorithm.
        /// </summary>
        /// <param name="data">The array of integers to be sorted.</param>
        /// <returns>The sorted array of integers.</returns>
        public int[] Sort(int[] data) {
            Console.WriteLine("Sorting started...");
            int n = data.Length;

            // Build the max heap
            for (int i = n / 2 - 1; i >= 0; i--) {
                Console.WriteLine($"Heapifying node at index {i}");
                Heapify(data, n, i);
            }

            // Extract elements from the heap one by one
            for (int i = n - 1; i >= 0; i--) {
                Console.WriteLine($"Moving root (max element) to index {i}");
                Swap(data, 0, i); // Move the root (max element) to the end
                Console.WriteLine($"Heapifying the reduced heap with size {i}");
                Heapify(data, i, 0); // Max heapify the reduced heap
            }

            Console.WriteLine("Sorting completed!");
            return data;
        }

        private void Heapify(int[] data, int n, int i) {
            int largest = i; // Initialize largest as root
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            // If left child is larger than root
            if (left < n && data[left] > data[largest]) {
                largest = left;
            }

            // If right child is larger than largest so far
            if (right < n && data[right] > data[largest]) {
                largest = right;
            }

            // If largest is not root
            if (largest != i) {
                Console.WriteLine($"Swapping elements at indices {i} and {largest}");
                Swap(data, i, largest);
                Console.WriteLine($"Recursively heapifying sub-tree rooted at index {largest}");
                Heapify(data, n, largest); // Recursively heapify the affected sub-tree
            }
        }

        private void Swap(int[] data, int i, int j) {
            int temp = data[i];
            data[i] = data[j];
            data[j] = temp;
        }
    }
}