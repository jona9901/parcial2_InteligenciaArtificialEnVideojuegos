using UnityEngine;

public class OgreSearchState : OgreBaseState
{
    public override void EnterState(OgreStateManager ogre)
    {
        Debug.Log("Search Fairy");
        int r = Random.Range(0, ogre.forest.Count);
        ogre.currentForest = ogre.forest[r];
        ogre.move.TargetSeek = ogre.currentForest;
        ogre.move.OnSeek = true;
    }

    public override void UpdateState(OgreStateManager ogre)
    {
        float distance = Vector3.Distance(ogre.currentForest.transform.position, ogre.transform.position);
        if (distance <= 2f)
        {
            ogre.move.OnSeek = false;
            ogre.move.OnWander = true;
        }
        if (ogre.fairy) ogre.SwitchState(ogre.pursuitFairyState);
    }

    public override void OnCollisionEnter(OgreStateManager ogre, Collision other)
    {

    }
}
