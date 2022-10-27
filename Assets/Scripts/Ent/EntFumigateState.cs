using UnityEngine;

public class EntFumigateState : EntBaseState
{
    Vector3 treePosition;
    public override void EnterState(EntStateManager ent)
    {
        // go to ent.treeToFumigate position
        Debug.Log("Fumigating");
        ent.move.TargetSeek = ent.treeToFumigate.gameObject;
        ent.move.OnSeek = true;
        treePosition = ent.treeToFumigate.transform.position;
    }

    public override void UpdateState(EntStateManager ent)
    {
        float distance = Vector3.Distance(
            treePosition, ent.transform.position);
        if (distance <= 1.2f)
        {
            ent.treeToFumigate.gameObject.GetComponent<TreeBehaviour>().isPlage = false;
            ent.treeToFumigate.gameObject.GetComponent<TreeBehaviour>().polinize();
            ent.SwitchState(ent.wanderState);
        }
    }

    public override void OnCollisionEnter(EntStateManager ent, Collider other)
    {
        /*
        if (other.gameObject == ent.treeToFumigate.gameObject)
        {
            other.gameObject.GetComponent<TreeBehaviour>().isPlage = false;
            other.gameObject.GetComponent<TreeBehaviour>().polinize();
            ent.SwitchState(ent.wanderState);
        }
        */
    }
}
