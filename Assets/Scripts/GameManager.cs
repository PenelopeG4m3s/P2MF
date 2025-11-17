using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager gameManager;
    public float score;
    public int damageZones;
    public bool isAlive;
    public int lives;
    [Header("Timer")]
    public float timeRemaining;
    public float maxTime;
    [Header("General Stuff")]
    public string gameState;
    public string menuType;
    public GameObject spaceship;
    public Menu menu;
    public GameObject ui;
    //public GameObject obstacleone;
    //public GameObject obstacletwo;
    //public GameObject obstaclethree;
    //public GameObject obstaclefour;
    public int[] boundaries;
    [Header("Start Game Variables")]
    public int enemySpawnCount;
    public GameObject obstacle;
    public GameObject obstacleBig;
    public GameObject obstacleUFO;
    public GameObject obstacleHealthUI;
    [Header("RNG (Percentage Out of 100)")]
    public int obstacleBigRNG;
    public int obstacleUFORNG;
    public GameObject AudioListener;

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
        // Start with 3 lives
        lives = 3;
        // game starts at "menu" game state
        gameState = "menu";
        // game starts at "main" menu type
        menuType = "main";
        // screen border
        boundaries = new int[] 
        { 
            -35,     // X min
            -20,     // Y min
            35, // X max
            20  // Y max
        };
        AudioListener.GetComponent<SpaceShipAudioListener>().spaceship = spaceship;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Set the timer to max time
        timeRemaining = maxTime;
        spaceship.gameObject.SetActive(false);
        //obstacleone.gameObject.SetActive(false);
        //obstacletwo.gameObject.SetActive(false);
        //obstaclethree.gameObject.SetActive(false);
        //obstaclefour.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("Obstacles Remaining: "+damageZones);
        // Debug.Log(damageZones);
        // check if the state of the game is game
        if ( gameState == "game" )
        {
            // check if all of the damage zones have been destroyed
            if ( damageZones == 0.0f )
            {
                Victory();
            }
        
            // check if the player is still alive
            if ( !isAlive || timeRemaining <= 0)
            {
                Defeat();
            }

            //Debug.Log("Spaceship Position: "+spaceship.gameObject.transform.position);
        }
        
        //Debug.Log("Game State: "+gameState);
    }

    public void StartGame()
    {
        // disable the menu and enable the ui
        menu.gameObject.SetActive(false);
        ui.gameObject.SetActive(true);
        // enable all of the obstacles
        //obstacleone.gameObject.SetActive(true);
        //obstacletwo.gameObject.SetActive(true);
        //obstaclethree.gameObject.SetActive(true);
        //obstaclefour.gameObject.SetActive(true);
        // set general game variables
        lives = 3;
        ResetGame();
    }

    public void ResetGame()
    {
        // Enable the spaceship
        spaceship.gameObject.SetActive(true);
        spaceship.gameObject.transform.position = new Vector3( 0, 0, 0 );
        // set general game variables
        timeRemaining = maxTime;
        isAlive = true;
        damageZones = 0;
        Destroy(obstacle);
        Debug.Log("GameManager.cs line 112 gameState == "+gameState);
        gameState = "game";
        score = 0;
        // loop for creating all of the different asteroids
        for ( int i = 0; i < (enemySpawnCount); i++ )
        {
            string obstacleType;
            obstacleType = "Default";
            // check if the obstacle becomes BIG
            if (Random.Range(0.0f, 100.0f) <= obstacleBigRNG)
            {
                obstacleType = "Big";
            }
            // check if the obstacle becomes a UFO
            if (Random.Range(0.0f, 100.0f) <= obstacleUFORNG)
            {
                obstacleType = "UFO";
            }
            // create a temp obstacle
            GameObject obstacleTemp;
            // create the obstacles UI
            GameObject obstacleHealthTemp;
            // set the random position that the pawn will spawn at
            Vector3 obstaclePosition = new Vector3(Random.Range(-10.0f, 10.0f),Random.Range(-10.0f, 10.0f), 0.0f);
            if (obstaclePosition.x < 6 && obstaclePosition.x > -6 && obstaclePosition.y < 6 && obstaclePosition.y > -6){
                obstaclePosition.x = obstaclePosition.x + 20;
                obstaclePosition.y = obstaclePosition.y + 20;
            }
            // create the new obstacles health ui
            obstacleHealthTemp = Instantiate(obstacleHealthUI, obstaclePosition, Quaternion.identity) as GameObject;
            ObstacleHealthUI obstacleHealthComponent = obstacleHealthTemp.GetComponent<ObstacleHealthUI>();
            // figure out what type of obstacle is being created
            if ( obstacleType == "Default" )
            {
                // create a new default obstacle
                obstacleTemp = Instantiate(obstacle, obstaclePosition, Quaternion.identity) as GameObject;
                DamageOnOverlap obstacleOverlap = obstacleTemp.GetComponent<DamageOnOverlap>();
                obstacleOverlap.HealthUI = obstacleHealthTemp;
                obstacleHealthComponent.obstacle = obstacleTemp;
            }
            if ( obstacleType == "Big" )
            {
                // create a new big obstacle
                obstacleTemp = Instantiate(obstacleBig, obstaclePosition, Quaternion.identity) as GameObject;
                DamageOnOverlap obstacleOverlap = obstacleTemp.GetComponent<DamageOnOverlap>();
                obstacleOverlap.HealthUI = obstacleHealthTemp;
                obstacleHealthComponent.obstacle = obstacleTemp;
            }
            if ( obstacleType == "UFO" )
            {
                // create a new big obstacle
                obstacleTemp = Instantiate(obstacleUFO, obstaclePosition, Quaternion.identity) as GameObject;
                DamageOnOverlap obstacleOverlap = obstacleTemp.GetComponent<DamageOnOverlap>();
                obstacleOverlap.HealthUI = obstacleHealthTemp;
                obstacleHealthComponent.obstacle = obstacleTemp;
                obstacleTemp.GetComponent<ObstacleMovementUFO>().spaceship = spaceship;
                obstacleTemp.GetComponent<AudioHum>().spaceship = spaceship;
            }
            //obstacleTemp = Instantiate(obstacle, obstaclePosition, Quaternion.identity) as GameObject;
            //obstacleHealthComponent.obstacle = obstacleTemp;
            // track that a new obstacle has been created
            damageZones += 1;
        }
        Debug.Log("damageZones: "+damageZones);
    }

    public void DestroyObstacles()
    {
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");

        foreach (GameObject obstacle in obstacles)
        {
            Debug.Log("Found enemy: " + obstacle.name);
            Destroy(obstacle);
        }
    }

    public void GameOver()
    {
        spaceship.gameObject.transform.position = new Vector3( 0, 0, 0 );
        spaceship.gameObject.SetActive(false);
        gameState = "menu";
        menuType = "gameover";
        menu.gameObject.SetActive(true);
        menu.button = 0;
        ui.gameObject.SetActive(false);
    }

    public void ResetTimer()
    {
        timeRemaining = maxTime;
    }

    void Victory()
    {
        Debug.Log("Victory");
        spaceship.gameObject.transform.position = new Vector3( 0, 0, 0 );
        spaceship.gameObject.SetActive(false);
        gameState = "menu";
        menuType = "youwin";
        menu.gameObject.SetActive(true);
        menu.button = 0;
        ui.gameObject.SetActive(false);
    }

    void Defeat()
    {
        Debug.Log("Defeat");
    }
}
