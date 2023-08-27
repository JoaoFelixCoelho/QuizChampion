namespace QuizChampion.Extensions;

public static class GenericUtil
{
    public static IEnumerable<T> RandomizeCollection<T>(IEnumerable<T> collection)
    {
        Random rand = new Random();
        var shuffled = collection.OrderBy(_ => rand.Next());
        return shuffled;
    }
}

