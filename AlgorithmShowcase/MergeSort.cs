using AlgorithmShowcase.Interfaces;

namespace AlgorithmShowcase {
    /// <summary>
    /// Implementation of the Merge Sort algorithm.
    /// </summary>
    public class MergeSort : ISortingAlgorithm {
        /// <summary>
        /// Sorts an array of integers using the Merge Sort algorithm.
        /// </summary>
        /// <param name="data">The array of integers to be sorted.</param>
        /// <returns>The sorted array of integers.</returns>
        public int[] Sort(int[] data) {
            Console.WriteLine("Sorting started...");
            Sort(data, 0, data.Length - 1);
            Console.WriteLine("Sorting completed!");
            return data;
        }

        private void Sort(int[] data, int left, int right) {
            if (left < right) {
                Console.WriteLine($"Sorting subarray from index {left} to {right}");
                int mid = (left + right) / 2;
                Sort(data, left, mid); // Sort the left subarray
                Sort(data, mid + 1, right); // Sort the right subarray
                Console.WriteLine($"Merging subarrays from index {left} to {mid} and from index {mid + 1} to {right}");
                Merge(data, left, mid, right); // Merge the sorted subarrays
            }
        }

        private void Merge(int[] data, int left, int mid, int right) {
            int n1 = mid - left + 1; // Length of the left subarray
            int n2 = right - mid; // Length of the right subarray

            int[] L = new int[n1]; // Temporary array for the left subarray
            int[] R = new int[n2]; // Temporary array for the right subarray

            Array.Copy(data, left, L, 0, n1); // Copy the elements of the left subarray to L
            Array.Copy(data, mid + 1, R, 0, n2); // Copy the elements of the right subarray to R

            int i = 0, j = 0, k = left;

            while (i < n1 && j < n2) {
                if (L[i] <= R[j]) {
                    data[k] = L[i]; // Place the smaller element from L into the merged array
                    i++;
                } else {
                    data[k] = R[j]; // Place the smaller element from R into the merged array
                    j++;
                }
                k++;
            }

            // Copy the remaining elements of L, if any
            while (i < n1) {
                data[k] = L[i];
                i++;
                k++;
            }

            // Copy the remaining elements of R, if any
            while (j < n2) {
                data[k] = R[j];
                j++;
                k++;
            }
        }
    }
}