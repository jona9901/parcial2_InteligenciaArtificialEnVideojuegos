using UnityEngine;

public class TreeBehaviour : MonoBehaviour
{
    public bool isMainTree = false;
    public bool isThirsty = false;
    public bool isPlage = false;
    public float timeToPollinize;
    public float thirstness;

    private bool unlocked = false;

    // Start is called before the first frame update
    void Start()
    {
        thirstness = Random.Range(0, 20);
        timeToPollinize = Random.Range(0, 20);
    }

    // Update is called once per frame
    void Update()
    {
        if (timeToPollinize > 0f ) timeToPollinize -= Time.deltaTime;

        thirstness += Time.deltaTime;

        if (thirstness >= 15) isThirsty = true;
        else isThirsty = false;

        if (timeToPollinize > 0) isPlage = false;
        else isPlage = true;
    }

    public void startMeeting()
    {

    }

    public void drink()
    {
        thirstness -= 100;
    }

    public void polinize()
    {
        timeToPollinize += 100;
    }

    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Fairy")
        {
            timeToPollinize = Random.Range(0, 20);
        }
    }
}
