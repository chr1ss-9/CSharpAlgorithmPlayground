
namespace MainApplication {
    internal class ConsoleHandler {
        private SortingAlgorithmShowcase sortingAlgorithmShowcase;

        public ConsoleHandler() {
            sortingAlgorithmShowcase = new SortingAlgorithmShowcase();
        }

        public void Run() {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            while (true) {
                PrintMenu();
                int choice = GetMenuChoice();
                // Set Array Values 
                if (choice == sortingAlgorithmShowcase.GetSortingAlgorithmCount() + 1) {
                    Console.WriteLine("Enter new numbers to be sorted, separated by spaces: ");
                    int[] data = GetInputData();
                    sortingAlgorithmShowcase.UpdateData(data);
                    continue;
                }
                // Quit Application
                if (choice == sortingAlgorithmShowcase.GetSortingAlgorithmCount() + 2) {
                    Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXX GAME OVER XXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
                    break;
                }
                // Non-Existing Choice 
                if (choice < 1 || choice > sortingAlgorithmShowcase.GetSortingAlgorithmCount()) {
                    Console.WriteLine("Invalid choice. Please try again.");
                    continue;
                }
                // Run Sorting Algorithm
                Console.WriteLine("\n******************Start Algorithm*********************");
                int[] sortedData = sortingAlgorithmShowcase.SortData(choice - 1);

                Console.WriteLine("Sorted data: " + FormatArray(sortedData));
                Console.WriteLine("********************Algorithm Finished*******************\n");
            }
        }
        private static string FormatArray(int[] sortedData) {
            return $"[{string.Join(", ", sortedData)}]";
        }
        private void PrintMenu() {
            Console.WriteLine("Welcome to Sorting Algorithm Showcase!");
            Console.WriteLine("Default Data: " + FormatArray(sortingAlgorithmShowcase.GetData()));
            List<Type> sortingAlgorithmTypes = sortingAlgorithmShowcase.GetSortingAlgorithmTypes();
            for (int i = 0; i < sortingAlgorithmTypes.Count; i++) {
                int optionNumber = i + 1;
                Console.WriteLine($"{optionNumber}. {sortingAlgorithmTypes[i].Name}");
            }
            int newArrayListOptionNumber = sortingAlgorithmShowcase.GetSortingAlgorithmCount() + 1;
            int quitOptionNumber = sortingAlgorithmShowcase.GetSortingAlgorithmCount() + 2;

            Console.WriteLine($"{newArrayListOptionNumber}. Enter new array");
            Console.WriteLine($"{quitOptionNumber}. Quit");
        }
        private int GetMenuChoice() {
            Console.Write("Enter your choice: ");
            string input = Console.ReadLine();
            int choice;
            while (!int.TryParse(input, out choice) || choice < 1 || choice > sortingAlgorithmShowcase.GetSortingAlgorithmCount() + 2) {
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
    }
}
