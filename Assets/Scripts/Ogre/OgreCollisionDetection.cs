using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OgreCollisionDetection : MonoBehaviour
{
    OgreStateManager ogre;
    // Start is called before the first frame update
    void Start()
    {
        ogre = transform.parent.gameObject.GetComponent<OgreStateManager>();
        Debug.Log(ogre.stamina);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Fairy")
        {
            FairyStateManager fairy = other.GetComponent<FairyStateManager>();
            if (fairy)
            {
                if (!ogre.fairy) ogre.fairy = fairy;
            }
        }
        else if (other.gameObject.tag == "Player")
        {
            ogre.player = other.gameObject;
            ogre.SwitchState(ogre.pursuitPlayerState);
        }
    }
}
