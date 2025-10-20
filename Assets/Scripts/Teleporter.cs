using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Pawn player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Teleport
    void Teleport()
    {
        Debug.Log("Teleport function is being run");
        player.transform.position = transform.position;
    }
}
