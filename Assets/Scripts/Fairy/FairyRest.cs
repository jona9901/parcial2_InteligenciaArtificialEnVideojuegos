using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairyRest : FairyBaseState
{
    public override void EnterState(FairyStateManager fairy)
    {
        fairy.move.TargetSeek = fairy.mainTree.gameObject;
        fairy.move.OnSeek = true;
    }

    public override void UpdateState(FairyStateManager fairy)
    {
        if (Vector3.Distance(fairy.mainTree.gameObject.transform.position, fairy.gameObject.transform.position) < 1.2f)
        {
            //fairy.sleep();
            fairy.move.OnSeek = false;
            Debug.Log("Necesito más polen");
            fairy.stamina = fairy.stamina + 1f;
            fairy.SwitchState(fairy.recolectateState);
        }
    }

    public override void OnCollisionEnter(FairyStateManager fairy, Collider other)
    {

    }
}
