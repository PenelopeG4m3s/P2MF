using UnityEngine;

public abstract class Death : MonoBehaviour
{
    public virtual void Die( )
    {
        Debug.Log("Ugh... you got me.");
    }
}
