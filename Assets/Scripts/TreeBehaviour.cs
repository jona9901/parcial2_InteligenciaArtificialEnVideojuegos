using UnityEngine;

public class TreeBehaviour : MonoBehaviour
{
    public bool isMainTree = false;
    public bool isThirsty = false;
    public bool isPlage = false;
    public float timeToPollinize = 0;
    public float thirstness;

    private bool unlocked = false;

    // Start is called before the first frame update
    void Start()
    {
        thirstness = Random.Range(0, 20);
    }

    // Update is called once per frame
    void Update()
    {
        timeToPollinize -= Time.deltaTime;

        thirstness += Time.deltaTime;

        if (thirstness > 15)
        {
            isThirsty = true;
        }
        else
        {
            isThirsty = false;
        }
    }

    public void startMeeting()
    {

    }

    public void drink()
    {
        thirstness -= 20;
    }

    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Fairy")
        {
            timeToPollinize = Random.Range(0, 20);
        }
    }
}
