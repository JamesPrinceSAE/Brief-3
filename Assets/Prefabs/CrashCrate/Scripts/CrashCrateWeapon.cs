namespace ArionDigital
{
    using UnityEngine;

    public class CrashCrateWeapons : MonoBehaviour
    {
        [Header("Whole Create")]
        public MeshRenderer wholeCrate;
        public BoxCollider boxCollider;
        [Header("Fractured Crate")]
        public GameObject fracturedCrate;
        [Header("Audio")]
        public AudioSource crashAudioClip;

        private void OnTriggerEnter(Collider other)
        {
            wholeCrate.enabled = false;
            boxCollider.enabled = false;
            fracturedCrate.SetActive(true);
            crashAudioClip.Play();
        }

        [ContextMenu("Test")]
        public void Test()
        {
            wholeCrate.enabled = false;
            boxCollider.enabled = false;
            fracturedCrate.SetActive(true);
        }
    }
}