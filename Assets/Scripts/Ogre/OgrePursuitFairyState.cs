using UnityEngine;

public class OgrePursuitFairyState : OgreBaseState
{
    public override void EnterState(OgreStateManager ogre)
    {
        Debug.Log("Pursuit Fairy");
        ogre.move.OnSeek = false;
        ogre.move.TargetPursuit = ogre.fairy.gameObject;
        ogre.move.OnPursuit = true;
    }

    public override void UpdateState(OgreStateManager ogre)
    {
        
        float d = Vector3.Distance(ogre.fairy.gameObject.transform.position, ogre.transform.position);
        
        if (d < 1.2f)
        {
            ogre.move.OnPursuit = false;
            ogre.SwitchState(ogre.eatState);
        }
        
        /*if (d >= 4f)
        {
            
            ogre.move.OnPursuit = false;
            ogre.fairy = null;
            ogre.SwitchState(ogre.searchState);
        }
        else if (d <= 1.2f) ogre.SwitchState(ogre.eatState);*/
    }

    public override void OnCollisionEnter(OgreStateManager ogre, Collision other)
    {

    }
}
