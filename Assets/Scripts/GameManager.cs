using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager gameManager;
    public float score;
    public int damageZones;
    public bool isAlive;
    [Header("Timer")]
    public float timeRemaining;
    public float maxTime;

    void Awake()
    {
        if (gameManager == null)
        {
            gameManager = this;
        } else
        {
            Destroy(gameObject);
        }

        // Start with 0 zones
        damageZones = 0;
        // Start alive
        isAlive = true;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Set the timer to max time
        timeRemaining = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(damageZones);
        if ( damageZones == 0.0f )
        {
            Victory();
        }
        if ( !isAlive )
        {
            Defeat();
        }
    }

    public void ResetTimer()
    {
        timeRemaining = maxTime;
    }

    void Victory()
    {
        Debug.Log("Victory");
    }

    void Defeat()
    {
        Debug.Log("Defeat");
    }
}
