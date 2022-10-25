using UnityEngine;

public class FairyWanderState : FairyBaseState
{
    public override void EnterState(FairyStateManager fairy)
    {
        // Call for wander code
        Debug.Log("Wander");
    }

    public override void UpdateState(FairyStateManager fairy)
    {
        Debug.Log("Update State");
    }

    public override void OnCollisionEnter(FairyStateManager fairy, Collision other)
    {
        TreeBehaviour tree = other.collider.GetComponent<TreeBehaviour>();
    }
}
