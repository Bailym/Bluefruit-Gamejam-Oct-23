using System.Collections;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    public int timeToLiveSeconds = 5;
    public float travelSpeed = 20f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("DestroyProjectileAfterTimeToLive");
    }

    IEnumerator DestroyProjectileAfterTimeToLive()
    {
        yield return new WaitForSeconds(timeToLiveSeconds);
        Destroy(gameObject);
    }
}
