using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName = "Card")]
    public class Card : ScriptableObject
    {
        public string cardName;
        public Sprite image;
        public int hp;
        public int weaponSkill;
        public int strength;
    }

}
