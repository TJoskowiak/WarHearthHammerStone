#pragma warning disable 0618

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SA.GameStates;


namespace SA
{
    public class GameManager : NetworkBehaviour
    {
        public State currentState;
        public GameObject CardPrefab;
        public SO.TransformVariable HandTransform;
        public GameElements.CardElementLogic HandLogic;

        private void Start()
        {
            Settings.gameManager = this;
            if (!isServer) {
                Settings.ChangeStateToOpponentControlState();


            } else {
                Settings.ChangeStateToPlayerControlState();

            }
        }

        private void Update()
        {
            currentState.Tick(Time.deltaTime);
        }

        public void SetState(State state)
        {
            currentState = state;
        }

        public void CreateHandCard()
        {
            GameObject obj = Instantiate(CardPrefab) as GameObject;
            CardViz viz = obj.gameObject.GetComponentInParent<CardViz>();
            viz.card_json_id = Random.Range(1, 6);
            CardInstance cardInstance = obj.AddComponent<CardInstance>();
            // CardInstance cardInstance = obj.gameObject.GetComponentInParent<CardInstance>();
            cardInstance.cardViz = viz;
            cardInstance.currentLogic = HandLogic;
            //obj.gameObject.GetComponent<CardViz>().DeserializeCard(4);
            obj.SetActive(true);
            obj.transform.SetParent(HandTransform.value.transform);
            obj.transform.localPosition = Vector3.zero;
            //obj.transform.rotation = Quaternion.Euler(0, 0, 180);
            obj.transform.localScale = Vector3.one;
            Debug.Log("Stworzylem");
        }


    }
}
