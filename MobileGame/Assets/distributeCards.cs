using UnityEngine;

public class distributeCards : MonoBehaviour
{
    private CardsCount CardsCount;
    private SpadeCards SpadeCards;
    private HeartCards HeartCards;
    private DiamondCards DiamondCards;
    private CloverCards CloverCards;
    
    void Start()
    {
       
        CardsCount = FindAnyObjectByType<CardsCount>();
        SpadeCards = GetComponent<SpadeCards>();
        HeartCards = GetComponent<HeartCards>();
        DiamondCards = GetComponent<DiamondCards>();
        CloverCards = GetComponent<CloverCards>();

        if (CardsCount == null || SpadeCards == null || HeartCards == null || DiamondCards == null || CloverCards == null)
        {
            Debug.Log("can't find");
        }
    }

  
    void Update()
    {
        
    }

    public void Distribute()
    {
        
        //Get from the overall cardcount
        //So it gets from the lists
    }
}
