using UnityEngine;

public class DeathObstacle : Death
{
    public float scoreAddition;

    public override void Die()
    {
        // Destroy the game object
        Destroy(gameObject);
        // gameObject.SetActive(false);
        GameManager.gameManager.damageZones -= 1;
        GameManager.gameManager.score += scoreAddition;
    }
}
