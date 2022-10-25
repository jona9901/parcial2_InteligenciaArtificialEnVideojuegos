using UnityEngine;

public class OgreRestState : OgreBaseState
{
    private float _staminaPeriod = 0.5f;
    private float _staminaActionTime = 0.0f;
    public override void EnterState(OgreStateManager ogre)
    {
        Debug.Log("Ogre is resting");
    }

    public override void UpdateState(OgreStateManager ogre)
    {
        if (Time.time > _staminaActionTime)
        {
            ogre.stamina++;
            _staminaActionTime += _staminaPeriod;
        }
        if (ogre.isHungry)
        {
            ogre.eat();
        }
        else if (ogre.isThirsty)
        {
            ogre.drink();
        }
    }

    public override void OnCollisionEnter(OgreStateManager ogre, Collision other)
    {

    }
}
