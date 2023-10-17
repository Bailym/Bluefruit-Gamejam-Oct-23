using Unity.Mathematics;
using UnityEngine;

public class PlayerCombatHandler : MonoBehaviour
{
    public GameObject mainProjectile;
    private ProjectileBehaviour mainProjectileBehaviour;
    private PlayerInputHandler playerInputs;

    void Start()
    {
        playerInputs = GetComponent<PlayerInputHandler>();
        mainProjectileBehaviour = mainProjectile.GetComponent<ProjectileBehaviour>();
    }

    void Update()
    {
        if (playerInputs.GetFireInputPressed())
        {
            float projectileAngleRadians = CalculateProjectileAngle();
            FireMainProjectile(transform.position, projectileAngleRadians);
        }
    }

    float CalculateProjectileAngle()
    {
        Vector2 mouseWorldPosition = FindObjectOfType<Camera>().ScreenToWorldPoint(playerInputs.GetPointDirection());
        Vector2 playerCurrentPosition = transform.position;
        return Mathf.Atan2(mouseWorldPosition.y - playerCurrentPosition.y, mouseWorldPosition.x - playerCurrentPosition.x);
    }

    public void FireMainProjectile(Vector2 startPosition, float travelAngleRadians)
    {
        GameObject projectileObject = Instantiate(mainProjectile, startPosition, quaternion.identity);
        projectileObject.GetComponent<ProjectileBehaviour>().SetprojectileOwnerId(gameObject.GetInstanceID());
        Rigidbody2D projectileObjectBody = projectileObject.GetComponent<Rigidbody2D>();
        projectileObjectBody.velocity = mainProjectileBehaviour.travelSpeed * new Vector2(Mathf.Cos(travelAngleRadians), Mathf.Sin(travelAngleRadians));
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            ProjectileBehaviour projectileObjectBehaviour = collision.gameObject.GetComponent<ProjectileBehaviour>(); 
            int projectileOwnerId = projectileObjectBehaviour.GetprojectileOwnerId();

            if (projectileOwnerId != gameObject.GetInstanceID())
            {
                Destroy(gameObject);
            }
        }

    }
}
