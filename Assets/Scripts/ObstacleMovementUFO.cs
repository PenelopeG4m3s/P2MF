using UnityEngine;

public class ObstacleMovementUFO : MonoBehaviour
{
    //public GameObject spaceship;
    //public float speed;

    // The target marker.
    public GameObject spaceship;

    // Angular speed in radians per sec.
    public float speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, spaceship.gameObject.transform.position, speed * Time.deltaTime);
    }
}
