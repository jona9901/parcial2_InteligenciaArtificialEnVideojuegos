using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowEatState : CrowBaseState
{

    public override void EnterState(CrowStateManager crow)
    {
        Debug.Log("Persiguiendo Hada");
        crow.move.TargetSeek = crow.fairy;
        crow.move.OnSeek = true;

    }

    public override void UpdateState(CrowStateManager crow)
    {

        float distance = Vector3.Distance(crow.gameObject.transform.position, crow.fairy.transform.position);
        if (distance < 1.5)
        {
            crow.hunger += 20.0f;
            crow.move.OnSeek = false;
            Debug.Log("Hada Muerta");
            //crow.fairy.kill();
        }

        Debug.Log("Regresando a la cueva");
        if (crow.hunger > 2)
        {
            crow.move.OnSeek = false;
            crow.SwitchState(crow.restState);
        }
        //Si todavia tiene hambre
        if (crow.hunger <= 2)
        {
            crow.move.OnSeek = false;
            crow.SwitchState(crow.followState);

        }
            
    }

    public override void OnCollisionEnter(CrowStateManager crow, Collision other)
    {
        // FairyStateManager fairy = other.collider.gameObject.GetComponent<FairyStateManager>();
        // if(crow.fairy)
        // {
            
            
            
        // }
    }
}
