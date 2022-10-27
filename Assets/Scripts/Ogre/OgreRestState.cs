using UnityEngine;

public class OgreRestState : OgreBaseState
{
    private float _staminaPeriod = 0.5f;
    private float _staminaActionTime = 0.0f;
    public override void EnterState(OgreStateManager ogre)
    {
        Debug.Log("Ogre is resting");
        ogre.move.TargetSeek = ogre.cave;
        ogre.move.OnSeek = true;
    }

    public override void UpdateState(OgreStateManager ogre)
    { 
        float distance = Vector3.Distance(ogre.cave.transform.position, ogre.transform.position);
        if ( distance <= 1.2 )
        {
            //ogre.move.OnSeek = false;
            if (Time.time > _staminaActionTime)
            {
                ogre.stamina += 4;
                _staminaActionTime += _staminaPeriod;
            }
            if (ogre.isHungry) ogre.SwitchState(ogre.searchState);
            else if (ogre.isThirsty) ogre.SwitchState(ogre.drinkState);
             
        }
        
    }

    public override void OnCollisionEnter(OgreStateManager ogre, Collision other)
    {

    }
}
