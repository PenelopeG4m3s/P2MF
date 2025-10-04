using UnityEngine;

public class Pawn : MonoBehaviour
{
    public float moveSpeed;
    public float turnSpeed;
    public float turboSpeed;
    public float teleportSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveForward ( float moveSpeed )
    {
        // Change my pawns positionn -- in the forward direction, magnitude of moveSpeed
        // Get the transform component
        transform.position = transform.position + ( transform.up * moveSpeed * Time.deltaTime );
    }

    public void MoveBackward ( float moveSpeed )
    {
        transform.position = transform.position + ( -transform.up * moveSpeed * Time.deltaTime );
    }

    public void RotateClockwise ( float rotateValue )
    {
        transform.Rotate( 0.0f, 0.0f, rotateValue * Time.deltaTime );
    }

    public void RotateCounterClockwise(float rotateValue)
    {
        transform.Rotate( 0.0f, 0.0f, -rotateValue * Time.deltaTime );
    }

    public void TeleportForward (float teleportSpeed)
    {
        transform.position = transform.position + ( Vector3.up * teleportSpeed * Time.deltaTime );
    }

    public void TeleportBackward (float teleportSpeed)
    {
        transform.position = transform.position + ( -Vector3.up * teleportSpeed * Time.deltaTime );
    }

    public void TeleportLeft (float teleportSpeed)
    {
        transform.position = transform.position + ( Vector3.left * teleportSpeed * Time.deltaTime );
    }

    public void TeleportRight (float teleportSpeed)
    {
        transform.position = transform.position + ( Vector3.right * teleportSpeed * Time.deltaTime );
    }
}
