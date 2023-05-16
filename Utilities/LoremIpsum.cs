using System.Text;

namespace Api.Utilities;

public class LoremIpsum
{
    public static string Generate(int minWords, int maxWords)
    {
        var words = new[]{"lorem", "ipsum", "dolor", "sit", "amet", "consectetuer",
            "adipiscing", "elit", "sed", "diam", "nonummy", "nibh", "euismod",
            "tincidunt", "ut", "laoreet", "dolore", "magna", "aliquam", "erat"};

        var rand = new Random();
        int numWords = rand.Next(maxWords - minWords) + minWords + 1;

        StringBuilder result = new StringBuilder();
        for (int w = 0; w < numWords; w++)
        {
            if (w > 0) 
                result.Append(" "); 
            result.Append(words[rand.Next(words.Length)]);
        }

        return result.ToString();
    }
}