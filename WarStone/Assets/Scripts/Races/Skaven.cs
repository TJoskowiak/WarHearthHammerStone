using System.Collections.Generic;
using UnityEngine;

namespace SA.Races 
{
    [CreateAssetMenu(menuName = "Race/Skaven")]
    public class Skaven : Race
    {
        private readonly List<int> _AvailableCards = new List<int>(15) { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7 };
        public override List<int> AvailableCards { get => _AvailableCards; }
    }
}
