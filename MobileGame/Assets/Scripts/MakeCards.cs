using Unity.VisualScripting;
using UnityEngine;
using static Card;

public class MakeCards : MonoBehaviour
{
    public static MakeCards Instance;

    public GameObject _PrefabCard;

    public Sprite _backSprite;
    public Sprite _HeartSprite;
    public Sprite _DiamondSprite;
    public Sprite _SpadeSprite;
    public Sprite _CloverSprite;


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


    //wont use this anymore sr byee
    //public Card CreateCardObject(SuitEnum suit, RankEnum rank)
    //{
    //    Debug.Log("creating visual cards");
    //    GameObject prefabToInstantiate = null;

    //    switch (suit)
    //    {
    //        case SuitEnum.Hearts:
    //            prefabToInstantiate = _HeartsPreFab;
    //            break;

    //        case SuitEnum.Diamonds:
    //            prefabToInstantiate = _DiamondPrefab;
    //            break;

    //        case SuitEnum.Spades:
    //            prefabToInstantiate = _SpadePreFab;
    //            break;

    //        case SuitEnum.Clubs:
    //            prefabToInstantiate = _CloverPreFab;
    //            break;

    //        default:
    //            {
    //                return null;
    //            }
    //    }

    //    GameObject cardobject = Instantiate(prefabToInstantiate);

    //    Card cardComponent  = cardobject.GetComponent<Card>();

    //    if (cardComponent != null)
    //    {
    //        cardComponent.Initialize(suit, rank);
    //    }
    //    else
    //    {
    //        Debug.LogError("Card component not here wut");
    //    }
    //    return cardComponent;
    //}

    public Card MakeCard(SuitEnum suit, RankEnum rank)
    {
        Debug.Log("MakeUpsidedown card method");

        GameObject cardObject = Instantiate(_PrefabCard);

        Card cardComponent = cardObject.GetComponent<Card>();

        if (cardComponent != null)
        {
            // Initialize the Card component with the correct suit and rank
            cardComponent.Initialize(suit, rank);
        }
        else
        {
            Debug.LogError("Card component not here wut");
        }

        return cardComponent;
    }
}
