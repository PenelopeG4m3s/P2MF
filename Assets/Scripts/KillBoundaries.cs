using UnityEngine;

public class KillBoundaries : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ( GameManager.gameManager.boundaries[0] >= transform.position.x ) {
            Destroy(gameObject);
        }
        // checks if object is on the right border
        if ( GameManager.gameManager.boundaries[2] <= transform.position.x ) {
            Destroy(gameObject);
        }
        // checks if object is on the top border
        if ( GameManager.gameManager.boundaries[3] <= transform.position.y ) {
            Destroy(gameObject);
        }
        // checks if object is on the bottom border
        if ( GameManager.gameManager.boundaries[1] >= transform.position.y ) {
            Destroy(gameObject);
        }
    }
}
