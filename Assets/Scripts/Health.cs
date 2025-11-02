using UnityEngine;

public class Health : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;
    public AudioSource myAudioSource;
    public AudioClip impact;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage( float amount )
    {
        // currentHealth = currentHealth - amount;
        currentHealth -= amount;
        myAudioSource.PlayOneShot(impact, 1.0F);
        if ( !IsAlive() )
        {
            currentHealth = 0;
            Die();
        }
    }

    public void Heal ( float amount )
    {
        currentHealth += amount;
        if ( currentHealth > maxHealth )
        {
            currentHealth = maxHealth;
        }
    }

    public void Die()
    {
        Death death = GetComponent<Death>();
        // If that death component exists
        if (death != null)
        {
            death.Die();
        }
    }

    public bool IsAlive()
    {
        if ( currentHealth > 0 )
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}