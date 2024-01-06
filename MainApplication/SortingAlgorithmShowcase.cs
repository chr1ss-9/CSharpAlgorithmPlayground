using System.Reflection;
using AlgorithmShowcase.Interfaces;

namespace MainApplication {
    internal class SortingAlgorithmShowcase {
        private int[] data = { 5, 2, 8, 1, 9 }; // Default array
        private List<Type> sortingAlgorithmTypes;

        public void Run() {
            // Discover available sorting algorithms
            sortingAlgorithmTypes = GetSortingAlgorithmTypes();
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            while (true) {
                PrintMenu();
                int choice = GetMenuChoice();

                if (choice == sortingAlgorithmTypes.Count + 1) {
                    Console.WriteLine("Enter new numbers to be sorted, separated by spaces: ");
                    data = GetInputData();
                    continue;
                }
                if (choice == sortingAlgorithmTypes.Count + 2) {
                    Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXX GAME OVER XXXXXXXXXXXXXXXXXXXXXXXXXXXXX");                                        
                    break;
                }
                if (choice < 1 || choice > sortingAlgorithmTypes.Count) {
                    Console.WriteLine("Invalid choice. Please try again.");
                    continue;
                }
                Console.WriteLine("\n******************Start Algorithm*********************");
                Type algorithmType = sortingAlgorithmTypes[choice - 1];
                ISortingAlgorithm? sortAlgorithm = Activator.CreateInstance(algorithmType) as ISortingAlgorithm;

                int[] originalData = (int[])data.Clone();
                int[] sortedData = sortAlgorithm.Sort(originalData);

                Console.WriteLine("Sorted data: " + FormatArray(sortedData));
                Console.WriteLine("********************Algorithm Finished*******************\n");

            }
        }

        private static string FormatArray(int[] sortedData) {
            return $"[{string.Join(", ", sortedData)}]";
        }

        private void PrintMenu() {
            Console.WriteLine("Welcome to Sorting Algorithm Showcase!");
            Console.WriteLine("Default Data: " + FormatArray(data));
            for (int i = 0; i < sortingAlgorithmTypes.Count; i++) {
                int optionNumber = i + 1;
                Console.WriteLine($"{optionNumber}. {sortingAlgorithmTypes[i].Name}");
            }

            int newArrayListOptionNumber = sortingAlgorithmTypes.Count + 1;
            int quitOptionNumber = sortingAlgorithmTypes.Count + 2;

            Console.WriteLine($"{newArrayListOptionNumber}. Enter new array");
            Console.WriteLine($"{quitOptionNumber}. Quit");
        }

        private int GetMenuChoice() {
            Console.Write("Enter your choice: ");
            string input = Console.ReadLine();
            int choice;
            while (!int.TryParse(input, out choice) || choice < 1 || choice > sortingAlgorithmTypes.Count + 2) {
                Console.WriteLine("Invalid choice. Please try again.");
                Console.Write("Enter your choice: ");
                input = Console.ReadLine();
            }
            return choice;
        }

        private int[] GetInputData() {
            string input = Console.ReadLine();
            string[] inputNumbers = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int[] newData = new int[inputNumbers.Length];
            for (int i = 0; i < inputNumbers.Length; i++) {
                newData[i] = int.Parse(inputNumbers[i]);
            }

            return newData;
        }

        private List<Type> GetSortingAlgorithmTypes() {
            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            Assembly algorithmShowcaseAssembly = typeof(ISortingAlgorithm).Assembly;

            List<Type> sortingAlgorithmTypes = algorithmShowcaseAssembly.GetTypes()
              .Where(type => typeof(ISortingAlgorithm).IsAssignableFrom(type) && !type.IsInterface)
              .ToList();

            return sortingAlgorithmTypes;
        }
    }
}