using UnityEngine;
using static Card;

public class MakeCards : MonoBehaviour
{
    public static MakeCards Instance;

    public GameObject BackCardPreFab;
    public GameObject HeartsPreFab;
    public GameObject DiamondPrefab;
    public GameObject CloverPreFab;
    public GameObject SpadePreFab;



    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }




    public GameObject CreateCardObject(Card card)
    {
        GameObject prefabToInstantiate = null;

        switch (card._suit)
        {
            case SuitEnum.Hearts:
                prefabToInstantiate = HeartsPreFab;
                break;

            case SuitEnum.Diamonds:
                prefabToInstantiate = DiamondPrefab;
                break;

            case SuitEnum.Spades:
                prefabToInstantiate = SpadePreFab;
                break;

            case SuitEnum.Clubs:
                prefabToInstantiate = CloverPreFab;
                break;


            default:
                {

                    return null;
                }
        }

        GameObject cardobject = Instantiate(prefabToInstantiate);

        CardInstance cardComponent = cardobject.GetComponent<CardInstance>();
        cardComponent.Init(card);

        return cardobject;
    }

    public GameObject MakeUpsideDownCard(Card UpSideDownCard)
    {
        Debug.Log("MakeUpsidedown card method");
        GameObject prefabToInstantiate = null;
        prefabToInstantiate = BackCardPreFab;

        GameObject cardObject = Instantiate(prefabToInstantiate);

        CardInstance cardComponent = cardObject.GetComponent<CardInstance>();
        cardComponent.Init(UpSideDownCard);
        return cardObject;
    }
}
