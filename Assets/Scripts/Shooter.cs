using UnityEngine;

public abstract class Shooter : MonoBehaviour
{
    public virtual void Shoot( )
    {
        Debug.Log("You shoot a projectile (Abstract Class)");
    }
}
