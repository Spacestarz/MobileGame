using UnityEngine;

public class SpawnLocations : MonoBehaviour
{
    public static SpawnLocations instance;

    public GameObject discardLocation;
    public GameObject dropzoneLocationForCards;
    public Vector3 startAPlayer;
    public Vector3 StartBPlayer;

    private CardInstance cardInstance;



    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

}