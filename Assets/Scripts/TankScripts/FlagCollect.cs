using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagCollect : MonoBehaviour
{
    public class MeshRendererEnabler : MonoBehaviour
    {
        void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.name == "GoalFlag")
            {
                collision.gameObject.GetComponent<MeshRenderer>().enabled = true;
            }

        }
    }
}
