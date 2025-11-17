using UnityEngine;

public class AudioHum : MonoBehaviour
{
    public GameObject spaceship;
    public float pitch;
    public AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pitch = Mathf.Sqrt( ( (spaceship.transform.position.x - transform.position.x) * (spaceship.transform.position.x - transform.position.x) ) + ( (spaceship.transform.position.y - transform.position.y) * (spaceship.transform.position.y - transform.position.y) ) );
        //Debug.Log(pitch);
        //Debug.Log(spaceship.transform.position.x);
        if ( pitch <= 25.0f ){
            audioSource.pitch = Mathf.Abs((pitch/25)-1.0f);
            audioSource.volume = Mathf.Abs((pitch/25)-1.0f);
        } else {
            audioSource.pitch = 0.0f;
            audioSource.volume = 0.0f;
        }
    }
}
