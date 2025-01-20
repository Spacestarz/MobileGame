using System;
using TMPro;
using UnityEngine;

public class CardUIHandler : MonoBehaviour
{
    private distributeCards distributeCards;
    private CardManager cardManager;

    private TextMeshProUGUI _rankText;

    public GameObject _heartPrefab;
    public GameObject _diamondPrefab;
    public GameObject _cloverPrefab;
    public GameObject _spadesPrefab;

    private TextMeshProUGUI rankOnCardText;
    
    void Start()
    {
       distributeCards = GetComponent<distributeCards>();
       cardManager = GetComponent<CardManager>();
      
    }

    public void GetCardUI(int rank, Card.SuitEnum suit)
    {
        //will get the rank and suit of the card 
        GameObject cardInstance = InstantiateCardPrefab(suit);

        _rankText = cardInstance.GetComponent<TextMeshProUGUI>();

        _rankText.text = GetRank(rank);

    }

    private GameObject InstantiateCardPrefab(Card.SuitEnum suit)
    {
        switch (suit)
        {
            case Card.SuitEnum.Hearts:
                return Instantiate(_heartPrefab, transform);

            case Card.SuitEnum.Diamonds:
                return Instantiate(_diamondPrefab, transform);

            case Card.SuitEnum.Spades:
                return Instantiate(_spadesPrefab, transform);

            case Card.SuitEnum.Clubs:
                return Instantiate(_cloverPrefab, transform);


            default:
                Debug.Log("idk which suit");
                return null;

        }
    }

    private string GetRank(int rank)
    {
        switch (rank)
        {
            case 1:
                return "A";

            case 11:
                return "J";

            case 12:
                return "Q";

            case 13:
                return "K";

            default:
                return rank.ToString();

        }
    }
}
