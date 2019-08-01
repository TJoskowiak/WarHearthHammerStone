//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//namespace SA
//{
//    [CreateAssetMenu(menuName = "Card")]
//    public class Card : ScriptableObject
//    {
//        public string cardName;
//        public Sprite image;
//        public int hp;
//        public int weaponSkill;
//        public int strength;
//    }

//}

using System.Collections;
using System.Runtime.Serialization;
using UnityEngine;

namespace SA
{
    [DataContract]
    public class Card
    {
        [DataMember]
        public int id;
        [DataMember]
        public string cardName;
        [DataMember]
        public string imagePath;
        [DataMember]
        public int hp;
        [DataMember]
        public int weaponSkill;
        [DataMember]
        public int strength;
    }

}
