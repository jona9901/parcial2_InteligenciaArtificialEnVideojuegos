using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OgreStateManager : MonoBehaviour
{
    // variable declaration
    private string name = "Ogro 1";

    // Ogre State declarations
    OgreBaseState currentState;
    OgreDrinkState drinkState = new OgreDrinkState();
    OgreEatState eatState = new OgreEatState();
    OgrePursuitPlayerState pursuitPlayerState = new OgrePursuitPlayerState(); // globla state
    OgrePursuitFairyState pursuitFairyState = new OgrePursuitFairyState();
    OgreRestState restState = new OgreRestState();
    OgreSearchState searchState = new OgreSearchState();

    // Start is called before the first frame update
    void Start()
    {
        // Starting the state of the machine
        currentState = restState;
        // "this" is a reference to this exact MonoBehaviour script (CONTEXT)
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchState(OgreBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }
}
