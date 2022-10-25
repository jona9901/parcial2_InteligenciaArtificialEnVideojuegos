using UnityEngine;

public class EntFumigateState : EntBaseState
{
    public override void EnterState(EntStateManager ent)
    {
        // go to ent.treeToFumigate position
        Debug.Log("Fumigating");
        ent.move.TargetSeek = ent.treeToFumigate.gameObject;
        ent.move.OnSeek = true;
    }

    public override void UpdateState(EntStateManager ent)
    {

    }

    public override void OnCollisionEnter(EntStateManager ent, Collision other)
    {
        if (other.collider.gameObject == ent.treeToFumigate.gameObject)
        {
            ent.treeToFumigate.isPlage = false;
            ent.SwitchState(ent.wanderState);
        }
    }
}
