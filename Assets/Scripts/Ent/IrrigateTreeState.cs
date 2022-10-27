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
        float distance = Vector3.Distance(ent.treeToDrink.transform.position,
            ent.transform.position);
        if ( distance <= 1.2f)
        {
            ent.move.OnSeek = false;
            ent.waterBucket = false;

            ent.treeToDrink.drink();
            if (ent.treeToDrink.isThirsty)
            {
                ent.SwitchState(ent.searchState);
            }
            else
            {
                ent.SwitchState(ent.wanderState);
            }
        }
    }

    public override void OnCollisionEnter(EntStateManager ent, Collider other)
    {
        /*
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
        } */
    }
}
