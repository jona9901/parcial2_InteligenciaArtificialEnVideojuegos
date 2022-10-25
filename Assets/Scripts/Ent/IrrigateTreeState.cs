using UnityEngine;

public class IrrigateTreeState : EntBaseState
{
    public override void EnterState(EntStateManager ent)
    {
        // Call for wander code
        Debug.Log("Irrigate State");
        ent.move.TargetSeek = ent.treeToDrink.gameObject;
        ent.move.OnSeek = true;
    }

    public override void UpdateState(EntStateManager ent)
    {
        if (ent.isMeeting)
        {
            // Stop Wandering
            ent.move.OnSeek = false;
            ent.SwitchState(ent.meetingState);
        }
    }

    public override void OnCollisionEnter(EntStateManager ent, Collision other)
    {
        if (other.gameObject == ent.treeToDrink)
        {
            ent.move.OnSeek = false;
            ent.waterBucket = false;

            ent.treeToDrink.drink();
            if (ent.treeToDrink.isThirsty)
            {
                ent.SwitchState(ent.searchState);
            } else
            {
                ent.SwitchState(ent.wanderState);
            }
        }
    }
}
