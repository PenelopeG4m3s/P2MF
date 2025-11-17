using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public Image timerImage;
    public TMP_Text timerText;
    public TMP_Text scoreText;
    public TMP_Text enemiesText;
    public Image lifeOne;
    public Image lifeTwo;
    public Image lifeThree;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Timer
        GameManager.gameManager.ResetTimer();
        timerText.text = "Hello World";

        // Other
        if (GameManager.gameManager.gameState == "menu"){
            this.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Timer Schenanigans
        if ( GameManager.gameManager.timeRemaining > 0 ) {
            UpdateTimer();
        } else {
            GameManager.gameManager.timeRemaining = 0;
        }

        // Score
        UpdateScore();

        // Enemies
        UpdateEnemies();

        // Lives
        switch (GameManager.gameManager.lives){
            // 3 lives
            case 3:
                lifeOne.enabled = true;
                lifeTwo.enabled = true;
                lifeThree.enabled = true;
            break;
            // 2 lives
            case 2:
                lifeOne.enabled = true;
                lifeTwo.enabled = true;
                lifeThree.enabled = false;
            break;
            // 1 life
            case 1:
                lifeOne.enabled = true;
                lifeTwo.enabled = false;
                lifeThree.enabled = false;
            break;
            // 0 lives
            case 0:
                lifeOne.enabled = false;
                lifeTwo.enabled = false;
                lifeThree.enabled = false;
            break;
        }
    }

    // Timer
    void UpdateTimer ()
    {
        GameManager.gameManager.timeRemaining -= Time.deltaTime;
        timerImage.fillAmount = GameManager.gameManager.timeRemaining / GameManager.gameManager.maxTime;
        float displayTimeRemaining = Mathf.Floor(GameManager.gameManager.timeRemaining);
        timerText.text = "Time Remaining: " + GameManager.gameManager.timeRemaining;
    }

    // Score
    void UpdateScore ()
    {
        scoreText.text = "Score: " + GameManager.gameManager.score;
    }

    // Enemies
    void UpdateEnemies ()
    {
        enemiesText.text = "Enemies: " + GameManager.gameManager.damageZones;
    }
}
