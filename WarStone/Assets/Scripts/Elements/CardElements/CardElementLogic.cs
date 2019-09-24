using UnityEngine;

namespace SA.GameElements
{
    public abstract class CardElementLogic : ScriptableObject       
    {
        public abstract void onClick(CardInstance instance);

        public abstract void onHighlight(CardInstance instance);

        public abstract void onDrag(CardInstance instance);
    }
}
