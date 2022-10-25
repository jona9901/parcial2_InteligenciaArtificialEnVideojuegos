using UnityEngine;

public abstract class FairyBaseState
{
    public abstract void EnterState(FairyStateManager fairy);
    public abstract void UpdateState(FairyStateManager fairy);
    public abstract void OnCollisionEnter(FairyStateManager fairy, Collision other);
}