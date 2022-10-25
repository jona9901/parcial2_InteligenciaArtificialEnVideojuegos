using UnityEngine;


public class FairySearchWaterState : FairyBaseState
{


    public override void EnterState(FairyStateManager fairy)
    {
        Debug.Log("Buscando agua");
    }
    
    public override void UpdateState(FairyStateManager fairy)
    {
        Debug.Log("Estoy yendo por agua");
    }

    public override void OnCollisionEnter(FairyStateManager fairy, Collision other)
    {
        if(other.collider.gameObject.tag == "Water")
        {
            Debug.Log("Estoy llena de agua!");
            fairy.thirstyFairy = 20;
            fairy.SwitchState(fairy.fairyRest);
        }
    }
}
