using UnityEngine;

public class CrowRestState : CrowBaseState
{
    
    
    public override void EnterState(CrowStateManager crow)
    {
        Debug.Log("Resting in cave");
        crow.move.TargetSeek = crow.cave;     
    }

    public override void UpdateState(CrowStateManager crow)
    {

        if(crow.hunger <= 2)
        {
            Debug.Log("I'm hungry");
            crow.SwitchState(crow.followState);
        } 
        if(crow.thirst <= 5)
        {
            Debug.Log("I'm thirsty");
            crow.SwitchState(crow.searchState);
        }

    }

    public override void OnCollisionEnter(CrowStateManager crow, Collider other)
    {
            if (other.gameObject.tag == "Cave")
            {
                crow.stamina += 1;
            }else
            {
                crow.stamina -= 0.1f;
            }
    }
}
