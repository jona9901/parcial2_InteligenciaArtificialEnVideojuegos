using UnityEngine;

public class FairyPollinateState : FairyBaseState
{
    public int pollenNumber;
    public TreeBehaviour depositPollen;
    public override void EnterState(FairyStateManager fairy)
    {
        fairy.move.TargetSeek = fairy.mainTree.gameObject;
        fairy.move.OnSeek = true;
    }

    public override void UpdateState(FairyStateManager fairy)
    {
        if (Vector3.Distance(fairy.mainTree.gameObject.transform.position, fairy.gameObject.transform.position) < 1.2f)
        {
            fairy.mainTree.treePollenRemaining += 0.1f;

            fairy.move.OnSeek = false;
        }
    }

    public override void OnCollisionEnter(FairyStateManager fairy, Collider other)
    {
        if (other.gameObject.tag == "MainTree")
        {
            fairy.SwitchState(fairy.fairyRest);

        }

    }
}
