namespace ArionDigital
{
    using UnityEngine;

    public class DestroyAfterTime : MonoBehaviour
    {
        private void Start()
        {
            Invoke("DestroySelf", 1.5f);
        }

        void DestroySelf()
        {
            Destroy(gameObject);
        }
    }
}