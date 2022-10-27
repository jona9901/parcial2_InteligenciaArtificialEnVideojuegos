using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PondBehaviour : MonoBehaviour
{
    //public List<EntStateManager> ents = new List<EntStateManager>();
    [SerializeField]
    private int _seconds = 5;
    public int entsTotal = 0;
    public int entsInLake = 0;
    public bool isHavingMeeting = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ( entsInLake == entsTotal )
        {
            isHavingMeeting = true;
            havingMeeting();
        }
    }

    IEnumerator havingMeeting()
    {
        Debug.Log("Having meeting");

        yield return new WaitForSeconds(_seconds);

        isHavingMeeting = false;
        Debug.Log("Meeting finished");
    }
}
