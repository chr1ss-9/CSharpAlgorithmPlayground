using AlgorithmShowcase.Interfaces;

namespace AlgorithmShowcase {
    /// <summary>
    /// Implementation of the Bubble Sort algorithm.
    /// </summary>
    public class BubbleSort : ISortingAlgorithm {
        /// <summary>
        /// Sorts an array of integers using the Bubble Sort algorithm.
        /// </summary>
        /// <param name="data">The array of integers to be sorted.</param>
        /// <returns>The sorted array of integers.</returns>
        public int[] Sort(int[] data) {
            Console.WriteLine("Sorting started...");
            // Bubble Sort repeatedly compares adjacent elements and swaps them if they are in the wrong order.
            // This process is reminiscent of bubbles rising to the surface in a liquid, hence the name Bubble Sort.
            for (int i = 0; i < data.Length - 1; i++) { // Iterate over the array
                // Compare adjacent elements and swap if necessary
                for (int j = 0; j < data.Length - i - 1; j++) {
                    Console.WriteLine($"Comparing elements: {data[j]} and {data[j + 1]}");
                    if (data[j] > data[j + 1]) {
                        Console.WriteLine($"Swapping elements: {data[j]} and {data[j + 1]}");
                        int temp = data[j];
                        data[j] = data[j + 1];
                        data[j + 1] = temp;
                    }
                }
            }
            Console.WriteLine("Sorting completed!");
            return data;
        }
    }
}
