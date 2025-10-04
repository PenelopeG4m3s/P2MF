using UnityEngine;

public class RandomPosition : MonoBehaviour
{
    public float randomXPositionMin;
    public float randomXPositionMax;
    public float randomYPositionMin;
    public float randomYPositionMax;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetKeyDown(KeyCode.T) )
        {
            // TODO change colors
            transform.position = new Vector3(Random.Range( randomXPositionMin, randomXPositionMax), Random.Range( randomYPositionMin, randomYPositionMax), 0.0f);
        }
    }
}
