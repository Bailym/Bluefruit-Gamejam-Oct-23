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

    IEnumerator DestroyShurikenAfterTimeToLive()
    {
        yield return new WaitForSeconds(timeToLiveSeconds);
        Destroy(gameObject);
    }
}
