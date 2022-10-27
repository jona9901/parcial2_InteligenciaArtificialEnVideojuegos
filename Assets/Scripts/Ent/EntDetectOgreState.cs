using UnityEngine;

public class EntDetectOgreState : EntBaseState
{
    public override void EnterState(EntStateManager ent)
    {
        Debug.Log("Oge detected");
    }

    public override void UpdateState(EntStateManager ent)
    {
        
    }

    public override void OnCollisionEnter(EntStateManager ent, Collider other)
    {
        OgreStateManager ogre = other.GetComponent<OgreStateManager>();
        if ( ogre )
        {
            ogre.kill();
        }
    }
}
