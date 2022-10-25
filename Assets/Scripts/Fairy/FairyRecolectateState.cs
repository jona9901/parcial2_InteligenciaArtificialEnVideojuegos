using UnityEngine;

public class FairyRecolectateState : FairyBaseState
{

   public override void EnterState(FairyStateManager fairy)
    {

        Debug.Log("Buscando polen");
    }

    public override void UpdateState(FairyStateManager fairy)
    {
        Debug.Log("Estoy yendo por polen");

    }

    public override void OnCollisionEnter(FairyStateManager fairy, Collision other)
    {
        if (other.collider.gameObject.tag == "Tree")
        {
            Debug.Log("Tengo el máximo de polen!");
            fairy.collectPollen = 30;
            fairy.SwitchState(fairy.fairyRest);
        }

    }
}
