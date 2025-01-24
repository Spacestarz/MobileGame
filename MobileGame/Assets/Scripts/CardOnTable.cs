using UnityEngine;

public class CardOnTable : MonoBehaviour
{
    private CardManager cardManager;
    private PlayerHand playerHand;
    private CardUIHandler cardUIHandler;
    private SpawnLocationsPlayer SpawnLocationsScript;

    void Start()
    {
        cardManager = GetComponent<CardManager>();
        playerHand = GetComponent<PlayerHand>();
        cardUIHandler = GetComponent<CardUIHandler>();
        SpawnLocationsScript = GetComponent<SpawnLocationsPlayer>();
    }

    void Update()
    {
        
    }

    public void DistributeCardTable()
    {

    }
}
