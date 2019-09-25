using System.Collections.Generic;
using UnityEngine;

namespace SA.Races
{
    public abstract class Race : ScriptableObject
    {
        public abstract List<int> AvailableCards { get; }

        public List<int> ShuffleCards()
        {
            List<int> source = new List<int>(AvailableCards);
            List<int> output = new List<int>();
            System.Random generator = new System.Random();

            while (source.Count > 0)
            {
                int position = generator.Next(source.Count);
                output.Add(source[position]);
                source.RemoveAt(position);
            }
            return output;
        }
    }
}
