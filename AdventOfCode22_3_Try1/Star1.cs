using System.Text.RegularExpressions;

namespace AdventOfCode22_3_Try1;

internal static class Star1
{
    public static int Run()
    {
        const int upperCaseLimit = 'Z' - 52;
        const int lowerCaseLimit = 'z' - 26;

        var packList = File.ReadAllText("Input/input.txt");
        var rucksacks = packList.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        var prioritySum = 0;

        foreach (var rucksack in rucksacks)
        {
            var compartment1 = rucksack[..(rucksack.Length / 2)];
            var compartment2 = rucksack[compartment1.Length..];
            
            var duplicate = Match(compartment1, compartment2);
            
            
            if (char.IsUpper(duplicate))
            {
                prioritySum += duplicate - upperCaseLimit;
            }
            else
            {
                prioritySum += duplicate - lowerCaseLimit ;
            }
        }

        return prioritySum;
        
        char Match(string compartment1, string compartment2)
        {
            foreach (var item1 in compartment1)
            {
                foreach (var item2 in compartment2)
                {
                    if (item1 == item2)
                    {
                        return item1;
                    }
                }
            }

            throw new Exception("Input should always have a match.");
        };
    }
}