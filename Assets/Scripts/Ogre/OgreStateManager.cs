using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OgreStateManager : MonoBehaviour
{
    // variable declaration
    public int stamina = 20;
    public int hungre = 0;
    public int thirst = 0;
    public bool isHungry = true;
    public bool isThirsty = false;
    public GameObject pond;
    public GameObject cave;
    public GameObject player;
    public moveVelSimple move;
    public List<GameObject> forest;
    public GameObject currentForest;
    public FairyStateManager fairy;

    private float _staminaActionTime = 0.0f;
    private float _staminaPeriod = 2f;
    

    // Ogre State declarations
    OgreBaseState currentState;
    public OgreDrinkState drinkState = new OgreDrinkState();
    public OgreEatState eatState = new OgreEatState();
    public OgrePursuitPlayerState pursuitPlayerState = new OgrePursuitPlayerState(); // globla state
    public OgrePursuitFairyState pursuitFairyState = new OgrePursuitFairyState();
    public OgreRestState restState = new OgreRestState();
    public OgreSearchState searchState = new OgreSearchState();

    // Start is called before the first frame update
    void Start()
    {
        move = gameObject.GetComponent<moveVelSimple>();
        // Starting the state of the machine
        SwitchState(restState);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > _staminaActionTime)
        {
            stamina--;
            hungre++;
            thirst++;
            _staminaActionTime += _staminaPeriod;
        }

        if (hungre >= 20) isHungry = true;
        if (thirst >= 30) isThirsty = true;

        currentState.UpdateState(this);
    }

    public void SwitchState(OgreBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }

    public void eat()
    {
        hungre -= 20;
        if (hungre < 20) isHungry = false;
        Destroy(fairy.gameObject);
        sleep();
    }

    public void drink()
    {
        thirst -= 20;
        if (thirst < 30) isThirsty = false;
    }

    public void kill()
    {
        Destroy(this);
    }

    public IEnumerator sleep()
    {
        Debug.Log("Sleeping");

        yield return new WaitForSeconds(5);

        if (hungre >= 20) SwitchState(searchState);
        else if (stamina <= 20 && hungre < 20) SwitchState(restState);
        else if (thirst >= 20) SwitchState(drinkState);
    }

    public IEnumerator pursuit()
    {
        Debug.Log("Pursuiting");

        yield return new WaitForSeconds(2);

        float d = Vector3.Distance(transform.position, player.transform.position);
        if (d <= 1.2f)
        {
            Destroy(player);
            move.OnPursuit = false;
            SwitchState(restState);
        }
    }
}
