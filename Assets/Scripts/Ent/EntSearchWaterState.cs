using UnityEngine;

public class EntSearchWaterState : EntBaseState
{
    public override void EnterState(EntStateManager ent)
    {
        // Search for water
        Debug.Log("Searching for water");
    }

    public override void UpdateState(EntStateManager ent)
    {
        if (ent.isMeeting)
        {
            // Stop search for water
            ent.SwitchState(ent.meetingState);
        }
    }

    public override void OnCollisionEnter(EntStateManager ent, Collision other)
    {
        if ( other.collider.tag == "Water")
        {
            ent.waterBucket = true;
            ent.SwitchState(ent.irrigateState);
        }
    }
}