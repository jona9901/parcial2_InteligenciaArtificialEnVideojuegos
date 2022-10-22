using UnityEngine;

public class EntSearchWaterState : EntBaseState
{
    public override void EnterState(EntStateManager ent)
    {
        Debug.Log("HOla ent");
    }

    public override void UpdateState(EntStateManager ent)
    {

    }

    public override void OnCollisionEnter(EntStateManager ent, Collision other)
    {

    }
}
