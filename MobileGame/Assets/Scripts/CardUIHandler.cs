using System;
using TMPro;
using UnityEngine;

public class CardUIHandler : MonoBehaviour
{
    private distributeCards distributeCards;
    private CardManager cardManager;

    private TextMeshPro _rankText;

    public GameObject _heartPrefab;
    public GameObject _diamondPrefab;
    public GameObject _cloverPrefab;
    public GameObject _spadesPrefab;

   public GameObject _cardInstance; //the instantiated card
    
    void Start()
    {
       distributeCards = GetComponent<distributeCards>();
       cardManager = GetComponent<CardManager>();
    }

    public void GetCardUI(int rank, Card.SuitEnum suit)
    {
        //will get the rank and suit of the card 
        _cardInstance = InstantiateCardPrefab(suit);

        if (_cardInstance != null)
        {
            //makes so the card script on the prefab gets the data
            CardScript cardScript = _cardInstance.GetComponent<CardScript>();
            cardScript.SetCardData(rank, suit);
        }
       
        TextMeshPro[] ranktexts = _cardInstance.GetComponentsInChildren<TextMeshPro>();
        
        string rankString = GetRank(rank); //if its above 10 it gets a q for queen etc
        
       foreach (TextMeshPro text in ranktexts)
        {
            text.text = rankString;
        }
    }

    private GameObject InstantiateCardPrefab(Card.SuitEnum suit)
    {
       // Debug.Log("getting the prefab look fab");
        switch (suit)
        {
            case Card.SuitEnum.Hearts:
                return Instantiate(_heartPrefab); 

            case Card.SuitEnum.Diamonds:
                return Instantiate(_diamondPrefab);

            case Card.SuitEnum.Spades:
                return Instantiate(_spadesPrefab);

            case Card.SuitEnum.Clubs:
                return Instantiate(_cloverPrefab);


            default:
               // Debug.Log("idk which suit");
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
