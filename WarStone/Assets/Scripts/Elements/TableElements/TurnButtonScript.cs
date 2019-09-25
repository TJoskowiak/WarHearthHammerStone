using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnButtonScript : MonoBehaviour
{
    public GameObject imageAttack;
    public GameObject imageHourglass;

    // Start is called before the first frame update
    void Start() {
        imageAttack.SetActive(true);
        imageHourglass.SetActive(false);
    }

    // Update is called once per frame
    void Update() {

    }
    public void ToggleState() {
        imageAttack.SetActive(!imageAttack.activeSelf);
        imageHourglass.SetActive(!imageHourglass.activeSelf);
    }
    public void SetState(SA.GameStates.State state) {
        if (state.name == "Player Control State") {
            imageAttack.SetActive(true);
            imageHourglass.SetActive(false);
        }
        else if (state.name == "Opponent Control State") {
            imageAttack.SetActive(false);
            imageHourglass.SetActive(true);
        }
    }
    public void OnButtonClick() {
        if (imageAttack.activeSelf) {

            var Player = GameObject.Find("LocalPlayer");
            var PlayerComp = Player.GetComponent<PlayerConnectionScript>();
            PlayerComp.CmdRoundOver();

            if (PlayerComp.isServer) {
                var opponentDeskComp = GameObject.Find("Player1CardsDown");
                var children = opponentDeskComp.GetComponentsInChildren<SA.CardViz>();
                foreach (var cardInstance in children) {
                    cardInstance.GetComponent<SA.CardViz>().cardMoved = false;
                }
            } else {
                var opponentDeskComp = GameObject.Find("Player2CardsDown");
                var children = opponentDeskComp.GetComponentsInChildren<SA.CardViz>();
                foreach (var cardInstance in children) {
                    cardInstance.GetComponent<SA.CardViz>().cardMoved = false;
                }
            }


            ToggleState();
        } else {

        }
    }
}
