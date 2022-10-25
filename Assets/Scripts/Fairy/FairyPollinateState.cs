using UnityEngine;

public class FairyPollinateState : FairyBaseState
{
    public override void EnterState(FairyStateManager fairy)
    {
        Debug.Log("Buscando mi �rbol");

    }

    public override void UpdateState(FairyStateManager fairy)
    {
        Debug.Log("Estoy depositando el polen");

    }

    public override void OnCollisionEnter(FairyStateManager fairy, Collision other)
    {
        if (other.collider.gameObject.tag == "MainTree")
        {
            Debug.Log("Entregu� el polen");
            fairy.treePollinization = 10;
            fairy.SwitchState(fairy.fairyRest);
        }

    }
}
