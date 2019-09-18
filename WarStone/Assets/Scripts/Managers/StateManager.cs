using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SA
{
    public class StateManager : MonoBehaviour
    {
        public GameStates.State PlayerControlState;
        public GameStates.State OpponentControlState;
        // Start is called before the first frame update
        void Start() {
            Settings.stateManager = this;
        }

        // Update is called once per frame
        void Update() {

        }
    }
}