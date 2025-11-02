using UnityEngine;

public class InstantiateTest : MonoBehaviour
{
    public GameObject prefabToCopy;
    public Controller controllerToConnect;

    public AudioSource myAudioSource;
    public AudioClip newAudioCLip;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetKeyDown(KeyCode.L) )
        {
            GameObject tempPawn;
            tempPawn = Instantiate(prefabToCopy, Vector3.zero, Quaternion.identity) as GameObject;
            if (tempPawn != null)
            {
                Pawn pawnComponent = tempPawn.GetComponent<Pawn>();
                if (pawnComponent != null)
                {
                    controllerToConnect.pawn = pawnComponent;
                }
            }
            Health healthComponent = tempPawn.GetComponent<Health>();
            if ( healthComponent != null )
            {
                healthComponent.maxHealth = 1000;
            }
        }  
    }
}
