using AlgorithmShowcase.Interfaces;

namespace AlgorithmShowcase {
    /// <summary>
    /// Implementation of the Insertion Sort algorithm.
    /// </summary>
    public class InsertionSort : ISortingAlgorithm {
        /// <summary>
        /// Sorts an array of integers using the Insertion Sort algorithm.
        /// </summary>
        /// <param name="data">The array of integers to be sorted.</param>
        /// <returns>The sorted array of integers.</returns>
        public int[] Sort(int[] data) {
            Console.WriteLine("Sorting started...");
            // Insertion Sort builds the final sorted array one item at a time.
            // It iterates through the input array and for each element, it finds the correct position in the sorted part of the array.
            for (int i = 1; i < data.Length; i++) {
                int key = data[i];
                int j = i - 1;

                // Move elements of data[0..i-1], that are greater than key, to one position ahead of their current position
                while (j >= 0 && data[j] > key) {
                    Console.WriteLine($"Shifting element {data[j]} to the right");
                    data[j + 1] = data[j];
                    j--;
                }

                Console.WriteLine($"Placing element {key} at index {j + 1}");
                data[j + 1] = key;
            }

            Console.WriteLine("Sorting completed!");
            return data;
        }
    }
}