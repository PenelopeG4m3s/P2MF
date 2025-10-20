using UnityEngine;

public class DamageOnOverlap : MonoBehaviour
{

    public float damageDone;
    public bool instantKill;
    public GameObject immuneObject;
    public bool isObstacle;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if ( !isObstacle )
        {
            GameManager.gameManager.damageZones += 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy()
    {
        if ( !isObstacle )
        {
            GameManager.gameManager.damageZones -= 1;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if ( !instantKill )
        {
            if ( other.gameObject == null || other.gameObject != immuneObject )
            {
                Health otherHealth = other.gameObject.GetComponent<Health>();
                if ( otherHealth != null && otherHealth.enabled)
                {
                    Debug.Log("The collision trigger has been triggered, no instant kill, did damage to other object.");
                    Debug.Log(otherHealth);
                    otherHealth.TakeDamage(damageDone);
                }
                else
                {
                    Debug.Log("Health error prevention works");
                }
            }
        }
        else
        {
            if ( other.gameObject == null || other.gameObject != immuneObject )
            {
                Death death = other.gameObject.GetComponent<Death>();
                if ( death != null && death.enabled)
                {
                    Debug.Log( "death exists" + death );
                    death.Die();
                }
                else
                {
                    Debug.Log( "death does not exists" );
                }
            }
        }
    }
}
