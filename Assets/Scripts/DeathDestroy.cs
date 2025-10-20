using UnityEngine;

public class DeathDestroy : Death
{
    public override void Die()
    {
        // Destroy the game object
        Destroy(gameObject);
        GameManager.gameManager.isAlive = false;
    }
}
