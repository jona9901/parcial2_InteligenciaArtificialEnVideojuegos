using UnityEngine;

public abstract class EntBaseState
{
    public abstract void EnterState(EntStateManager ent);
    public abstract void UpdateState(EntStateManager ent);
    public abstract void OnCollisionEnter(EntStateManager ent, Collider other);
}
