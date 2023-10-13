using System.Collections;
using UnityEngine;

public class ShurikenBehaviour : MonoBehaviour
{

    public int timeToLiveSeconds = 5;

    private Rigidbody2D shurikenBody;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("DestroyShurikenAfterTimeToLive");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    IEnumerator DestroyShurikenAfterTimeToLive()
    {
        yield return new WaitForSeconds(timeToLiveSeconds);
        Destroy(gameObject);
    }
}
