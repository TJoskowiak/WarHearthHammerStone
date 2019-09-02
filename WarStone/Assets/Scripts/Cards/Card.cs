using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

namespace SA
{
    [Serializable]
    public class CardContainer
    {
        public List<Card> cards;
    }

    [Serializable]
    public class Card
    {
        public int id;
        public string name;
        public string race;
        public string category;
        public int health;
        public int special;
        public int strength;
        public int cost;
        public string skill;
        public string gfx_path;
    }
}
