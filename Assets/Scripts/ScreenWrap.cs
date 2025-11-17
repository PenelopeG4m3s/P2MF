using UnityEngine;

public class ScreenWrap : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("X Position: " + transform.position.x);
        // checks if object is on the left border
        if ( GameManager.gameManager.boundaries[0] >= transform.position.x ) {
            transform.position = new Vector3(GameManager.gameManager.boundaries[2] - 1.0f, transform.position.y, 0.0f);
        }
        // checks if object is on the right border
        if ( GameManager.gameManager.boundaries[2] <= transform.position.x ) {
            transform.position = new Vector3(GameManager.gameManager.boundaries[0] + 1.0f, transform.position.y, 0.0f);
        }
        // checks if object is on the top border
        if ( GameManager.gameManager.boundaries[3] <= transform.position.y ) {
            transform.position = new Vector3(transform.position.x, GameManager.gameManager.boundaries[1] + 1.0f, 0.0f);
        }
        // checks if object is on the bottom border
        if ( GameManager.gameManager.boundaries[1] >= transform.position.y ) {
            transform.position = new Vector3(transform.position.x, GameManager.gameManager.boundaries[3] - 1.0f, 0.0f);
        }
    }
}
