using UnityEngine;

/*
 * Ogre base state for the State machine
 */


public abstract class OgreBaseState
{
    public abstract void EnterState(OgreStateManager ogre);
    public abstract void UpdateState(OgreStateManager ogre);
    public abstract void OnCollisionEnter(OgreStateManager ogre, Collision other);
}
