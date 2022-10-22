using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntStateManager : MonoBehaviour
{
    // Define Ent States
    EntBaseState currentState;
    EntWanderState wanderState = new EntWanderState();
    EntSearchWaterState searchState = new EntSearchWaterState();
    EntMeetingState meetingState = new EntMeetingState();
    EntFumigateState fumigateState = new EntFumigateState();
    EntDetectOgreState detectOgreState = new EntDetectOgreState();

    // Start is called before the first frame update
    void Start()
    {
        SwitchState(wanderState);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchState(EntBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }
}
