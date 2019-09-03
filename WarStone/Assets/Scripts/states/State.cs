using UnityEngine;

namespace SA.GameStates
{
    [CreateAssetMenu(menuName ="State")]
    public class State : ScriptableObject
    {
        public Action[] actions; 

        public void Tick(float d)
        {
            foreach(Action action in actions)
            {
                action.Execute(d);               
            }
        }
    }
}
