using Unity.Mathematics;
using UnityEngine;

public class PlayerCombatHandler : MonoBehaviour
{
    public GameObject mainProjectile;
    private PlayerInputHandler playerInputs;

    public void FireMainProjectile(Vector2 startPosition)
    {
        Instantiate(mainProjectile, startPosition, quaternion.identity);
    }

    void Start()
    {
        playerInputs = GetComponent<PlayerInputHandler>();
    }
    void Update()
    {
        if (playerInputs.GetFireInputPressed())
        {
            Vector2 projectileStartPosition = playerInputs.GetPointDirection();
            FireMainProjectile(projectileStartPosition);
        }
    }
}
