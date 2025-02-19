using Unity.VisualScripting;
using UnityEngine;
using static Card;

public class MakeCards : MonoBehaviour
{
    public static MakeCards Instance;

    public GameObject _BackCardPreFab;
    public GameObject _HeartsPreFab;
    public GameObject _DiamondPrefab;
    public GameObject _CloverPreFab;
    public GameObject _SpadePreFab;

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

    public Card CreateCardObject(SuitEnum suit, RankEnum rank)
    {
        GameObject prefabToInstantiate = null;

        switch (suit)
        {
            case SuitEnum.Hearts:
                prefabToInstantiate = _HeartsPreFab;
                break;

            case SuitEnum.Diamonds:
                prefabToInstantiate = _DiamondPrefab;
                break;

            case SuitEnum.Spades:
                prefabToInstantiate = _SpadePreFab;
                break;

            case SuitEnum.Clubs:
                prefabToInstantiate = _CloverPreFab;
                break;

            default:
                {
                    return null;
                }
        }

        GameObject cardobject = Instantiate(prefabToInstantiate);

        Card cardComponent  = cardobject.GetComponent<Card>();

        if (cardComponent != null)
        {
            cardComponent.Initialize(suit, rank);
        }
        else
        {
            Debug.LogError("Card component not here wut");
        }

        return cardComponent;
    }

    public GameObject MakeUpsideDownCard(SuitEnum suit, RankEnum rank)
    {
        GameObject prefabToInstantiate;

        Debug.Log("MakeUpsidedown card method");
        prefabToInstantiate = _BackCardPreFab;

        GameObject cardObject = Instantiate(prefabToInstantiate);

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

        return cardObject;
    }
}
