using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObstacleHealthUI : MonoBehaviour
{
    public Image healthImage;
    public GameObject obstacle;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealth();
    }

    // Update the ui
    void UpdateHealth()
    {
        if (obstacle != null){
            // healthImage.rectTransform.sizeDelta = new Vector2(100, 500* (obstacle.GetComponent<Health>().currentHealth / obstacle.GetComponent<Health>().maxHealth) );
            // healthImage.fillAmount = new Vector2(100, 500* (GameManager.gameManager.timeRemaining / GameManager.gameManager.maxTime) );
            healthImage.fillAmount = obstacle.GetComponent<Health>().currentHealth / obstacle.GetComponent<Health>().maxHealth;
        } else {
            healthImage.fillAmount = 0;
        }
    }
}
