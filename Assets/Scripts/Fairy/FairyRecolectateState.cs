using UnityEngine;

public class FairyRecolectateState : FairyBaseState
{
    public int randomNumber;
    public TreeBehaviour randomTree;

    public override void EnterState(FairyStateManager fairy)
    {
        randomNumber = Random.Range(0, fairy.trees.Count);
        randomTree = fairy.trees[randomNumber];

        fairy.move.TargetSeek = randomTree.gameObject;
        fairy.move.OnSeek = true;
    }

    public override void UpdateState(FairyStateManager fairy)
    {
        if (Vector3.Distance(randomTree.gameObject.transform.position, fairy.gameObject.transform.position) < 1.2f)
        {
            Debug.Log("Recolectado!");
            fairy.collectPollen = fairy.collectPollen + 1.5f;
            fairy.move.OnSeek = false;
            fairy.SwitchState(fairy.pollinateState);
        }
    }

    public override void OnCollisionEnter(FairyStateManager fairy, Collider other)
    {

    }
}
