using UnityEngine;

public class OgreEatState : OgreBaseState
{
    GameObject currentForest;
    public override void EnterState(OgreStateManager ogre)
    {
        Debug.Log("Eating fairy");
        ogre.eat();
        ogre.fairy = null;
        ogre.move.OnPursuit = false;
        ogre.move.TargetPursuit = null;
        ogre.StartCoroutine(ogre.sleep());
    }

    public override void UpdateState(OgreStateManager ogre)
    {

    }

    public override void OnCollisionEnter(OgreStateManager ogre, Collision other)
    {

    }
}
