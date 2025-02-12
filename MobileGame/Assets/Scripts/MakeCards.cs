using UnityEngine;
using static Card;

public class MakeCards : MonoBehaviour
{
    public static MakeCards Instance;

    public CardInstance BackCardPreFab;
    public CardInstance HeartsPreFab;
    public CardInstance DiamondPrefab;
    public CardInstance CloverPreFab;
    public CardInstance SpadePreFab;



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




    public CardInstance CreateCardObject(Card card)
    {
        CardInstance prefabToInstantiate = null;

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

        CardInstance cardobject = Instantiate(prefabToInstantiate);

        cardobject.Init(card);

        return cardobject;
    }

    public CardInstance MakeUpsideDownCard(Card UpSideDownCard)
    {
        Debug.Log("MakeUpsidedown card method");
        CardInstance prefabToInstantiate = null;
        prefabToInstantiate = BackCardPreFab;

        CardInstance cardObject = Instantiate(prefabToInstantiate);

        cardObject.Init(UpSideDownCard);
        return cardObject;
    }
}
