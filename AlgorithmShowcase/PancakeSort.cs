using AlgorithmShowcase.Interfaces;

namespace AlgorithmShowcase {
    /// <summary>
    /// Implementation of the Pancake Sort algorithm.
    /// Pancake Sort is a sorting algorithm that sorts an array by repeatedly flipping the order of the elements.
    /// It works by finding the largest element in the unsorted portion of the array and flipping the subarray 
    /// to move it to the beginning. The process is then repeated for the remaining unsorted portion until 
    /// the entire array is sorted.
    /// 
    /// Pancake Sort is an unusual and somewhat impractical sorting algorithm, and it doesn't typically exceed or 
    /// outperform other more commonly used sorting algorithms in terms of efficiency or practicality. It is primarily 
    /// used for educational purposes or as a fun and interesting way to explore sorting concepts.
    /// 
    /// Before Microsoft took off, a much younger Bill Gates spent some time thinking about pancakes, an untidy stack 
    /// of pancakes. He even published a mathematics paper about it. And academics say it was a fine peace of work.
    /// </summary>
    public class PancakeSort : ISortingAlgorithm {
        /// <summary>
        /// Sorts an array of integers using the Pancake Sort algorithm.
        /// </summary>
        /// <param name="data">The array of integers to be sorted.</param>
        /// <returns>The sorted array of integers.</returns>
        public int[] Sort(int[] data) {
            Console.WriteLine($"Sorting started...");

            for (int i = data.Length - 1; i >= 0; i--) {
                // Find the index of the maximum element in the unsorted portion of the array
                int maxIndex = FindMaxIndex(data, i);

                // If the maximum element is not already at the end, flip the elements to move it to the beginning
                if (maxIndex != i) {
                    Console.WriteLine($"Flipping subarray from index 0 to {maxIndex} (max) [{String.Join(", ", data)}]");
                    Flip(data, maxIndex);
                    Console.WriteLine($"Flipping subarray from index 0 to {i} (current) [{String.Join(", ", data)}]");
                    Flip(data, i);
                }
            }

            Console.WriteLine("Sorting completed!");
            return data;
        }

        private int FindMaxIndex(int[] data, int endIndex) {
            int maxIndex = 0;
            for (int i = 1; i <= endIndex; i++) {
                if (data[i] > data[maxIndex]) {
                    maxIndex = i;
                }
            }
            return maxIndex;
        }

        private void Flip(int[] data, int endIndex) {
            int start = 0;
            while (start < endIndex) {
                int temp = data[start];
                data[start] = data[endIndex];
                data[endIndex] = temp;
                start++;
                endIndex--;
            }
        }
    }
}