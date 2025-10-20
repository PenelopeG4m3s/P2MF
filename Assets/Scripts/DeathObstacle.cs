using UnityEngine;

public class DeathObstacle : Death
{
    public override void Die()
    {
        // Destroy the game object
        Destroy(gameObject);
    }
}
