using UnityEngine;

public class EntSearchWaterState : EntBaseState
{
    public override void EnterState(EntStateManager ent)
    {
        // Search for water
        Debug.Log("Searching for water");
        ent.move.TargetSeek = ent.pondGO;
        ent.move.OnSeek = true;
    }

    public override void UpdateState(EntStateManager ent)
    {
        float distance = Vector3.Distance(ent.pondGO.transform.position, ent.gameObject.transform.position);
        if (distance <= 1.2f) {
            ent.move.OnSeek = false;
            ent.waterBucket = true;
            ent.SwitchState(ent.irrigateState);
        }
    }

    public override void OnCollisionEnter(EntStateManager ent, Collider other)
    {

    }
}
