using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObstacleHealthUI : MonoBehaviour
{
    public Image healthImage;
    public GameObject obstacle;
    RectTransform m_RectTransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_RectTransform = GetComponent<RectTransform>();
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
        m_RectTransform.anchoredPosition = new Vector2(obstacle.transform.position.x, obstacle.transform.position.y);
        //healthImage.anchoredPosition = new Vector3(obstacle.transform.position.x,obstacle.transform.position.y,0.0f);
    }
}
