using AlgorithmShowcase.Interfaces;
using System.Reflection;

internal class SortingAlgorithmShowcase {
    private int[] data = { 5, 2, 8, 1, 9 }; // Default array
    private List<Type> sortingAlgorithmTypes;

    public void UpdateData(int[] newData) {
        data = newData;
    }

    public int[] GetData() {
        return data;
    }

    public int[] SortData(int choice) {
        Type algorithmType = sortingAlgorithmTypes[choice];
        ISortingAlgorithm? sortAlgorithm = Activator.CreateInstance(algorithmType) as ISortingAlgorithm;

        int[] originalData = (int[])data.Clone();
        int[] sortedData = sortAlgorithm.Sort(originalData);

        return sortedData;
    }

    public int GetSortingAlgorithmCount() {
        return sortingAlgorithmTypes.Count;
    }

    public List<Type> GetSortingAlgorithmTypes() {
        Assembly algorithmShowcaseAssembly = typeof(ISortingAlgorithm).Assembly;

        sortingAlgorithmTypes = algorithmShowcaseAssembly.GetTypes()
            .Where(type => typeof(ISortingAlgorithm).IsAssignableFrom(type) && !type.IsInterface)
            .ToList();

        return sortingAlgorithmTypes;
    }
}