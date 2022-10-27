using UnityEngine;

public class EntMeetingState : EntBaseState
{
    private bool _inMeeting = false;
    // from pond behaviour
    private bool _isHavingMeeting = false;
    public override void EnterState(EntStateManager ent)
    {
        Debug.Log("Ent meeting");
        ent.move.TargetSeek = ent.pondGO;
        ent.move.OnSeek = true;
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

    public override void OnCollisionEnter(EntStateManager ent, Collider other)
    {
        if ( other.tag == "Water" )
        {
            ent.move.OnSeek = false;
            //ent.move.OnWander = true;
            ent.pond.entsInLake++;
            _inMeeting = true;
            _isHavingMeeting = ent.pond.isHavingMeeting;
        }
    }
}
