using AlgorithmShowcase.Interfaces;

namespace AlgorithmShowcase {
    /// <summary>
    /// Implementation of the Selection Sort algorithm.
    /// </summary>
    public class SelectionSort : ISortingAlgorithm {
        /// <summary>
        /// Sorts an array of integers using the Selection Sort algorithm.
        /// </summary>
        /// <param name="data">The array of integers to be sorted.</param>
        /// <returns>The sorted array of integers.</returns>
        public int[] Sort(int[] data) {
            Console.WriteLine("Sorting started...");
            // Selection Sort repeatedly finds the minimum element from the unsorted part of the array and places it at the beginning.
            for (int i = 0; i < data.Length - 1; i++) {
                int minIndex = i;

                // Find the index of the minimum element in the unsorted part of the array
                for (int j = i + 1; j < data.Length; j++) {
                    Console.WriteLine($"Comparing elements: {data[j]} and {data[minIndex]}");
                    if (data[j] < data[minIndex]) {
                        minIndex = j;
                    }
                }

                // Swap the minimum element with the first element of the unsorted part
                Console.WriteLine($"Swapping elements: {data[i]} and {data[minIndex]}");
                int temp = data[i];
                data[i] = data[minIndex];
                data[minIndex] = temp;
            }

            Console.WriteLine("Sorting completed!");
            return data;
        }
    }
}