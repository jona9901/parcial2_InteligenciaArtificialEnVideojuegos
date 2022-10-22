using UnityEngine;

public class OgreRestState : OgreBaseState
{
    public override void EnterState(OgreStateManager ogre)
    {
        Debug.Log(ogre.name + " is resting in cave");
    }

    public override void UpdateState(OgreStateManager ogre)
    {

    }

    public override void OnCollisionEnter(OgreStateManager ogre, Collision other)
    {

    }
}
