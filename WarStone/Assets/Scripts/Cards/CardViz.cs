using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

namespace SA
{
    public class CardViz : MonoBehaviour
    {
        public TextMeshProUGUI cardName;
        public TextMeshProUGUI HP;
        public TextMeshProUGUI strength;
        public TextMeshProUGUI weaponSkill;
        public Image image;

        public Card card;

        private void Start()
        {
            LoadCard(card);
        }

        //TODO: Implementation function that retrieves data from JSON file//
        //Add JSON files in folder \WarStone\Assets\Data//
        public void LoadCard(Card c)
        {

        }


    }
}

