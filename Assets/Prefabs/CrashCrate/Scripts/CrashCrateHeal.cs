namespace ArionDigital
{
    using UnityEngine;

    public class CrashCrateHeal : MonoBehaviour
    {
        [Header("Whole Create")]
        public MeshRenderer wholeCrate;
        public BoxCollider boxCollider;
        [Header("Fractured Crate")]
        public GameObject fracturedCrate;
        [Header("Audio")]
        public AudioSource crashAudioClip;
        public CrateSpawn myCrateSpawn;

        private void OnTriggerEnter(Collider other)
        {
            wholeCrate.enabled = false;
            boxCollider.enabled = false;
            fracturedCrate.SetActive(true);
            CrateSpawn myCrateSpawn = FindObjectOfType<CrateSpawn>();
            myCrateSpawn.allCratesSpawnedIn.Remove(gameObject);
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