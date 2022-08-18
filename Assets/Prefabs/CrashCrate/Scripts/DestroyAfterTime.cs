namespace ArionDigital
{
    using UnityEngine;

    public class DestroyAfterTime : MonoBehaviour
    {

        
        private void Start()
        {
            Invoke("DestroySelf", 0.5f);
        }

        
        void DestroySelf()
        {
            Destroy(transform.parent.gameObject);
        }

    }
}