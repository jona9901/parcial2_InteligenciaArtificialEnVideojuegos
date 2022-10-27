using UnityEngine;

public class OgreDrinkState : OgreBaseState
{
    public override void EnterState(OgreStateManager ogre)
    {
        Debug.Log("Drinking water");
        ogre.move.TargetSeek = ogre.pond;
        ogre.move.OnSeek = true;
    }

    public override void UpdateState(OgreStateManager ogre)
    {
        float d = Vector3.Distance(ogre.pond.transform.position, ogre.transform.position);
        if (d <= 1.2f)
        {
            ogre.drink();
            //ogre.thirst += 40;
            ogre.SwitchState(ogre.restState);
        }
    }

    public override void OnCollisionEnter(OgreStateManager ogre, Collision other)
    {

    }
}
