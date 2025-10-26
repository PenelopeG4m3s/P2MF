using UnityEngine;

public class DeathObstacle : Death
{
    public float scoreAddition;

    public override void Die()
    {
        // Destroy the game object
        Destroy(gameObject);
        GameManager.gameManager.score += scoreAddition;
    }
}
