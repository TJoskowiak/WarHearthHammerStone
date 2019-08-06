//Unity inludes
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//System includes
using System.Collections;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.IO;
using System.Linq;


namespace SA
{
    public class CardViz : MonoBehaviour
    {
        //To be deleted. Or left. Not sure though what will call desrialize on card. Probably some battlefield controller that will also update the values on the cards.
        public int id=1;
        
        public TextMeshProUGUI cardName;
        public TextMeshProUGUI HP;     
        public TextMeshProUGUI strength;
        public TextMeshProUGUI weaponSkill;
        
        public Image image;

        private int _HealthPoints;
        private int _StrengthPoints;
        private int _WeaponSkillNum;
    
        public int HealthPoints { get => _HealthPoints; set => _HealthPoints = value; }  
        public int StrengthPoints { get => _StrengthPoints; set => _StrengthPoints = value; }
        public int WeaponSkillNum { get => _WeaponSkillNum; set => _WeaponSkillNum = value; }

        private void Start()
        {
            //To be deleted. The Deserialie will be called from the game controller during the bginning of the game. Can' pass any parameters through Start, Awake or Update
            DeserializeCard(id);
        }

        private void Update()
        {
            this.HP.text = this.HealthPoints.ToString();
            this.strength.text = this.StrengthPoints.ToString();
        }
        //TODO: Implementation function that retrieves data from JSON file//
        //Add JSON files in folder \WarStone\Assets\Data//
        public void DeserializeCard(int CardID)
        {
            var Deserializer = new DataContractJsonSerializer(typeof(Card));
            var CardData = new Card();

            //Reads the correct line from file and initialize new MemoryStream with the lione converted to bytes
            var StreamJSONLine = new MemoryStream(
                Encoding.UTF8.GetBytes(
                    File.ReadLines(@"Assets/Cards.json").Skip(CardID - 1).Take(1).First()));

            //Deserialize the card
            CardData = Deserializer.ReadObject(StreamJSONLine) as Card;
            //Closes memory stream
            StreamJSONLine.Close();

            //Initialize each field
            this.cardName.text = CardData.cardName;
            //Initialize ints for each of the card fields
            this.HealthPoints = CardData.hp;
            this.StrengthPoints = CardData.strength;
            this.WeaponSkillNum = CardData.weaponSkill;
            //Initialize corresponding TextMeshes
            this.HP.text = this.HealthPoints.ToString();
            this.strength.text = this.StrengthPoints.ToString();
            //this.weaponSkill.text = this.WeaponSkillNum.ToString();

            //Initialize the sprite for the card
            this.image.sprite = Resources.Load<Sprite>(CardData.imagePath);

        }



    }
}

