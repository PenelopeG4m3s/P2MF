using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    int randomDirection;
    public float speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.Rotate( 0.0f, 0.0f, Random.Range( 0.0f, 360.0f ) );
        Debug.Log("Obstacle "+GameManager.gameManager.damageZones+" Position: "+"( "+transform.position.x+", "+transform.position.y+")");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + ( transform.up * speed * Time.deltaTime );
    }
}
