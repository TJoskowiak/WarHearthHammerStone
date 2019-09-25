using System.Collections.Generic;
using UnityEngine;

namespace SA.Races
{
    [CreateAssetMenu(menuName = "Race/Dwarves")]
    public class Dwarves : Race
    {
        private readonly List<int> _AvailableCards = new List<int>(15) { 8, 8, 9, 9, 10, 10, 11, 11, 12, 12, 13, 13, 14, 14, 15 };
        public override List<int> AvailableCards { get => _AvailableCards; }
    }
}
