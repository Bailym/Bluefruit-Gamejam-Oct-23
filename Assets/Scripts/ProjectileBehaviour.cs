using System.Collections;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    public int timeToLiveSeconds = 5;
    public float travelSpeed = 20f;

    private int projectileOwnerId;

    void Start()
    {
        GameObject dividerObject = GameObject.FindGameObjectWithTag("Divider");
        Physics2D.IgnoreCollision(GetComponent<CircleCollider2D>(), dividerObject.GetComponent<BoxCollider2D>());
        StartCoroutine("DestroyProjectileAfterTimeToLive");
    }

    IEnumerator DestroyProjectileAfterTimeToLive()
    {
        yield return new WaitForSeconds(timeToLiveSeconds);
        Destroy(gameObject);
    }

    public void SetprojectileOwnerId(int id)
    {
        projectileOwnerId = id;
    }

    public int GetprojectileOwnerId()
    {
        return projectileOwnerId;
    }
}
