using UnityEngine;

public class EntMeetingState : EntBaseState
{
    private bool _inMeeting = false;
    // from pond behaviour
    private bool _isHavingMeeting = false;
    public override void EnterState(EntStateManager ent)
    {
        Debug.Log("Ent meeting");
        // Head to waterPond (transofrm)
    }

    public override void UpdateState(EntStateManager ent)
    {
        if (_inMeeting && !_isHavingMeeting )
        {
            if ( ent.pond.isHavingMeeting )
            {
                _isHavingMeeting = true;
                _inMeeting = false;
                ent.SwitchState(ent.wanderState);
            }
        }
    }

    public override void OnCollisionEnter(EntStateManager ent, Collision other)
    {
        if ( other.collider.tag == "Water" )
        {
            ent.pond.entsInLake++;
            _inMeeting = true;
            _isHavingMeeting = ent.pond.isHavingMeeting;
        }
    }
}
