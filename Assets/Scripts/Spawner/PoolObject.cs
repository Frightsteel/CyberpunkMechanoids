using UnityEngine;

namespace CyberpunkAwakening.Spawning
{
    public class PoolObject : MonoBehaviour
    {
        public void ReturnToPool()
        {
            gameObject.SetActive(false);
        }
    }
}