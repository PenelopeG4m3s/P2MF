using UnityEngine;

public class DeathDestroy : Death
{
    public override void Die()
    {
        // Destroy the game object
        //Destroy(gameObject);
        if ( GameManager.gameManager.lives == 1 ) {
            GameManager.gameManager.isAlive = false;
            GameManager.gameManager.DestroyObstacles();
            GameManager.gameManager.GameOver();
        }
        if ( GameManager.gameManager.lives >= 2 ) {
            Debug.Log("Life was lost");
            GameManager.gameManager.lives -= 1;
            GameManager.gameManager.DestroyObstacles();
            GameManager.gameManager.ResetGame();
        }
    }
}
