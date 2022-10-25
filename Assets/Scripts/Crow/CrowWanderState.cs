
using UnityEngine;

public class CrowWanderState : CrowBaseState
{
    public override void EnterState(CrowStateManager crow)
    {
        // Call for wander code
        Debug.Log("Wander");
    }

    public override void UpdateState(CrowStateManager crow)
    {
        Debug.Log("Update State");
    }

    public override void OnCollisionEnter(CrowStateManager crow, Collision other)
    {
        TreeBehaviour tree = other.collider.GetComponent<TreeBehaviour>();
    }
}
