using UnityEngine;

public class DamageOnOverlap : MonoBehaviour
{

    public float damageDone;
    public bool instantKill;
    public GameObject immuneObject;
    public bool isObstacle;
    public AudioSource myAudioSource;
    public AudioClip impact;
    // public GameObject spaceship;
    public bool destroyOnOverlap;
    public GameObject HealthUI;
    bool check;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if ( !isObstacle )
        {
            // GameManager.gameManager.damageZones += 1;
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
            // GameManager.gameManager.damageZones -= 1;
        }
        if ( isObstacle && HealthUI != null)
        {
            Destroy(HealthUI);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Begin Debug");
        Debug.Log(this+" collided into "+other.gameObject);
        DamageOnOverlap otherObstacle = other.gameObject.GetComponent<DamageOnOverlap>();
        if (otherObstacle == null){
            Debug.Log("Other object does not have a damage on overlap component");
            check = false;
        } else {
            check = otherObstacle.isObstacle;
        }
        // check to make sure that both objects aren't obstacles
        if ( !isObstacle || !check )
        {
            if ( !instantKill )
            {
                if ( other.gameObject == null || other.gameObject != immuneObject )
                {
                    myAudioSource.PlayOneShot(impact, 1.0F);
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
                Debug.Log("Other: "+other.gameObject);
                if ( other.gameObject == null || other.gameObject != immuneObject )
                {
                    myAudioSource.PlayOneShot(impact, 1.0F);
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
            if ( destroyOnOverlap && other.gameObject != null && other.gameObject != immuneObject )
            {
                Destroy(gameObject);
            }
        }
    }
}
