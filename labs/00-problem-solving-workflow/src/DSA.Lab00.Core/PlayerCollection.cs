using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace DSA.Lab00
{
    public sealed class PlayerCollection
    {
        private readonly List<Player> _players;

        public PlayerCollection(IEnumerable<Player> players)
        {
            if (players == null)
            {
                throw new ArgumentNullException(nameof(players));
            }

            _players = new List<Player>(players);
        }

        public Player? FindById(int id)
        {
            foreach (Player player in _players)
            {
                if (player.Id == id)
                {
                    return player;
                }
            }

            return null;
        }

        public Player? FindHighestScore(params int[] maxExclude)
        {
            Player? highestScoringPlayer = null;
            int highestScore = 0;

            if (_players.Count == 0)
                return null;

            foreach (Player player in _players)
            {
                if (player.Score > highestScore)
                {
                    if (maxExclude.Length > 0)
                    {
                        if (player.Score < maxExclude[0])
                        {
                            highestScore = player.Score;
                            highestScoringPlayer = player;
                        }
                    }
                    else
                    {
                        highestScore = player.Score;
                        highestScoringPlayer = player;
                    }
                        
                }
            }
            return highestScoringPlayer;
        }

        public bool ContainsNames(string[] names, params string[] excludeNames)
        {
            bool existsInCollection = false;

            if (_players.Count == 0)
                throw new ArgumentNullException(nameof(_players));

            foreach (Player player in _players)
            {
                for (int i = 0; i < names.Length; i++)
                {
                    if (player.Name == names[i] && excludeNames != null)
                    {
                        for (int j = 0; j < excludeNames.Length; j++)
                        {
                            if (player.Name != excludeNames[j])
                                existsInCollection = true;
                        }
                    }
                    else if (player.Name == names[i] && excludeNames == null)
                    {
                        for (int j = 0; j < names.Length; j++)
                        {
                            if (player.Name == names[i])
                            {
                                existsInCollection = true;
                            }
                        }
                    }
                }
            }

            return existsInCollection; ;
        }
    }
}
