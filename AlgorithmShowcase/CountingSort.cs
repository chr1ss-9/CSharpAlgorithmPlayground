using AlgorithmShowcase.Interfaces;

namespace AlgorithmShowcase {
    /// <summary>
    /// Implementation of the Counting Sort algorithm.
    /// </summary>
    public class CountingSort : ISortingAlgorithm {
        /// <summary>
        /// Sorts an array of integers using the Counting Sort algorithm.
        /// </summary>
        /// <param name="data">The array of integers to be sorted.</param>
        /// <returns>The sorted array of integers.</returns>
        public int[] Sort(int[] data) {
            Console.WriteLine("Sorting started...");

            // Find the maximum element in the array
            int max = data[0];
            for (int i = 1; i < data.Length; i++) {
                if (data[i] > max) {
                    max = data[i];
                }
            }

            Console.WriteLine("Finding the maximum element: " + max);

            // Create a counting array of size max+1
            int[] count = new int[max + 1];

            // Count the occurrences of each element
            for (int i = 0; i < data.Length; i++) {
                count[data[i]]++;
            }

            Console.WriteLine("Counting occurrences of each element: " + string.Join(", ", count));

            // Calculate the cumulative count array
            for (int i = 1; i <= max; i++) {
                count[i] += count[i - 1];
            }

            Console.WriteLine("Calculating cumulative count array: " + string.Join(", ", count));

            // Create a temporary array to store the sorted output
            int[] sorted = new int[data.Length];

            // Build the sorted array
            for (int i = data.Length - 1; i >= 0; i--) {
                sorted[count[data[i]] - 1] = data[i];
                count[data[i]]--;
            }

            Console.WriteLine("Building the sorted array: " + string.Join(", ", sorted));

            // Copy the sorted array back to the original array
            Array.Copy(sorted, data, data.Length);

            Console.WriteLine("Sorting completed!");

            return data;
        }
    }
}