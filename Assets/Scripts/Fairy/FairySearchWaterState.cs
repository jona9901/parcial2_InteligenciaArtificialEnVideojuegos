using UnityEngine;
using System.Collections;

public class FairySearchWaterState : FairyBaseState
{
    public GameObject respawnPrefab;
    public GameObject[] respawns;

    public override void EnterState(FairyStateManager fairy)
    {
        fairy.move.TargetSeek = fairy.pondGO;
        fairy.move.OnSeek = true;
    }

    public override void UpdateState(FairyStateManager fairy)
    {
        if (Vector3.Distance(fairy.pondGO.gameObject.transform.position, fairy.gameObject.transform.position) < 1.5f)
        {
         Debug.Log("Estoy llena de agua!");
         fairy.thirstyFairy = fairy.thirstyFairy + 10f;
         fairy.move.OnSeek = false;
         fairy.SwitchState(fairy.fairyRest);
        
        }
    }

    public override void OnCollisionEnter(FairyStateManager fairy, Collider other)
    {

    }
}
