using System.Text.RegularExpressions;

namespace AdventOfCode22_3_Try1;

internal static class Star2
{
    public static int Run()
    {
        const int upperCaseLimit = 'Z' - 52;
        const int lowerCaseLimit = 'z' - 26;

        var packList = File.ReadAllText("Input/input.txt");
        var rucksacks = packList.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        var prioritySum = 0;

        for (int i = 0; i < rucksacks.Length; i+=3)
        {
            var badge = Match(rucksacks[i], rucksacks[i+1], rucksacks[i+2]);

            if (char.IsUpper(badge)) 
            {
                prioritySum += badge - upperCaseLimit;
            }
            else
            {
                prioritySum += badge - lowerCaseLimit;
            }
        }
        

        return prioritySum;

        char Match(string rucksack1, string rucksack2, string rucksack3)
        {
            foreach (var item1 in rucksack1)
            {
                foreach (var item2 in rucksack2)
                {
                    foreach (var item3 in rucksack3)
                    {
                        if (item1 == item2 && item2 == item3)
                        {
                            return item1;
                        }
                    }
                }
            }

            throw new Exception("Input should always have a match.");
        };
    }
}