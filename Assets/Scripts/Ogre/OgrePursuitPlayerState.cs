using UnityEngine;

/*
 * Ogre global state
 * Pursuit player state
 */

public class OgrePursuitPlayerState : OgreBaseState
{
    public override void EnterState(OgreStateManager ogre)
    {
        Debug.Log("Pursuiting Player");
        ogre.move.OnSeek = false;
        ogre.move.OnWander = false;

        ogre.move.TargetPursuit = ogre.player;
        ogre.move.OnPursuit = true;
        ogre.pursuit();
    }

    public override void UpdateState(OgreStateManager ogre)
    {

    }

    public override void OnCollisionEnter(OgreStateManager ogre, Collision other)
    {

    }
}
