using UnityEngine;

public class SpaceShipAudioListener : MonoBehaviour
{
    public GameObject spaceship;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(spaceship.gameObject.transform.position);
        transform.position = new Vector3(spaceship.gameObject.transform.position.x,spaceship.gameObject.transform.position.y,0.0f);
    }
}