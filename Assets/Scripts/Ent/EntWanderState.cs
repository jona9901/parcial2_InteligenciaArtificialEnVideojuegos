using UnityEngine;

public class EntWanderState : EntBaseState
{
    public override void EnterState(EntStateManager ent)
    {
        // Call for wander code
        Debug.Log("Wander");
        ent.pathFollower.onWander = true;
    }

    public override void UpdateState(EntStateManager ent)
    {
        if ( ent.isMeeting )
        {
            // Stop Wandering
            ent.pathFollower.onWander = false;
            ent.SwitchState( ent.meetingState );
        }
    }

    public override void OnCollisionEnter(EntStateManager ent, Collision other)
    {
        TreeBehaviour tree = other.collider.GetComponent<TreeBehaviour>();

        if ( tree )
        {
            if ( tree.isThirsty )
            {
                ent.treeToDrink = other.gameObject.GetComponent<TreeBehaviour>();
                ent.SwitchState( ent.searchState );
            } else if ( tree.isPlage )
            {
                ent.treeToFumigate = other.collider.gameObject.GetComponent<TreeBehaviour>();
                ent.SwitchState( ent.fumigateState );
            }
        }
    }
}
