using AlgorithmShowcase.Interfaces;

namespace AlgorithmShowcase {
    /// <summary>
    /// Shell Sort is a sorting algorithm that starts by comparing and swapping elements 
    /// that are far apart, gradually reducing the gap between elements until the entire 
    /// list is sorted, resembling a series of insertion sort steps with diminishing gaps.
    /// 
    /// Shell Sort can be more efficient than simpler algorithms like Bubble Sort and 
    /// Insertion Sort, especially when dealing with medium-sized lists. It performs well 
    /// in situations where the input data is not already mostly sorted. The efficiency of 
    /// Shell Sort depends on the chosen gap sequence; some gap sequences may perform better 
    /// than others for specific types of data. Additionally, Shell Sort is an in-place sorting 
    /// algorithm, which means it doesn't require additional memory for sorting the elements.
    /// </summary>

    public class ShellSort : ISortingAlgorithm {
        /// <summary>
        /// Sorts an array of integers using the Shell Sort algorithm.
        /// </summary>
        /// <param name="data">The array to be sorted.</param>
        /// <returns>The sorted array.</returns>
        public int[] Sort(int[] data) {
            int n = data.Length;
            int gap = n / 2;
            Console.WriteLine($"Initial array: {String.Join(", ", data)}");
            // Start with a large gap and gradually reduce it
            while (gap > 0) {
                Console.WriteLine($"Gap: {gap}");
                // Perform insertion sort on subarrays defined by the gap
                for (int i = gap; i < n; i++) {
                    int temp = data[i];
                    int j = i;
                    // Shift elements towards right until the correct position is found
                    while (j >= gap && data[j - gap] > temp) {
                        data[j] = data[j - gap];
                        j -= gap;
                    }
                    data[j] = temp;
                    Console.WriteLine($"Intermediate array: {String.Join(", ", data)}");
                }
                // Reduce the gap for the next iteration
                gap /= 2;
            }
            Console.WriteLine("Sorting completed!");
            return data;
        }
    }
}
