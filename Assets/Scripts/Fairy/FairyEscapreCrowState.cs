using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairyEscapreCrowState : FairyBaseState
{
    public override void EnterState(FairyStateManager fairy)
    {
        fairy.move.OnFlee = true;
    }

    public override void UpdateState(FairyStateManager fairy)
    {
        if (Vector3.Distance(fairy.crow.gameObject.transform.position, fairy.gameObject.transform.position) > 2f)
        {
            fairy.move.OnFlee = false;
            fairy.SwitchState(fairy.fairyRest);
        }

    }

    public override void OnCollisionEnter(FairyStateManager fairy, Collider other)
    {

    }
}
