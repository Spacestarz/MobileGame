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


    public Card MakeCard(SuitEnum suit, RankEnum rank)
    {
       // Debug.Log("MakeUpsidedown card method");

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
