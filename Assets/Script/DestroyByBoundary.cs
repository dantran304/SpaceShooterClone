using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour {

    void OnTriggerExit(Collider other)
    {
        //destroy everything that leave the trigger
        Destroy(other.gameObject);
    }
}
