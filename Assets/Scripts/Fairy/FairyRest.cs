using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairyRest : FairyBaseState
{
    public override void EnterState(FairyStateManager fairy)
    {
        Debug.Log("Resting in tree");
    }

    public override void UpdateState(FairyStateManager fairy)
    {
        if(fairy.treePollinization <= 2)
        {
            Debug.Log("Polinizaré");
            fairy.SwitchState(fairy.pollinateState);
        }
        else if(fairy.thirstyFairy <= 2)
        {
            Debug.Log("Tengo sed");
            fairy.SwitchState(fairy.searchWaterState);
        }
        else if (fairy.collectPollen <= 2)
        {
            Debug.Log("Necesito más polen");
            fairy.SwitchState(fairy.recolectateState);
        }
    }

    public override void OnCollisionEnter(FairyStateManager fairy, Collision other)
    {

    }
}
