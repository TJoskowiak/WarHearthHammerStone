using UnityEngine;
using UnityEditor;

namespace SA
{
    public class ResourceHolder : MonoBehaviour
    {
        private int MAX_RESOURCE = 10;
        public int aviableResource = 10;

        private int nextIndex = 0;

        public void RemoveSingleResource()
        {
            RemoveResource(3);
        }

        public bool RemoveResource(int count)
        {
            if (aviableResource < count) return false;

            
            aviableResource -= count;
            while ((count--) > 0)
            {
                RemoveNextResource();
            }            
            return true;
            
        }


        public void RemoveNextResource()
        {
            if (nextIndex < MAX_RESOURCE)
            {
                transform.GetChild(nextIndex).gameObject.SetActive(false);
                nextIndex++;
            }

        }

    }
}
