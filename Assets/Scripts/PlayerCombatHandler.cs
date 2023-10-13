using Unity.Mathematics;
using UnityEngine;

public class PlayerCombatHandler : MonoBehaviour
{
    public GameObject mainProjectile;
    private PlayerInputHandler playerInputs;

    public void FireMainProjectile()
    {
        Instantiate(mainProjectile, transform.position, quaternion.identity);
    }

    void Start()
    {
        playerInputs = GetComponent<PlayerInputHandler>();
    }
    void Update()
    {
        if (playerInputs.GetFireInputPressed())
        {
            FireMainProjectile();
        }
    }
}
