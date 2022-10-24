using UnityEngine;

public class IrrigateTreeState : EntBaseState
{
    public override void EnterState(EntStateManager ent)
    {
        // Call for wander code
        Debug.Log("Irrigate State");
    }

    public override void UpdateState(EntStateManager ent)
    {
        if (ent.isMeeting)
        {
            // Stop Wandering
            ent.SwitchState(ent.meetingState);
        }
    }

    public override void OnCollisionEnter(EntStateManager ent, Collision other)
    {
    }
}
