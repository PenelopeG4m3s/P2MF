using UnityEngine;

public class Pawn : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float turnSpeed;
    public float turboSpeed;
    public float teleportSpeed;
    [Header("Components")]
    public Health health;
    public Death death;
    public Shooter shooter;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Load the health component from this object
        health = GetComponent<Health>();
        // Load the death component from this object
        death = GetComponent<Death>();
        // Load the shooterbullet component from this object
        shooter = GetComponent<Shooter>();
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

    public void Teleport ()
    {
        GameObject teleporter = GameObject.Find("Teleporter");
        transform.position = teleporter.transform.position;
    }

    public void ShootBullet ()
    {
        if ( shooter != null )
        {
            shooter.Shoot();
        }
    }
}
