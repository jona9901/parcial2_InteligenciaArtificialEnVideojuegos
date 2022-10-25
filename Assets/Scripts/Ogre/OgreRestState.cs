using UnityEngine;

public class OgreRestState : OgreBaseState
{
    public override void EnterState(OgreStateManager ogre)
    {
        Debug.Log("Ogre is resting");
    }

    public override void UpdateState(OgreStateManager ogre)
    {
        if (ogre.stamina < 20)
        {
            ogre.stamina++;
        }
    }

    public override void OnCollisionEnter(OgreStateManager ogre, Collision other)
    {

    }
}
