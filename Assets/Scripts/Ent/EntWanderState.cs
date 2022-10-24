using UnityEngine;

public class EntWanderState : EntBaseState
{
    public override void EnterState(EntStateManager ent)
    {
        // Call for wander code
        Debug.Log("Wander");
    }

    public override void UpdateState(EntStateManager ent)
    {
        if ( ent.isMeeting )
        {
            // Stop Wandering
            ent.SwitchState( ent.meetingState );
        }
    }

    public override void OnCollisionEnter(EntStateManager ent, Collision other)
    {
        TreeBehaviour tree = other.collider.GetComponent<TreeBehaviour>();

        if ( tree != null )
        {
            if ( tree.isThirsty )
            {
                ent.SwitchState( ent.searchState );
            } else if ( tree.isPlage )
            {
                ent.treeToFumigate = other.collider.gameObject;
                ent.SwitchState( ent.fumigateState );
            }
        }
    }
}
