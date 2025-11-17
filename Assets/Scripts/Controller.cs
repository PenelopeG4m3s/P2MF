using UnityEngine;

public class Controller : MonoBehaviour
{
    public Pawn pawn;
    public Menu menu;
    public GameObject teleporter;
    private float mainSpeed;
    public KeyCode fire;
    public AudioSource myAudioSource;
    public AudioClip impact;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainSpeed = pawn.moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) )
        {
            mainSpeed = pawn.turboSpeed;
        }
        else
        {
            mainSpeed = pawn.moveSpeed;
        }

        // Check current game state
        if ( GameManager.gameManager.gameState == "game" ) {
            // Based on inputs, send commands to pawn
            MakeDescisions();
        }
        if ( GameManager.gameManager.gameState == "menu" ) {
            MakeMenuDescisions();
        }
    }

    private void MakeDescisions()
    {
        if (Input.GetKey(KeyCode.W))
        {
            /// TODO: Tell Pawn to Move Forward
            pawn.MoveForward( mainSpeed );
        }

        if (Input.GetKey(KeyCode.S))
        {
            /// TODO: Tell Pawn to Move Backward
            pawn.MoveBackward( mainSpeed );
        }

        if (Input.GetKey(KeyCode.A))
        {
            /// TODO: Tell Pawn to Turn Left
            pawn.RotateClockwise( pawn.turnSpeed );
        }

        if (Input.GetKey(KeyCode.D))
        {
            /// TODO: Tell Pawn to Turn Right
            pawn.RotateCounterClockwise( pawn.turnSpeed );
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            /// TODO: Tell Pawn to Teleport Upwards
            pawn.TeleportForward( pawn.teleportSpeed );
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            /// TODO: Tell Pawn to Teleport Backwards
            pawn.TeleportBackward( pawn.teleportSpeed );
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            /// TODO: Tell Pawn to Teleport Left
            pawn.TeleportLeft( pawn.teleportSpeed );
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            /// TODO: Tell Pawn to Teleport Right
            pawn.TeleportRight( pawn.teleportSpeed );
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            // TODO: Tell Pawn to Teleport to Teleporter
            pawn.Teleport();
        }

        if (Input.GetKeyDown(fire))
        {
            // TODO: Tell Pawn to fire a bullet
            pawn.ShootBullet();
            // Play Audio of bullet
            myAudioSource.PlayOneShot(impact, 1.0F);
        }
    }

    private void MakeMenuDescisions()
    {
        // Up
        if (Input.GetKeyDown(KeyCode.W)){
            menu.SelectUp();
        }

        // Down
        if (Input.GetKeyDown(KeyCode.S)){
            menu.SelectDown();
        }

        // Accept  
        if (Input.GetKeyDown(KeyCode.Space)){
            menu.Accept();
        }
    }
}
