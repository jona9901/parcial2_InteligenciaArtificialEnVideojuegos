using UnityEngine;

public class EntFumigateState : EntBaseState
{
    public override void EnterState(EntStateManager ent)
    {
        // go to ent.treeToFumigate position
        Debug.Log("Fumigating");
    }

    public override void UpdateState(EntStateManager ent)
    {

    }

    public override void OnCollisionEnter(EntStateManager ent, Collision other)
    {

    }
}