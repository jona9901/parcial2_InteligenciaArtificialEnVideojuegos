using UnityEngine;

public class CrowRestState : CrowBaseState
{
    

    public override void EnterState(CrowStateManager crow)
    {
        Debug.Log("Resting in cave");
        crow.move.TargetSeek = crow.cave;
        crow.move.OnSeek = true;
        float distanceC2C = Vector3.Distance(crow.gameObject.transform.position, crow.cave.transform.position); 
        if (distanceC2C <= 1.5)
        {
            crow.move.OnSeek = false;
        }     
    }

    public override void UpdateState(CrowStateManager crow)
    {

        if(crow.hunger <= 2)
        {
            Debug.Log("I'm hungry");
            crow.SwitchState(crow.eatState);
        } 
        if(crow.thirst <= 5)
        {
            Debug.Log("I'm thirsty");
            crow.SwitchState(crow.searchState);
        }

    }

    public override void OnCollisionEnter(CrowStateManager crow, Collision other)
    {

    }
}
