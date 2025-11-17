using UnityEngine;

public class DeathObstacleBig : Death
{
    public float scoreAddition;
    public GameObject obstacle;
    public GameObject obstacleHealthUI;
    public int enemySpawnCount;

    public override void Die()
    {
        // Destroy the game object
        Destroy(gameObject);
        GameManager.gameManager.damageZones -= 1;
        GameManager.gameManager.score += scoreAddition;
        // loop for creating all of the different asteroids
        for ( int i = 0; i < (enemySpawnCount); i++ )
        {
            // create a temp obstacle
            GameObject obstacleTemp;
            // create the obstacles UI
            GameObject obstacleHealthTemp;
            // set the random position that the pawn will spawn at
            Vector3 obstaclePosition = new Vector3(gameObject.transform.position.x + Random.Range( -1.0f, 1.0f ),gameObject.transform.position.y + Random.Range( -1.0f, 1.0f ), 0.0f);
            // create the new obstacles health ui
            obstacleHealthTemp = Instantiate(obstacleHealthUI, obstaclePosition, Quaternion.identity) as GameObject;
            ObstacleHealthUI obstacleHealthComponent = obstacleHealthTemp.GetComponent<ObstacleHealthUI>();
            // create a new default obstacle
            obstacleTemp = Instantiate(obstacle, obstaclePosition, Quaternion.identity) as GameObject;
            DamageOnOverlap obstacleOverlap = obstacleTemp.GetComponent<DamageOnOverlap>();
            obstacleOverlap.HealthUI = obstacleHealthTemp;
            obstacleHealthComponent.obstacle = obstacleTemp;
            //obstacleTemp = Instantiate(obstacle, obstaclePosition, Quaternion.identity) as GameObject;
            //obstacleHealthComponent.obstacle = obstacleTemp;
            // track that a new obstacle has been created
            GameManager.gameManager.damageZones += 1;
        }
    }
}