using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntCollisionDetection : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ogre")
        {
            Destroy(other.gameObject);
        }
    }
}
