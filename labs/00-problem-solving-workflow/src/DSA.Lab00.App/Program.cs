using System;
using System.Collections.Generic;
using DSA.Lab00;

List<Player> players = new()
{
    new Player(101, "Amina", 120),
    new Player(205, "Bo", 175),
    new Player(734, "Cleo", 160),
    new Player(910, "Dani", 105)
};

PlayerCollection collection = new(players);

Console.WriteLine("DSA Lab 0 - baseline");
Console.WriteLine();

Player? player = collection.FindById(910);
Player? highestScorePlayer = collection.FindHighestScore(120);

if (player != null)
{
    Console.WriteLine($"Found player {player.Name} with score {player.Score}.");
    Console.WriteLine($"How many players do you wanna check for?");
    int amountOfNamesToCheckFor = int.Parse(Console.ReadLine());
    string[] namesToCheck = new string[amountOfNamesToCheckFor];

    for (int i = 0; i < namesToCheck.Length; i++)
    {
        Console.WriteLine("Enter Name");
        string nameToArray = Console.ReadLine();
        if (nameToArray != string.Empty)
            namesToCheck[i] = nameToArray;
    }

    Console.WriteLine("Do you want to exclude any names?");
    string excludeCheck = Console.ReadLine();
    
    if (excludeCheck.ToLower() == "yes")
    {
        Console.WriteLine($"How many players do you wanna exclude from the check?");
        int amountOfNamesToExclude = int.Parse(Console.ReadLine());
        string[] namesToExclude = new string[amountOfNamesToExclude];

        for (int i = 0; i < namesToExclude.Length; i++)
        {
            Console.WriteLine("Enter Name");
            string nameToArray = Console.ReadLine();
            if (nameToArray != string.Empty)
                namesToExclude[i] = nameToArray;
        }
        Console.WriteLine(collection.ContainsNames(namesToCheck, namesToExclude));
    }
    else
    {
        Console.WriteLine(collection.ContainsNames(namesToCheck));
    }
        
}
if (highestScorePlayer != null)
{
    Console.WriteLine($"Found player {highestScorePlayer.Name} with highest score of {highestScorePlayer.Score}.");
}
else
{
    Console.WriteLine("Player not found.");
}

Console.WriteLine();
Console.WriteLine("Next: open the lab README and work through the tasks.");
